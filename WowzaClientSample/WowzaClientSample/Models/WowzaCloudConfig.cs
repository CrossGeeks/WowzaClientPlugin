using System;
using Plugin.WowzaClient;

namespace WowzaClientSample.Models
{
    public class WowzaCloudConfig : IWowzaConfig
    {
        public WowzaCloudConfig()
        {
        }

        public string HostAddress => "0467fc.entrypoint.cloud.wowza.com";

        public int PortNumber => 1935;

        public string ApplicationName => "app-1264";

        public string StreamName => "0e68bed6";

        public string Username => "client39318";

        public string Password => "password";
    }
}
