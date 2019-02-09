using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.WowzaClient
{
    public interface IWowzaConfig
    {
        string HostAddress { get; }
        int    PortNumber { get; }
        string ApplicationName { get; }
        string StreamName { get; }
        string Username { get; }
        string Password { get; }
    }
}
