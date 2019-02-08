using System;
using ObjCRuntime;
using Wowza;

namespace Wowza
{
    [Native]
    public enum WOWZState : long
    {
        Idle = 0,
        Starting,
        Running,
        Stopping,
        Buffering,
        Ready
    }

    [Native]
    public enum WOWZEvent : long
    {
        None = 0,
        LowBandwidth,
        BitrateReduced,
        BitrateIncreased,
        EncoderPaused,
        EncoderResumed
    }

    [Native]
    public enum WOWZFrameSizePreset : long
    {
        WOWZFrameSizePreset352x288,
        WOWZFrameSizePreset640x480,
        WOWZFrameSizePreset1280x720,
        WOWZFrameSizePreset1920x1080,
        WOWZFrameSizePreset3840x2160,
        Count
    }

    [Native]
    public enum WOWZBroadcastOrientation : long
    {
        SameAsDevice,
        AlwaysLandscape,
        AlwaysPortrait
    }

    [Native]
    public enum WOWZBroadcastScaleMode : long
    {
        t,
        ll
    }

    [Native]
    public enum WOWZAudioChannels : long
    {
        Mono = 1,
        Stereo = 2
    }

    [Native]
    public enum WOWZDataType : long
    {
        Null,
        String,
        Boolean,
        Date,
        Integer,
        Float,
        Double,
        Map,
        List
    }

    [Native]
    public enum WOWZDataScope : long
    {
        Module,
        Stream
    }

    [Native]
    public enum WOWZCameraDirection : long
    {
        Back = 0,
        Front
    }

    [Native]
    public enum WOWZCameraFocusMode : long
    {
        Locked = 0,
        Auto,
        Continuous
    }

    [Native]
    public enum WOWZCameraExposureMode : long
    {
        Locked = 0,
        Auto,
        Continuous
    }

    [Native]
    public enum WOWZCameraPreviewGravity : long
    {
        Aspect = 0,
        AspectFill,
        WOWZCameraPreviewGravityResize
    }

    [Native]
    public enum WOWZPlayerViewGravity : long
    {
        Aspect = 0,
        AspectFill,
    }

    [Native]
    public enum WOWZError : long
    {
        NoError = 0,
        InvalidHostAddress,
        InvalidPortNumber,
        InvalidApplicationName,
        InvalidStreamName,
        InvalidUsernameOrPassword,
        ConnectionError,
        InitializationError,
        InternalError,
        InvalidSDKLicense,
        ExpiredSDKLicense,
        CameraAccessDenied,
        MicrophoneAccessDenied,
        MicrophoneInsufficientPriority,
        InvalidAudioConfiguration,
        UnknownError
    }

    [Native]
    public enum WowzaGoCoderLogLevel : long
    {
        Off,
        Default,
        Verbose
    }

    [Native]
    public enum WowzaGoCoderCapturePermission : long
    {
        Authorized,
        Denied,
        NotDetermined
    }

    [Native]
    public enum WowzaGoCoderPermissionType : long
    {
        Camera,
        Microphone
    }
}
