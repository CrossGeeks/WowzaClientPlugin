using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.WowzaClient
{
    public class WowzaClientBaseException : Exception
    {
        public const string PlayerDefaultErrorMessage = "The Wowza Client player has not completed it's process correctly.";
        public const string WowzaClientNotInitializedErrorMessage = "The Wowza Client is not initialized correctly.";
        public const string WowzaClientNotSetupErrorMessage = "The Wowza Client is not setup.";
        public const string WowzaClientPlayerViewNotAttachedErrorMessage = "The Wowza Client player view it not attached correctly.";
        public const string WowzaClientLicensingKeyErrorMessage = "The Wowza Client key is not valid.";
        public const string WowzaClientHslUrlParameterNullOrEmptyErrorMessage = "The HslUrl parameter is null or empty.";

        public WowzaClientBaseException() : base(PlayerDefaultErrorMessage) { }
        public WowzaClientBaseException(string message) : base(message) { }
        public WowzaClientBaseException(string message, Exception inner) : base(PlayerDefaultErrorMessage, inner) { }
    }

    public class WowzaClientNotInitializedException : WowzaClientBaseException
    {
        public WowzaClientNotInitializedException() : base(WowzaClientNotInitializedErrorMessage) { }
        public WowzaClientNotInitializedException(string message) : base(message) { }
        public WowzaClientNotInitializedException(string message, Exception inner) : base(WowzaClientNotInitializedErrorMessage, inner) { }
    }

    public class WowzaClientNotSetupException : WowzaClientBaseException
    {
        public WowzaClientNotSetupException() : base(WowzaClientNotSetupErrorMessage) { }
        public WowzaClientNotSetupException(string message) : base(message) { }
        public WowzaClientNotSetupException(string message, Exception inner) : base(WowzaClientNotSetupErrorMessage, inner) { }
    }

    public class WowzaClientPlayerViewNotAttachedException : WowzaClientBaseException
    {
        public WowzaClientPlayerViewNotAttachedException() : base(WowzaClientPlayerViewNotAttachedErrorMessage) { }
        public WowzaClientPlayerViewNotAttachedException(string message) : base(message) { }
        public WowzaClientPlayerViewNotAttachedException(string message, Exception inner) : base(WowzaClientPlayerViewNotAttachedErrorMessage, inner) { }
    }

    public class WowzaClientLicensingKeyException : WowzaClientBaseException
    {
        public WowzaClientLicensingKeyException() : base(WowzaClientLicensingKeyErrorMessage) { }
        public WowzaClientLicensingKeyException(string message) : base(message) { }
        public WowzaClientLicensingKeyException(string message, Exception inner) : base(WowzaClientLicensingKeyErrorMessage, inner) { }
    }

    public class WowzaClientHslUrlParameterNullOrEmptyException : WowzaClientBaseException
    {
        public WowzaClientHslUrlParameterNullOrEmptyException() : base(WowzaClientHslUrlParameterNullOrEmptyErrorMessage) { }
        public WowzaClientHslUrlParameterNullOrEmptyException(string message) : base(message) { }
        public WowzaClientHslUrlParameterNullOrEmptyException(string message, Exception inner) : base(WowzaClientHslUrlParameterNullOrEmptyErrorMessage, inner) { }
    }
}
