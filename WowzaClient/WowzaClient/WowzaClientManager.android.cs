using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.WowzaClient
{
    /// <summary>
    /// Interface for WowzaClient
    /// </summary>
    public class WowzaClientManager : IWowzaClientManager
    {
        public float Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsPlaying => throw new NotImplementedException();

        public bool IsReadyToPlay => throw new NotImplementedException();

        public event WOWZPlayerStatusChangedEventHandler OnPlayerStatusChanged;
        public event WOWZErrorEventHandler OnError;

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Setup(IWowzaConfig config)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
