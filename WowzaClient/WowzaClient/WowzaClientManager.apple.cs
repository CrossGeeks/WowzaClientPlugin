using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Wowza;

namespace Plugin.WowzaClient
{
    /// <summary>
    /// Interface for WowzaClient
    /// </summary>
    public class WowzaClientManager : NSObject, IWowzaClientManager
    {
        IWowzaConfig wowzaConfig;
        public static WowzaConfig Config;
        static WOWZPlayer Player;
        WowzaClientStatusCallback wowzaClientStatusCallback = new WowzaClientStatusCallback();

        public float Volume
        {
            get
            {
                return Player?.Volume ?? 0;
            }
            set
            {
                if (Player != null)
                    Player.Volume = value;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return Player?.Playing ?? false;
            }
        }

        public bool IsReadyToPlay
        {
            get
            {
                return IsPlaying;
            }
        }

        public WowzaClientManager()
        {
            if (Player == null)
                throw new WowzaClientNotInitializedException();
        }

        public static void Initialize(string key)
        {
            var goCoderLicensingError = WowzaGoCoder.RegisterLicenseKey(key);
            if (goCoderLicensingError != null)
            {
                // Log license key registration failure
                Console.WriteLine(goCoderLicensingError.LocalizedDescription);
                throw new WowzaClientLicensingKeyException(goCoderLicensingError.LocalizedDescription);
            }

            Player = new WOWZPlayer();
        }


        static WOWZPlayerStatusChangedEventHandler _OnPlayerStatusChanged;
        public event WOWZPlayerStatusChangedEventHandler OnPlayerStatusChanged
        {
            add
            {
                _OnPlayerStatusChanged += value;
            }
            remove
            {
                _OnPlayerStatusChanged -= value;
            }
        }

        static WOWZErrorEventHandler _OnError;
        public event WOWZErrorEventHandler OnError
        {
            add
            {
                _OnError += value;
            }
            remove
            {
                _OnError -= value;
            }
        }

        public void Play()
        {
            if (Config == null)
                throw new WowzaClientNotSetupException();

            if (Player.PlayerView == null)
                throw new WowzaClientPlayerViewNotAttachedException();

            if (!Player.Playing)
            {
                Player.Play(Config, wowzaClientStatusCallback);
            }
            else
            {
                Player.ResetPlaybackErrorCount();
                Player.Stop();
            }
        }

        public static void AttachPlayerView(UIView view)
        {
            if (Config == null)
                throw new WowzaClientNotSetupException();

            Player.PlayerView = view;
        }


        public static void ResetPlaybackErrorCount()
        {
            Player.ResetPlaybackErrorCount();
        }

        public static void UpdateViewLayouts()
        {
            Player.UpdateViewLayouts();
        }

        public static void AllowHSLPlayback(bool allow, string hslUrl)
        {
            Config.AllowHLSPlayback = allow;

            if (allow && string.IsNullOrEmpty(hslUrl))
                throw new WowzaClientHslUrlParameterNullOrEmptyException();

            Config.HlsURL = hslUrl;
        }

        public void Stop()
        {
            if (Config == null)
                throw new WowzaClientNotSetupException();

            if (Player.PlayerView == null)
                throw new WowzaClientPlayerViewNotAttachedException();

            if (Player.Playing)
                Player.Stop();

        }

        public void Setup(IWowzaConfig config)
        {
            if (config == null)
                throw new ArgumentNullException();

            Config = new WowzaConfig();
            // Perform any additional setup after loading the view, typically from a nib.
            Config.AudioEnabled = true;
            //Config.VideoEnabled = true;

            Config.HostAddress = config.HostAddress;
            Config.PortNumber = (nuint)config.PortNumber;
            Config.ApplicationName = config.ApplicationName;
            Config.StreamName = config.StreamName;
            Config.Username = config.Username;
            Config.Password = config.Password;

            WowzaGoCoder.SetLogLevel(WowzaGoCoderLogLevel.Verbose);

            Console.WriteLine(string.Format("{0} {1} {2} {3}", WOWZVersionInfo.MajorVersion, WOWZVersionInfo.MinorVersion,
                                            WOWZVersionInfo.Revision, WOWZVersionInfo.BuildNumber));
        }

        class WowzaClientStatusCallback : WOWZStatusCallback
        {
            public override void OnWOWZError(WOWZStatus status)
            {
                Player.Stop();
                Player.ResetPlaybackErrorCount();
                var errorArgs = new WOWZErrorEventHandlerEventArgs();
                errorArgs.Message = status.Description;
                _OnError?.Invoke(this, errorArgs);
            }

            public override void OnWOWZStatus(WOWZStatus status)
            {
                string statusMessage = ("Player status: ");
                var statusArgs = new WOWZPlayerStatusChangedEventHandlerEventArgs();

                switch (status.State)
                {
                    case WOWZState.Starting:
                        statusArgs.State = WowzaClientStatus.Starting;
                        statusMessage += ("Player initializing");
                        break;

                    case WOWZState.Ready:
                        statusArgs.State = WowzaClientStatus.Ready;
                        statusMessage += ("Ready to begin listening");
                        break;

                    case WOWZState.Running:
                        statusArgs.State = WowzaClientStatus.Running;
                        statusMessage += ("Player is active");
                        break;

                    case WOWZState.Stopping:
                        statusArgs.State = WowzaClientStatus.Stopping;
                        statusMessage += ("Player shutting down");
                        break;

                    case WOWZState.Idle:
                        statusArgs.State = WowzaClientStatus.Idle;
                        statusMessage += ("The Player is stopped");
                        break;
                }

                statusArgs.Message = statusMessage;
                _OnPlayerStatusChanged?.Invoke(this, statusArgs);
            }
        }
    }
}
