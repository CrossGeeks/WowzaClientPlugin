using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.WowzaClient
{
    public enum WowzaClientStatus
    {
        Idle,
        MaxState,
        MinState,
        Paused,
        PreBufferringEnded,
        PreBufferringStarted,
        Ready,
        Running,
        Shutdown,
        Starting,
        Stopped,
        Stopping,
        Unknown,
    }

    public interface IWowzaClientManager
    {
        event WOWZPlayerStatusChangedEventHandler OnPlayerStatusChanged;
        event WOWZErrorEventHandler OnError;
        float Volume { get; set; }
        bool IsPlaying { get; }
        bool IsReadyToPlay { get; }
        void Play();
        void Stop();
        void Setup(IWowzaConfig config);
    }

    public delegate void WOWZPlayerStatusChangedEventHandler(object source, WOWZPlayerStatusChangedEventHandlerEventArgs e);
    public class WOWZPlayerStatusChangedEventHandlerEventArgs : EventArgs
    {
        public WowzaClientStatus State { get; set; }
        public string Message { get; set; }

        public WOWZPlayerStatusChangedEventHandlerEventArgs() { }
        public WOWZPlayerStatusChangedEventHandlerEventArgs(WowzaClientStatus state, string message)
        {
            State = state;
            Message = message;
        }
    }

    public delegate void WOWZErrorEventHandler(object source, WOWZErrorEventHandlerEventArgs e);
    public class WOWZErrorEventHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }

        public WOWZErrorEventHandlerEventArgs() { }
        public WOWZErrorEventHandlerEventArgs(string message)
        {
            Message = message;
        }
    }
}
