#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkAudioSettings : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkAudioSettings(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkAudioSettings obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~AkAudioSettings() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkAudioSettings(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public uint uNumSamplesPerFrame { set { AkSoundEnginePINVOKE.CSharp_AkAudioSettings_uNumSamplesPerFrame_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkAudioSettings_uNumSamplesPerFrame_get(swigCPtr); } 
  }

  public uint uNumSamplesPerSecond { set { AkSoundEnginePINVOKE.CSharp_AkAudioSettings_uNumSamplesPerSecond_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkAudioSettings_uNumSamplesPerSecond_get(swigCPtr); } 
  }

  public AkAudioSettings() : this(AkSoundEnginePINVOKE.CSharp_new_AkAudioSettings(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.