
// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
// to the project by right-clicking (or Control-clicking) the folder containing this source
// file and clicking "Add files..." and then simply select the native library (or libraries)
// that you want to bind.
//
// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
// architectures that the native library supports and fills in that information for you,
// however, it cannot auto-detect any Frameworks or other system libraries that the
// native library may depend on, so you'll need to fill in that information yourself.
//
// Once you've done that, you're ready to move on to binding the API...
//
//
// Here is where you'd define your API definition for the native Objective-C library.
//
// For example, to bind the following Objective-C class:
//
//     @interface Widget : NSObject {
//     }
//
// The C# binding would look like this:
//
//     [BaseType (typeof (NSObject))]
//     interface Widget {
//     }
//
// To bind Objective-C properties, such as:
//
//     @property (nonatomic, readwrite, assign) CGPoint center;
//
// You would add a property definition in the C# interface like so:
//
//     [Export ("center")]
//     CGPoint Center { get; set; }
//
// To bind an Objective-C method, such as:
//
//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
//
// You would add a method definition to the C# interface like so:
//
//     [Export ("doSomething:atIndex:")]
//     void DoSomething (NSObject object, int index);
//
// Objective-C "constructors" such as:
//
//     -(id)initWithElmo:(ElmoMuppet *)elmo;
//
// Can be bound as:
//
//     [Export ("initWithElmo:")]
//     IntPtr Constructor (ElmoMuppet elmo);
//
// For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
//
using System;
using AVFoundation;
using AudioToolbox;

using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;
//using WowzaGoCoderSDK;

namespace Wowza
{
    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull WOWZStatusNewBitrateKey;
        [Field("WOWZStatusNewBitrateKey", "__Internal")]
        NSString WOWZStatusNewBitrateKey { get; }

        // extern NSString *const _Nonnull WOWZStatusPreviousBitrateKey;
        [Field("WOWZStatusPreviousBitrateKey", "__Internal")]
        NSString WOWZStatusPreviousBitrateKey { get; }
    }

    // @interface WOWZStatus : NSObject <NSMutableCopying, NSCopying>
    [BaseType(typeof(NSObject))]
    interface WOWZStatus : INSMutableCopying, INSCopying
    {
        // @property (nonatomic) WOWZState state;
        [Export("state", ArgumentSemantic.Assign)]
        WOWZState State { get; set; }

        // @property (nonatomic) WOWZEvent event;
        [Export("event", ArgumentSemantic.Assign)]
        WOWZEvent Event { get; set; }

        // @property (nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; set; }

        // @property (nonatomic, strong) NSDictionary * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        NSDictionary Data { get; set; }

        // +(instancetype _Nonnull)statusWithState:(WOWZState)aState;
        [Static]
        [Export("statusWithState:")]
        WOWZStatus StatusWithState(WOWZState aState);

        // +(instancetype _Nonnull)statusWithStateAndError:(WOWZState)aState aError:(NSError * _Nonnull)aError;
        [Static]
        [Export("statusWithStateAndError:aError:")]
        WOWZStatus StatusWithStateAndError(WOWZState aState, NSError aError);

        // +(instancetype _Nonnull)statusWithEvent:(WOWZEvent)event;
        [Static]
        [Export("statusWithEvent:")]
        WOWZStatus StatusWithEvent(WOWZEvent @event);

        // +(instancetype _Nonnull)statusWithState:(WOWZState)aState event:(WOWZEvent)event;
        [Static]
        [Export("statusWithState:event:")]
        WOWZStatus StatusWithState(WOWZState aState, WOWZEvent @event);

        // -(instancetype _Nonnull)initWithState:(WOWZState)aState;
        [Export("initWithState:")]
        IntPtr Constructor(WOWZState aState);

        // -(instancetype _Nonnull)initWithStateAndError:(WOWZState)aState aError:(NSError * _Nonnull)aError;
        [Export("initWithStateAndError:aError:")]
        IntPtr Constructor(WOWZState aState, NSError aError);

        // -(instancetype _Nonnull)initWithEvent:(WOWZEvent)event;
        [Export("initWithEvent:")]
        IntPtr Constructor(WOWZEvent @event);

        // -(instancetype _Nonnull)initWithState:(WOWZState)aState event:(WOWZEvent)event;
        [Export("initWithState:event:")]
        IntPtr Constructor(WOWZState aState, WOWZEvent @event);

        // -(void)resetStatus;
        [Export("resetStatus")]
        void ResetStatus();

        // -(void)resetStatusWithState:(WOWZState)aState;
        [Export("resetStatusWithState:")]
        void ResetStatusWithState(WOWZState aState);

        // @property (readonly, nonatomic) BOOL isIdle;
        [Export("isIdle")]
        bool IsIdle { get; }

        // @property (readonly, nonatomic) BOOL isStarting;
        [Export("isStarting")]
        bool IsStarting { get; }

        // @property (readonly, nonatomic) BOOL isReady;
        [Export("isReady")]
        bool IsReady { get; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (readonly, nonatomic) BOOL isStopping;
        [Export("isStopping")]
        bool IsStopping { get; }

        // @property (readonly, nonatomic) BOOL hasError;
        [Export("hasError")]
        bool HasError { get; }
    }

    // @interface WOWZMediaConfig : NSObject <NSMutableCopying, NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface WOWZMediaConfig : INSMutableCopying, INSCopying, INSCoding
    {
        // +(NSString * _Nullable)AVCaptureSessionPresetFromPreset:(WOWZFrameSizePreset)wzPreset;
        [Static]
        [Export("AVCaptureSessionPresetFromPreset:")]
        [return: NullAllowed]
        string AVCaptureSessionPresetFromPreset(WOWZFrameSizePreset wzPreset);

        // +(CGSize)CGSizeFromPreset:(WOWZFrameSizePreset)preset;
        [Static]
        [Export("CGSizeFromPreset:")]
        CGSize CGSizeFromPreset(WOWZFrameSizePreset preset);

        // +(NSString * _Nullable)closestAVCaptureSessionPresetByWidth:(NSUInteger)width;
        [Static]
        [Export("closestAVCaptureSessionPresetByWidth:")]
        [return: NullAllowed]
        string ClosestAVCaptureSessionPresetByWidth(nuint width);

        // +(NSArray * _Nonnull)presets;
        [Static]
        [Export("presets")]
        ////[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] Presets { get; }

        // +(NSArray * _Nonnull)presetConfigs;
        [Static]
        [Export("presetConfigs")]
        ////[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] PresetConfigs { get; }

        // @property (assign, nonatomic) BOOL videoEnabled;
        [Export("videoEnabled")]
        bool VideoEnabled { get; set; }

        // @property (assign, nonatomic) BOOL audioEnabled;
        [Export("audioEnabled")]
        bool AudioEnabled { get; set; }

        // @property (assign, nonatomic) NSUInteger videoWidth;
        [Export("videoWidth")]
        nuint VideoWidth { get; set; }

        // @property (assign, nonatomic) NSUInteger videoHeight;
        [Export("videoHeight")]
        nuint VideoHeight { get; set; }

        // @property (assign, nonatomic) NSUInteger videoFrameRate;
        [Export("videoFrameRate")]
        nuint VideoFrameRate { get; set; }

        // @property (assign, nonatomic) NSUInteger videoKeyFrameInterval;
        [Export("videoKeyFrameInterval")]
        nuint VideoKeyFrameInterval { get; set; }

        // @property (assign, nonatomic) NSUInteger videoBitrate;
        [Export("videoBitrate")]
        nuint VideoBitrate { get; set; }

        // @property (assign, nonatomic) Float32 videoBitrateLowBandwidthScalingFactor;
        [Export("videoBitrateLowBandwidthScalingFactor")]
        float VideoBitrateLowBandwidthScalingFactor { get; set; }

        // @property (assign, nonatomic) NSUInteger videoFrameBufferSizeMultiplier;
        [Export("videoFrameBufferSizeMultiplier")]
        nuint VideoFrameBufferSizeMultiplier { get; set; }

        // @property (assign, nonatomic) NSUInteger videoFrameRateLowBandwidthSkipCount;
        [Export("videoFrameRateLowBandwidthSkipCount")]
        nuint VideoFrameRateLowBandwidthSkipCount { get; set; }

        // @property (assign, nonatomic) BOOL capturedVideoRotates;
        [Export("capturedVideoRotates")]
        bool CapturedVideoRotates { get; set; }

        // @property (assign, nonatomic) BOOL videoPreviewRotates;
        [Export("videoPreviewRotates")]
        bool VideoPreviewRotates { get; set; }

        // @property (assign, nonatomic) WOWZBroadcastOrientation broadcastVideoOrientation;
        [Export("broadcastVideoOrientation", ArgumentSemantic.Assign)]
        WOWZBroadcastOrientation BroadcastVideoOrientation { get; set; }

        // @property (assign, nonatomic) WOWZBroadcastScaleMode broadcastScaleMode;
        [Export("broadcastScaleMode", ArgumentSemantic.Assign)]
        WOWZBroadcastScaleMode BroadcastScaleMode { get; set; }

        // @property (assign, nonatomic) BOOL mirrorFrontCamera;
        [Export("mirrorFrontCamera")]
        bool MirrorFrontCamera { get; set; }

        // @property (assign, nonatomic) BOOL backgroundBroadcastEnabled;
        [Export("backgroundBroadcastEnabled")]
        bool BackgroundBroadcastEnabled { get; set; }

        // @property (assign, nonatomic) NSUInteger audioChannels;
        [Export("audioChannels")]
        nuint AudioChannels { get; set; }

        // @property (assign, nonatomic) NSUInteger audioSampleRate;
        [Export("audioSampleRate")]
        nuint AudioSampleRate { get; set; }

        // @property (assign, nonatomic) NSUInteger audioBitrate;
        [Export("audioBitrate")]
        nuint AudioBitrate { get; set; }

        // @property (readonly, nonatomic) CGSize frameSize;
        [Export("frameSize")]
        CGSize FrameSize { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull frameSizeLabel;
        [Export("frameSizeLabel")]
        string FrameSizeLabel { get; }

        // -(instancetype _Nonnull)initWithPreset:(WOWZFrameSizePreset)preset;
        [Export("initWithPreset:")]
        IntPtr Constructor(WOWZFrameSizePreset preset);

        // -(void)loadPreset:(WOWZFrameSizePreset)preset;
        [Export("loadPreset:")]
        void LoadPreset(WOWZFrameSizePreset preset);

        // -(NSString * _Nullable)toAVCaptureSessionPreset;
        [NullAllowed, Export("toAVCaptureSessionPreset")]
        //[Verify(MethodToProperty)]
        string ToAVCaptureSessionPreset { get; }

        // -(NSString * _Nonnull)toClosestAVCaptureSessionPreset;
        [Export("toClosestAVCaptureSessionPreset")]
        //[Verify(MethodToProperty)]
        string ToClosestAVCaptureSessionPreset { get; }

        // -(WOWZFrameSizePreset)toPreset;
        [Export("toPreset")]
        //[Verify(MethodToProperty)]
        WOWZFrameSizePreset ToPreset { get; }

        // -(WOWZFrameSizePreset)toClosestPreset;
        [Export("toClosestPreset")]
        //[Verify(MethodToProperty)]
        WOWZFrameSizePreset ToClosestPreset { get; }

        // -(BOOL)equals:(WOWZMediaConfig * _Nonnull)other;
        [Export("equals:")]
        bool Equals(WOWZMediaConfig other);

        // -(BOOL)isPortrait;
        [Export("isPortrait")]
        //[Verify(MethodToProperty)]
        bool IsPortrait { get; }

        // -(BOOL)isLandscape;
        [Export("isLandscape")]
        //[Verify(MethodToProperty)]
        bool IsLandscape { get; }

        // -(void)copyTo:(WOWZMediaConfig * _Nonnull)other;
        [Export("copyTo:")]
        void CopyTo(WOWZMediaConfig other);


        // @property (nonatomic, assign) BOOL allowHLSPlayback;
        [Export("allowHLSPlayback", ArgumentSemantic.Assign)]
        bool AllowHLSPlayback { get; set; }

        // @property (nonatomic, assign) NSString * hlsURL;
        [Export("hlsURL", ArgumentSemantic.Assign)]
        string HlsURL { get; set; }
    }

    // typedef void (^WOWZDataCallback)(WZDataMap * _Nullable, BOOL);
    delegate void WOWZDataCallback([NullAllowed] WOWZDataMap arg0, bool arg1);

    // @interface WZDataItem : NSObject <NSMutableCopying, NSCopying, NSCoding>
    [BaseType(typeof(NSObject))]
    interface WOWZDataItem : INSMutableCopying, INSCopying, INSCoding
    {
        // @property (readonly, assign, nonatomic) WOWZDataType type;
        [Export("type", ArgumentSemantic.Assign)]
        WOWZDataType Type { get; }

        // +(instancetype _Nonnull)itemWithInteger:(NSInteger)value;
        [Static]
        [Export("itemWithInteger:")]
        WOWZDataItem ItemWithInteger(nint value);

        // +(instancetype _Nonnull)itemWithDouble:(double)value;
        [Static]
        [Export("itemWithDouble:")]
        WOWZDataItem ItemWithDouble(double value);

        // +(instancetype _Nonnull)itemWithFloat:(float)value;
        [Static]
        [Export("itemWithFloat:")]
        WOWZDataItem ItemWithFloat(float value);

        // +(instancetype _Nonnull)itemWithBool:(BOOL)value;
        [Static]
        [Export("itemWithBool:")]
        WOWZDataItem ItemWithBool(bool value);

        // +(instancetype _Nonnull)itemWithString:(NSString * _Nonnull)value;
        [Static]
        [Export("itemWithString:")]
        WOWZDataItem ItemWithString(string value);

        // +(instancetype _Nonnull)itemWithDate:(NSDate * _Nonnull)value;
        [Static]
        [Export("itemWithDate:")]
        WOWZDataItem ItemWithDate(NSDate value);

        // -(NSInteger)integerValue;
        [Export("integerValue")]
        //[Verify(MethodToProperty)]
        nint IntegerValue { get; }

        // -(double)doubleValue;
        [Export("doubleValue")]
        //[Verify(MethodToProperty)]
        double DoubleValue { get; }

        // -(float)floatValue;
        [Export("floatValue")]
        //[Verify(MethodToProperty)]
        float FloatValue { get; }

        // -(BOOL)boolValue;
        [Export("boolValue")]
        //[Verify(MethodToProperty)]
        bool BoolValue { get; }

        // -(NSString * _Nullable)stringValue;
        [NullAllowed, Export("stringValue")]
        //[Verify(MethodToProperty)]
        string StringValue { get; }

        // -(NSDate * _Nullable)dateValue;
        [NullAllowed, Export("dateValue")]
        //[Verify(MethodToProperty)]
        NSDate DateValue { get; }

        // -(WZDataMap * _Nullable)mapValue;
        [NullAllowed, Export("mapValue")]
        //[Verify(MethodToProperty)]
        WOWZDataMap MapValue { get; }

        // -(WOWZDataList * _Nullable)listValue;
        [NullAllowed, Export("listValue")]
        //[Verify(MethodToProperty)]
        WOWZDataList ListValue { get; }
    }

    // @interface WZDataMap : WZDataItem
    [BaseType(typeof(WOWZDataItem))]
    interface WOWZDataMap
    {
        // @property (readonly, nonatomic, strong) NSMutableDictionary<NSString *,WZDataItem *> * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        NSMutableDictionary<NSString, WOWZDataItem> Data { get; }

        // +(instancetype _Nonnull)dataMapWithDictionary:(NSDictionary<NSString *,WZDataItem *> * _Nonnull)dictionary;
        [Static]
        [Export("dataMapWithDictionary:")]
        WOWZDataMap DataMapWithDictionary(NSDictionary<NSString, WOWZDataItem> dictionary);

        // -(instancetype _Nonnull)initWithDictionary:(NSDictionary<NSString *,WZDataItem *> * _Nonnull)dictionary;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary<NSString, WOWZDataItem> dictionary);

        // -(void)setInteger:(NSInteger)value forKey:(NSString * _Nonnull)key;
        [Export("setInteger:forKey:")]
        void SetInteger(nint value, string key);

        // -(void)setDouble:(double)value forKey:(NSString * _Nonnull)key;
        [Export("setDouble:forKey:")]
        void SetDouble(double value, string key);

        // -(void)setFloat:(float)value forKey:(NSString * _Nonnull)key;
        [Export("setFloat:forKey:")]
        void SetFloat(float value, string key);

        // -(void)setBool:(BOOL)value forKey:(NSString * _Nonnull)key;
        [Export("setBool:forKey:")]
        void SetBool(bool value, string key);

        // -(void)setString:(NSString * _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setString:forKey:")]
        void SetString([NullAllowed] string value, string key);

        // -(void)setDate:(NSDate * _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setDate:forKey:")]
        void SetDate([NullAllowed] NSDate value, string key);

        // -(void)setItem:(WOWZDataItem * _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setItem:forKey:")]
        void SetItem([NullAllowed] WOWZDataItem value, string key);

        // -(void)setMap:(WOWZDataMap * _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setMap:forKey:")]
        void SetMap([NullAllowed] WOWZDataMap value, string key);

        // -(void)setList:(WOWZDataList * _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setList:forKey:")]
        void SetList([NullAllowed] WOWZDataList value, string key);

        // -(void)remove:(NSString * _Nonnull)key;
        [Export("remove:")]
        void Remove(string key);
    }

    // @interface WOWZDataList : WZDataItem
    [BaseType(typeof(WOWZDataItem))]
    interface WOWZDataList
    {
        // @property (readonly, nonatomic, strong) NSMutableArray<WOWZDataItem *> * _Nullable elements;
        [NullAllowed, Export("elements", ArgumentSemantic.Strong)]
        NSMutableArray<WOWZDataItem> Elements { get; }

        // +(instancetype _Nullable)dataListWithArray:(NSArray<WOWZDataItem *> * _Nonnull)array;
        [Static]
        [Export("dataListWithArray:")]
        [return: NullAllowed]
        WOWZDataList DataListWithArray(WOWZDataItem[] array);

        // +(NSUInteger)maximumSize;
        [Static]
        [Export("maximumSize")]
        //[Verify(MethodToProperty)]
        nuint MaximumSize { get; }

        // -(instancetype _Nullable)initWithArray:(NSArray<WOWZDataItem *> * _Nonnull)array;
        [Export("initWithArray:")]
        IntPtr Constructor(WOWZDataItem[] array);

        // -(void)addInteger:(NSInteger)value;
        [Export("addInteger:")]
        void AddInteger(nint value);

        // -(void)addDouble:(double)value;
        [Export("addDouble:")]
        void AddDouble(double value);

        // -(void)addFloat:(float)value;
        [Export("addFloat:")]
        void AddFloat(float value);

        // -(void)addBool:(BOOL)value;
        [Export("addBool:")]
        void AddBool(bool value);

        // -(void)addString:(NSString * _Nonnull)value;
        [Export("addString:")]
        void AddString(string value);

        // -(void)addDate:(NSDate * _Nonnull)value;
        [Export("addDate:")]
        void AddDate(NSDate value);

        // -(void)addItem:(WOWZDataItem * _Nonnull)value;
        [Export("addItem:")]
        void AddItem(WOWZDataItem value);

        // -(void)addMap:(WOWZDataMap * _Nonnull)value;
        [Export("addMap:")]
        void AddMap(WOWZDataMap value);

        // -(void)addList:(WOWZDataList * _Nonnull)value;
        [Export("addList:")]
        void AddList(WOWZDataList value);
    }

    // @interface WOWZStreamConfig : WOWZMediaConfig <NSMutableCopying, NSCopying, NSCoding>
    [BaseType(typeof(WOWZMediaConfig))]
    interface WOWZStreamConfig : INSMutableCopying, INSCopying, INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable hostAddress;
        [NullAllowed, Export("hostAddress", ArgumentSemantic.Strong)]
        string HostAddress { get; set; }

        // @property (assign, nonatomic) NSUInteger portNumber;
        [Export("portNumber")]
        nuint PortNumber { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable applicationName;
        [NullAllowed, Export("applicationName", ArgumentSemantic.Strong)]
        string ApplicationName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable streamName;
        [NullAllowed, Export("streamName", ArgumentSemantic.Strong)]
        string StreamName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable username;
        [NullAllowed, Export("username", ArgumentSemantic.Strong)]
        string Username { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable password;
        [NullAllowed, Export("password", ArgumentSemantic.Strong)]
        string Password { get; set; }

        // @property (nonatomic, strong) WOWZDataMap * _Nullable connectionParameters;
        [NullAllowed, Export("connectionParameters", ArgumentSemantic.Strong)]
        WOWZDataMap ConnectionParameters { get; set; }

        // -(instancetype _Nonnull)initWithPreset:(WOWZFrameSizePreset)preset;
        [Export("initWithPreset:")]
        IntPtr Constructor(WOWZFrameSizePreset preset);

        // -(NSError * _Nullable)validateForBroadcast;
        [NullAllowed, Export("validateForBroadcast")]
        //[Verify(MethodToProperty)]
        NSError ValidateForBroadcast { get; }

        // -(void)copyTo:(WOWZStreamConfig * _Nonnull)other;
        [Export("copyTo:")]
        void CopyTo(WOWZStreamConfig other);
    }

    // @protocol WOWZMediaSink <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WOWZMediaSink
    {
    }

    // @protocol WOWZBroadcastComponent <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WOWZBroadcastComponent
    {
        // @required -(WOWZStatus * _Nonnull)getStatus;
        [Abstract]
        [Export("getStatus")]
        //[Verify(MethodToProperty)]
        WOWZStatus Status { get; }

        // @required -(WOWZStatus * _Nonnull)prepareForBroadcast:(WOWZStreamConfig * _Nonnull)config;
        [Abstract]
        [Export("prepareForBroadcast:")]
        WOWZStatus PrepareForBroadcast(WOWZStreamConfig config);

        // @required -(WOWZStatus * _Nonnull)startBroadcasting;
        [Abstract]
        [Export("startBroadcasting")]
        //[Verify(MethodToProperty)]
        WOWZStatus StartBroadcasting { get; }

        // @required -(WOWZStatus * _Nonnull)stopBroadcasting;
        [Abstract]
        [Export("stopBroadcasting")]
        //[Verify(MethodToProperty)]
        WOWZStatus StopBroadcasting { get; }

        // @optional -(void)registerSink:(id<WOWZMediaSink> _Nonnull)sink;
        [Export("registerSink:")]
        void RegisterSink(WOWZMediaSink sink);

        // @optional -(void)unregisterSink:(id<WOWZMediaSink> _Nonnull)sink;
        [Export("unregisterSink:")]
        void UnregisterSink(WOWZMediaSink sink);
    }



    // @protocol WOWZAudioEncoderSink <WOWZMediaSink>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface WOWZAudioEncoderSink : WOWZMediaSink
    {
        // @optional -(void)audioSampleWasEncoded:(CMSampleBufferRef _Nullable)data;
        [Export("audioSampleWasEncoded:")]
        unsafe void AudioSampleWasEncoded([NullAllowed] CMSampleBuffer data);

        // @optional -(void)audioFrameWasEncoded:(void * _Nonnull)data size:(uint32_t)size time:(CMTime)time sampleRate:(Float64)sampleRate;
        //[Export("audioFrameWasEncoded:size:time:sampleRate:")]
        //unsafe void AudioFrameWasEncoded(void* data, uint size, CMTime time, double sampleRate);
    }

    // @protocol WOWZAudioSink <WOWZMediaSink>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface WOWZAudioSink : WOWZMediaSink
    {
        // @optional -(void)audioFrameWasCaptured:(void * _Nonnull)data size:(uint32_t)size time:(CMTime)time sampleRate:(Float64)sampleRate;
        //[Export("audioFrameWasCaptured:size:time:sampleRate:")]
        //unsafe void AudioFrameWasCaptured(void* data, uint size, CMTime time, double sampleRate);

        // @optional -(void)audioPCMFrameWasCaptured:(const AudioStreamBasicDescription * _Nonnull)pcmASBD bufferList:(const AudioBufferList * _Nonnull)bufferList time:(CMTime)time sampleRate:(Float64)sampleRate;
        [Export("audioPCMFrameWasCaptured:bufferList:time:sampleRate:")]
        unsafe void AudioPCMFrameWasCaptured(AudioStreamBasicDescription pcmASBD, AudioBuffers bufferList, CMTime time, double sampleRate);

        // @optional -(BOOL)canConvertStreamWithDescription:(const AudioStreamBasicDescription * _Nonnull)asbd;
        [Export("canConvertStreamWithDescription:")]
        unsafe bool CanConvertStreamWithDescription(AudioStreamBasicDescription asbd);

        // @optional -(void)audioLevelDidChange:(float)level;
        [Export("audioLevelDidChange:")]
        void AudioLevelDidChange(float level);
    }

    // @interface WOWZAACEncoder : NSObject <WOWZBroadcastComponent, WOWZAudioSink>
    [BaseType(typeof(NSObject))]
    interface WOWZAACEncoder : WOWZBroadcastComponent, WOWZAudioSink
    {
        // -(void)registerSink:(id<WOWZAudioEncoderSink> _Nonnull)sink;
        [Export("registerSink:")]
        void RegisterSink(WOWZAudioEncoderSink sink);

        // -(void)unregisterSink:(id<WOWZAudioEncoderSink> _Nonnull)sink;
        [Export("unregisterSink:")]
        void UnregisterSink(WOWZAudioEncoderSink sink);
    }

    // @interface WOWZAudioDevice : NSObject <WOWZBroadcastComponent>
    [BaseType(typeof(NSObject))]
    interface WOWZAudioDevice : WOWZBroadcastComponent
    {
        // @property (assign, nonatomic) BOOL paused;
        [Export("paused")]
        bool Paused { get; set; }

        // -(instancetype _Nonnull)initWithOptions:(AVAudioSessionCategoryOptions)options;
        [Export("initWithOptions:")]
        IntPtr Constructor(AVAudioSessionCategoryOptions options);

        // -(void)registerSink:(id<WOWZAudioSink> _Nonnull)sink;
        [Export("registerSink:")]
        void RegisterSink(WOWZAudioSink sink);

        // -(void)unregisterSink:(id<WOWZAudioSink> _Nonnull)sink;
        [Export("unregisterSink:")]
        void UnregisterSink(WOWZAudioSink sink);

        // +(NSArray * _Nullable)supportedBitratesForSampleRateAndChannels:(Float64)sampleRate channels:(UInt32)numChannels;
        [Static]
        [Export("supportedBitratesForSampleRateAndChannels:channels:")]
        //[Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        NSObject[] SupportedBitratesForSampleRateAndChannels(double sampleRate, uint numChannels);
    }

    // @protocol WOWZStatusCallback <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WOWZStatusCallback
    {
        // @required -(void)onWOWZStatus:(WOWZStatus *)status;
        [Abstract]
        [Export("onWOWZStatus:")]
        void OnWOWZStatus(WOWZStatus status);

        // @required -(void)onWOWZError:(WOWZStatus *)status;
        [Abstract]
        [Export("onWOWZError:")]
        void OnWOWZError(WOWZStatus status);

        // @optional -(void)onWOWOWZEvent:(WOWZStatus *)status;
        [Export("onWOWOWZEvent:")]
        void OnWOWOWZEvent(WOWZStatus status);
    }

    // @interface WOWZDataEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZDataEvent
    {
        // @property (nonatomic, strong) NSString * _Nullable eventName;
        [NullAllowed, Export("eventName", ArgumentSemantic.Strong)]
        string EventName { get; set; }

        // @property (nonatomic, strong) WOWZDataMap * _Nullable eventMapParams;
        [NullAllowed, Export("eventMapParams", ArgumentSemantic.Strong)]
        WOWZDataMap EventMapParams { get; set; }

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name mapParams:(WOWZDataMap * _Nonnull)mapParams;
        [Export("initWithName:mapParams:")]
        IntPtr Constructor(string name, WOWZDataMap mapParams);
    }

    // @protocol WOWZDataSink <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WOWZDataSink
    {
        // @required -(void)onData:(WOWZDataEvent * _Nonnull)dataEvent;
        [Abstract]
        [Export("onData:")]
        void OnData(WOWZDataEvent dataEvent);
    }

    // @interface WOWZBroadcast : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZBroadcast
    {
        // @property (readonly, nonatomic) WOWZStatus * _Nonnull status;
        [Export("status")]
        WOWZStatus Status { get; }

        // @property (nonatomic, unsafe_unretained) id<WOWZStatusCallback> _Nullable statusCallback;
        [NullAllowed, Export("statusCallback", ArgumentSemantic.Assign)]
        WOWZStatusCallback StatusCallback { get; set; }

        // @property (nonatomic, strong) id<WOWZBroadcastComponent> _Nullable videoEncoder;
        [NullAllowed, Export("videoEncoder", ArgumentSemantic.Strong)]
        WOWZBroadcastComponent VideoEncoder { get; set; }

        // @property (nonatomic, strong) id<WOWZBroadcastComponent> _Nullable audioEncoder;
        [NullAllowed, Export("audioEncoder", ArgumentSemantic.Strong)]
        WOWZBroadcastComponent AudioEncoder { get; set; }

        // @property (nonatomic, strong) id<WOWZBroadcastComponent> _Nullable audioDevice;
        [NullAllowed, Export("audioDevice", ArgumentSemantic.Strong)]
        WOWZBroadcastComponent AudioDevice { get; set; }

        // @property (readonly, nonatomic) WOWZDataMap * _Nullable metaData;
        [NullAllowed, Export("metaData")]
        WOWZDataMap MetaData { get; }

        // -(WOWZStatus * _Nonnull)startBroadcast:(WOWZStreamConfig * _Nonnull)config statusCallback:(id<WOWZStatusCallback> _Nullable)statusCallback;
        [Export("startBroadcast:statusCallback:")]
        WOWZStatus StartBroadcast(WOWZStreamConfig config, [NullAllowed] WOWZStatusCallback statusCallback);

        // -(WOWZStatus * _Nonnull)endBroadcast:(id<WOWZStatusCallback> _Nullable)statusCallback;
        [Export("endBroadcast:")]
        WOWZStatus EndBroadcast([NullAllowed] WOWZStatusCallback statusCallback);

        // -(void)sendDataEvent:(WOWZDataScope)scope eventName:(NSString * _Nonnull)eventName params:(WZDataMap * _Nonnull)params callback:(WOWZDataCallback _Nullable)callback;
        [Export("sendDataEvent:eventName:params:callback:")]
        void SendDataEvent(WOWZDataScope scope, string eventName, WOWZDataMap @params, [NullAllowed] WOWZDataCallback callback);

        // -(void)registerDataSink:(id<WOWZDataSink> _Nonnull)sink eventName:(NSString * _Nonnull)eventName;
        [Export("registerDataSink:eventName:")]
        void RegisterDataSink(WOWZDataSink sink, string eventName);

        // -(void)unregisterDataSink:(id<WOWZDataSink> _Nonnull)sink eventName:(NSString * _Nonnull)eventName;
        [Export("unregisterDataSink:eventName:")]
        void UnregisterDataSink(WOWZDataSink sink, string eventName);
    }

    // @interface WowzaConfig : WOWZStreamConfig <NSMutableCopying, NSCopying, NSCoding>
    [BaseType(typeof(WOWZStreamConfig))]
    interface WowzaConfig : INSMutableCopying, INSCopying, INSCoding
    {
        // -(instancetype _Nonnull)initWithPreset:(WOWZFrameSizePreset)preset;
        [Export("initWithPreset:")]
        IntPtr Constructor(WOWZFrameSizePreset preset);

        // -(void)copyTo:(WowzaConfig * _Nonnull)other;
        [Export("copyTo:")]
        void CopyTo(WowzaConfig other);
    }

    // @interface WOWZCamera : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface WOWZCamera
    {
        // @property (readonly) NSUInteger cameraId;
        [Export("cameraId")]
        nuint CameraId { get; }

        // @property (readonly) WOWZCameraDirection direction;
        [Export("direction")]
        WOWZCameraDirection Direction { get; }

        // @property (readonly, nonatomic) AVCaptureDevice * _Nonnull iOSCaptureDevice;
        [Export("iOSCaptureDevice")]
        AVCaptureDevice IOSCaptureDevice { get; }

        // @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull frameSizes;
        [Export("frameSizes")]
        NSValue[] FrameSizes { get; }

        // @property (readonly, nonatomic) NSArray<WOWZMediaConfig *> * _Nonnull supportedPresetConfigs;
        [Export("supportedPresetConfigs")]
        WOWZMediaConfig[] SupportedPresetConfigs { get; }

        // @property (readonly, nonatomic) BOOL hasTorch;
        [Export("hasTorch")]
        bool HasTorch { get; }

        // @property (getter = isTorchOn, nonatomic) BOOL torchOn;
        [Export("torchOn")]
        bool TorchOn { [Bind("isTorchOn")] get; set; }

        // @property (nonatomic) WOWZCameraFocusMode focusMode;
        [Export("focusMode", ArgumentSemantic.Assign)]
        WOWZCameraFocusMode FocusMode { get; set; }

        // @property (nonatomic) WOWZCameraExposureMode exposureMode;
        [Export("exposureMode", ArgumentSemantic.Assign)]
        WOWZCameraExposureMode ExposureMode { get; set; }

        // -(instancetype _Nonnull)initWithCaptureDevice:(AVCaptureDevice * _Nonnull)captureDevice;
        [Export("initWithCaptureDevice:")]
        IntPtr Constructor(AVCaptureDevice captureDevice);

        // -(BOOL)supportsWidth:(NSUInteger)width;
        [Export("supportsWidth:")]
        bool SupportsWidth(nuint width);

        // -(BOOL)supportsFocusMode:(WOWZCameraFocusMode)mode;
        [Export("supportsFocusMode:")]
        bool SupportsFocusMode(WOWZCameraFocusMode mode);

        // -(BOOL)supportsExposureMode:(WOWZCameraExposureMode)mode;
        [Export("supportsExposureMode:")]
        bool SupportsExposureMode(WOWZCameraExposureMode mode);

        // -(BOOL)isBack;
        [Export("isBack")]
        //[Verify(MethodToProperty)]
        bool IsBack { get; }

        // -(BOOL)isFront;
        [Export("isFront")]
        //[Verify(MethodToProperty)]
        bool IsFront { get; }

        // -(void)setFocusMode:(WOWZCameraFocusMode)focusMode focusPoint:(CGPoint)point;
        [Export("setFocusMode:focusPoint:")]
        void SetFocusMode(WOWZCameraFocusMode focusMode, CGPoint point);

        // -(void)setExposureMode:(WOWZCameraExposureMode)exposureMode exposurePoint:(CGPoint)point;
        [Export("setExposureMode:exposurePoint:")]
        void SetExposureMode(WOWZCameraExposureMode exposureMode, CGPoint point);
    }



    // @interface WOWZPlayer : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZPlayer
    {
        // @property (nonatomic, assign) WOWZPlayerViewGravity playerViewGravity;
        [Export("playerViewGravity", ArgumentSemantic.Assign)]
        WOWZPlayerViewGravity PlayerViewGravity { get; }

        // @property (nonatomic, unsafe_unretained, nonnull) UIView *playerView;
        [Export("playerView", ArgumentSemantic.Assign) ]
        UIView PlayerView { get; set; }

        // @property (nonatomic, assign, readonly) BOOL playing;
        [Export("playing", ArgumentSemantic.Assign)]
        bool Playing { get; }

        // @property (nonatomic, assign) Float32 volume;
        [Export("volume", ArgumentSemantic.Assign)]
        float Volume { get; set; }

        // @property (nonatomic, assign) Float32 syncOffset;
        [Export("syncOffset", ArgumentSemantic.Assign)]
        float SyncOffset { get; set; }

        // @property (nonatomic, assign) BOOL muted;
        [Export("muted", ArgumentSemantic.Assign)]
        bool Muted { get; set; }

        // @property (nonatomic, assign) Float64 prerollDuration;
        [Export("prerollDuration", ArgumentSemantic.Assign)]
        double PrerollDuration { get; set; }

        // @property (nonatomic, readonly, nullable) WOWZDataMap *metaData;
        [NullAllowed, Export("metaData")]
        WOWZDataMap MetaData { get; }

        // @property (nonatomic, readonly) CMTime currentTime;
        [Export("currentTime")]
        CMTime CurrentTime { get; }

        // @property (nonatomic, assign) BOOL useHLSFallback;
        [NullAllowed, Export("useHLSFallback", ArgumentSemantic.Assign)]
        bool UseHLSFallback { get; }

        // @property (nonatomic, unsafe_unretained) NSObject<WOWZStatusCallback> *clientCallback;
        [Export("clientCallback", ArgumentSemantic.Assign)]
        WOWZStatusCallback ClientCallback { get; }

        // -(void) play:(nonnull WowzaConfig *)config callback:(nullable id<WOWZStatusCallback>)statusCallback;
        [Export("play:callback:")]
        void Play(WowzaConfig config, [NullAllowed] WOWZStatusCallback statusCallback);

        // - (void) stop;
        [Export("stop")]
        void Stop();

        // -(void)updateViewLayouts;
        [Export("updateViewLayouts")]
        void UpdateViewLayouts();

        //-(void)setupHLSWithView:(UIView *_Nullable)viewToAttachTo;
        [Export("setupHLSWithView:")]
        void SetupHLSWithView([NullAllowed] UIView viewToAttachTo);

        // -(void)startHLSPlayback;
        [Export("startHLSPlayback")]
        void StartHLSPlayback();

        // -(void)stopHLSPlayback;
        [Export("stopHLSPlayback")]
        void StopHLSPlayback();

        // -(void)pauseHLSPlayback;
        [Export("pauseHLSPlayback")]
        void PauseHLSPlayback();

        // -(void)resetPlaybackErrorCount;
        [Export("resetPlaybackErrorCount")]
        void ResetPlaybackErrorCount();

        // - (void) registerDataSink:(nonnull id<WOWZDataSink>)sink eventName:(nonnull NSString *)eventName;
        [Export("registerDataSink:eventName:")]
        void RegisterDataSink(WOWZDataSink exposureMode, string eventName);

        // - (void) unregisterDataSink:(nonnull id<WOWZDataSink>)sink eventName:(nonnull NSString *)eventName;
        [Export("unregisterDataSink:eventName:")]
        void UnregisterDataSink(WOWZDataSink exposureMode, string eventName);
    }

    // @interface WZCameraPreview : NSObject
    [BaseType(typeof(NSObject))]
    //[DisableDefaultCtor]
    interface WOWZCameraPreview
    {
        // +(NSInteger)numberOfDeviceCameras;
        [Static]
        [Export("numberOfDeviceCameras")]
        //[Verify(MethodToProperty)]
        nint NumberOfDeviceCameras { get; }

        // +(NSArray<WZCamera *> * _Nonnull)deviceCameras;
        [Static]
        [Export("deviceCameras")]
        //[Verify(MethodToProperty)]
        WOWZCamera[] DeviceCameras { get; }

        // @property (nonatomic) WZCamera * _Nullable camera;
        [NullAllowed, Export("camera", ArgumentSemantic.Assign)]
        WOWZCamera Camera { get; set; }

        // @property (nonatomic) WowzaConfig * _Nonnull config;
        [Export("config", ArgumentSemantic.Assign)]
        WowzaConfig Config { get; set; }

        // @property (readonly, nonatomic) AVCaptureVideoPreviewLayer * _Nullable previewLayer;
        [NullAllowed, Export("previewLayer")]
        AVCaptureVideoPreviewLayer PreviewLayer { get; }

        // @property (assign, nonatomic) WOWZCameraPreviewGravity previewGravity;
        [Export("previewGravity", ArgumentSemantic.Assign)]
        WOWZCameraPreviewGravity PreviewGravity { get; set; }

        // @property (readonly, nonatomic) NSArray<WOWZCamera *> * _Nullable cameras;
        [NullAllowed, Export("cameras")]
        WOWZCamera[] Cameras { get; }

        // @property (readonly, getter = isPreviewActive, nonatomic) BOOL previewActive;
        [Export("previewActive")]
        bool PreviewActive { [Bind("isPreviewActive")] get; }

        // -(instancetype _Nonnull)initWithViewAndConfig:(UIView * _Nonnull)containingView config:(WowzaConfig * _Nonnull)aConfig;
        [Export("initWithViewAndConfig:config:")]
        IntPtr Constructor(UIView containingView, WowzaConfig aConfig);

        // -(void)startPreview;
        [Export("startPreview")]
        void StartPreview();

        // -(void)stopPreview;
        [Export("stopPreview")]
        void StopPreview();

        // -(BOOL)isSwitchCameraAvailableForConfig:(WOWZMediaConfig * _Nonnull)config;
        [Export("isSwitchCameraAvailableForConfig:")]
        bool IsSwitchCameraAvailableForConfig(WOWZMediaConfig config);

        // -(WOWZCamera * _Nonnull)switchCamera;
        [Export("switchCamera")]
        //[Verify(MethodToProperty)]
        WOWZCamera SwitchCamera { get; }

        // -(WOWZCamera * _Nullable)otherCamera;
        [NullAllowed, Export("otherCamera")]
        //[Verify(MethodToProperty)]
        WOWZCamera OtherCamera { get; }
    }

    // @protocol WOWZVideoEncoderSink <WOWZMediaSink>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface WOWZVideoEncoderSink : WOWZMediaSink
    {
        // @required -(void)videoFrameWasEncoded:(CMSampleBufferRef _Nonnull)data;
        //[Abstract]
        [Export("videoFrameWasEncoded:")]
        unsafe void VideoFrameWasEncoded(CMSampleBuffer data);

        // @optional -(void)videoBitrateDidChange:(NSUInteger)newBitrate previousBitrate:(NSUInteger)previousBitrate __attribute__((deprecated("")));
        [Export("videoBitrateDidChange:previousBitrate:")]
        void VideoBitrateDidChange(nuint newBitrate, nuint previousBitrate);
    }

    // @protocol WOWZVideoSink <WOWZMediaSink>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface WOWZVideoSink : WOWZMediaSink
    {
        // @required -(void)videoFrameWasCaptured:(CVImageBufferRef _Nonnull)imageBuffer framePresentationTime:(CMTime)framePresentationTime frameDuration:(CMTime)frameDuration;
        [Abstract]
        [Export("videoFrameWasCaptured:framePresentationTime:frameDuration:")]
        unsafe void VideoFrameWasCaptured(CVImageBuffer imageBuffer, CMTime framePresentationTime, CMTime frameDuration);

        // @optional -(void)videoCaptureInterruptionStarted;
        [Export("videoCaptureInterruptionStarted")]
        void VideoCaptureInterruptionStarted();

        // @optional -(void)videoCaptureInterruptionEnded;
        [Export("videoCaptureInterruptionEnded")]
        void VideoCaptureInterruptionEnded();

        // @optional -(void)videoCaptureUsingQueue:(dispatch_queue_t _Nullable)queue;
        [Export("videoCaptureUsingQueue:")]
        void VideoCaptureUsingQueue([NullAllowed] DispatchQueue queue);
    }

    // @interface WZH264Encoder : NSObject <WZBroadcastComponent, WOWZVideoSink>
    [BaseType(typeof(NSObject))]
    interface WOWZH264Encoder : WOWZBroadcastComponent, WOWZVideoSink
    {
        // @property (assign, nonatomic) OSType pixelFormat;
        [Export("pixelFormat")]
        uint PixelFormat { get; set; }

        // -(void)registerSink:(id<WOWZVideoEncoderSink> _Nonnull)sink;
        [Export("registerSink:")]
        void RegisterSink(WOWZVideoEncoderSink sink);

        // -(void)unregisterSink:(id<WOWZVideoEncoderSink> _Nonnull)sink;
        [Export("unregisterSink:")]
        void UnregisterSink(WOWZVideoEncoderSink sink);
    }

    // @interface WOWZImageUtilities : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZImageUtilities
    {
        // +(UIImage * _Nullable)imageFromCVPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer destinationImageSize:(CGSize)destinationImageSize;
        [Static]
        [Export("imageFromCVPixelBuffer:destinationImageSize:")]
        [return: NullAllowed]
        unsafe UIImage ImageFromCVPixelBuffer(CVPixelBuffer pixelBuffer, CGSize destinationImageSize);

        // +(UIImage * _Nullable)imageFromCVPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer destinationImageSize:(CGSize)destinationImageSize rotationAngle:(NSInteger)rotationAngle;
        [Static]
        [Export("imageFromCVPixelBuffer:destinationImageSize:rotationAngle:")]
        [return: NullAllowed]
        unsafe UIImage ImageFromCVPixelBuffer(CVPixelBuffer pixelBuffer, CGSize destinationImageSize, nint rotationAngle);
    }

    // @interface WOWZPlatformInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZPlatformInfo
    {
        // +(NSString * _Nonnull)model;
        [Static]
        [Export("model")]
        //[Verify(MethodToProperty)]
        string Model { get; }

        // +(NSString * _Nonnull)friendlyModel;
        [Static]
        [Export("friendlyModel")]
        //[Verify(MethodToProperty)]
        string FriendlyModel { get; }

        // +(NSString * _Nonnull)iOSVersion;
        [Static]
        [Export("iOSVersion")]
        //[Verify(MethodToProperty)]
        string IOSVersion { get; }

        // +(NSString * _Nonnull)string;
        [Static]
        [Export("string")]
        //[Verify(MethodToProperty)]
        string String { get; }
    }

    // @interface WOWZVersionInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface WOWZVersionInfo
    {
        // +(NSUInteger)majorVersion;
        [Static]
        [Export("majorVersion")]
        //[Verify(MethodToProperty)]
        nuint MajorVersion { get; }

        // +(NSUInteger)minorVersion;
        [Static]
        [Export("minorVersion")]
        //[Verify(MethodToProperty)]
        nuint MinorVersion { get; }

        // +(NSUInteger)revision;
        [Static]
        [Export("revision")]
        //[Verify(MethodToProperty)]
        nuint Revision { get; }

        // +(NSUInteger)buildNumber;
        [Static]
        [Export("buildNumber")]
        //[Verify(MethodToProperty)]
        nuint BuildNumber { get; }

        // +(NSString * _Nonnull)string;
        [Static]
        [Export("string")]
        //[Verify(MethodToProperty)]
        string String { get; }

        // +(NSString * _Nonnull)verboseString;
        [Static]
        [Export("verboseString")]
        //[Verify(MethodToProperty)]
        string VerboseString { get; }
    }

    // @interface WowzaGoCoder : NSObject <WOWZStatusCallback>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface WowzaGoCoder : WOWZStatusCallback
    {
        // +(NSError * _Nullable)registerLicenseKey:(NSString * _Nonnull)licenseKey;
        [Static]
        [Export("registerLicenseKey:")]
        [return: NullAllowed]
        NSError RegisterLicenseKey(string licenseKey);

        // +(void)setLogLevel:(WowzaGoCoderLogLevel)level;
        [Static]
        [Export("setLogLevel:")]
        void SetLogLevel(WowzaGoCoderLogLevel level);

        // +(void)requestPermissionForType:(WowzaGoCoderPermissionType)type response:(WOWZPermissionBlock _Nullable)response;
        [Static]
        [Export("requestPermissionForType:response:")]
        void RequestPermissionForType(WowzaGoCoderPermissionType type, [NullAllowed] WOWZPermissionBlock response);

        // +(WowzaGoCoderCapturePermission)permissionForType:(WowzaGoCoderPermissionType)type;
        [Static]
        [Export("permissionForType:")]
        WowzaGoCoderCapturePermission PermissionForType(WowzaGoCoderPermissionType type);

        // +(instancetype _Nullable)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        //[return: NullAllowed]
        WowzaGoCoder SharedInstance();

        // @property (copy, nonatomic) WowzaConfig * _Nonnull config;
        [Export("config", ArgumentSemantic.Copy)]
        WowzaConfig Config { get; set; }

        // @property (nonatomic) UIView * _Nullable cameraView;
        [NullAllowed, Export("cameraView", ArgumentSemantic.Assign)]
        UIView CameraView { get; set; }

        // @property (readonly, nonatomic) WOWZCameraPreview * _Nullable cameraPreview;
        [Export("cameraPreview")]
        WOWZCameraPreview CameraPreview { get; }

        // @property (readonly, nonatomic) WOWZStatus * _Nonnull status;
        [Export("status")]
        WOWZStatus Status { get; }

        // @property (getter = isAudioMuted, assign, nonatomic) BOOL audioMuted;
        [Export("audioMuted")]
        bool AudioMuted { [Bind("isAudioMuted")] get; set; }

        // @property (assign, nonatomic) AVAudioSessionCategoryOptions audioSessionOptions;
        [Export("audioSessionOptions", ArgumentSemantic.Assign)]
        AVAudioSessionCategoryOptions AudioSessionOptions { get; set; }

        // @property (readonly, nonatomic) BOOL isStreaming;
        [Export("isStreaming")]
        bool IsStreaming { get; }

        // @property (readonly, nonatomic) WZDataMap * _Nullable metaData;
        [NullAllowed, Export("metaData")]
        WOWZDataMap MetaData { get; }

        // -(void)startStreaming:(id<WOWZStatusCallback> _Nullable)statusCallback;
        [Export("startStreaming:")]
        void StartStreaming([NullAllowed] WOWZStatusCallback statusCallback);

        // -(void)startStreamingWithConfig:(id<WOWZStatusCallback> _Nullable)statusCallback config:(WowzaConfig * _Nonnull)aConfig;
        [Export("startStreamingWithConfig:config:")]
        void StartStreamingWithConfig([NullAllowed] WOWZStatusCallback statusCallback, WowzaConfig aConfig);

        // -(void)startStreamingWithPreset:(id<WOWZStatusCallback> _Nullable)statusCallback preset:(WOWZFrameSizePreset)aPreset;
        [Export("startStreamingWithPreset:preset:")]
        void StartStreamingWithPreset([NullAllowed] WOWZStatusCallback statusCallback, WOWZFrameSizePreset aPreset);

        // -(void)endStreaming:(id<WOWZStatusCallback> _Nullable)statusCallback;
        [Export("endStreaming:")]
        void EndStreaming([NullAllowed] WOWZStatusCallback statusCallback);

        // -(void)sendDataEvent:(WOWZDataScope)scope eventName:(NSString * _Nonnull)eventName params:(WZDataMap * _Nonnull)params callback:(WOWZDataCallback _Nullable)callback;
        [Export("sendDataEvent:eventName:params:callback:")]
        void SendDataEvent(WOWZDataScope scope, string eventName, WOWZDataMap @params, [NullAllowed] WOWZDataCallback callback);

        // -(void)registerVideoSink:(id<WOWZVideoSink> _Nonnull)sink;
        [Export("registerVideoSink:")]
        void RegisterVideoSink(WOWZVideoSink sink);

        // -(void)unregisterVideoSink:(id<WOWZVideoSink> _Nonnull)sink;
        [Export("unregisterVideoSink:")]
        void UnregisterVideoSink(WOWZVideoSink sink);

        // -(void)registerAudioSink:(id<WOWZAudioSink> _Nonnull)sink;
        [Export("registerAudioSink:")]
        void RegisterAudioSink(WOWZAudioSink sink);

        // -(void)unregisterAudioSink:(id<WOWZAudioSink> _Nonnull)sink;
        [Export("unregisterAudioSink:")]
        void UnregisterAudioSink(WOWZAudioSink sink);

        // -(void)registerVideoEncoderSink:(id<WOWZVideoEncoderSink> _Nonnull)sink;
        [Export("registerVideoEncoderSink:")]
        void RegisterVideoEncoderSink(WOWZVideoEncoderSink sink);

        // -(void)unregisterVideoEncoderSink:(id<WOWZVideoEncoderSink> _Nonnull)sink;
        [Export("unregisterVideoEncoderSink:")]
        void UnregisterVideoEncoderSink(WOWZVideoEncoderSink sink);

        // -(void)registerAudioEncoderSink:(id<WOWZAudioEncoderSink> _Nonnull)sink;
        [Export("registerAudioEncoderSink:")]
        void RegisterAudioEncoderSink(WOWZAudioEncoderSink sink);

        // -(void)unregisterAudioEncoderSink:(id<WOWZAudioEncoderSink> _Nonnull)sink;
        [Export("unregisterAudioEncoderSink:")]
        void UnregisterAudioEncoderSink(WOWZAudioEncoderSink sink);

        // -(void)registerDataSink:(id<WOWZDataSink> _Nonnull)sink eventName:(NSString * _Nonnull)eventName;
        [Export("registerDataSink:eventName:")]
        void RegisterDataSink(WOWZDataSink sink, string eventName);

        // -(void)unregisterDataSink:(id<WOWZDataSink> _Nonnull)sink eventName:(NSString * _Nonnull)eventName;
        [Export("unregisterDataSink:eventName:")]
        void UnregisterDataSink(WOWZDataSink sink, string eventName);
    }

    // typedef void (^WOWZPermissionBlock)(WowzaGoCoderCapturePermission);
    delegate void WOWZPermissionBlock(WowzaGoCoderCapturePermission arg0);
}

