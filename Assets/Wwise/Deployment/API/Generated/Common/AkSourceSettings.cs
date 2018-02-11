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


public class AkSourceSettings : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkSourceSettings(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkSourceSettings obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~AkSourceSettings() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkSourceSettings(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public uint sourceID { set { AkSoundEnginePINVOKE.CSharp_AkSourceSettings_sourceID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkSourceSettings_sourceID_get(swigCPtr); } 
  }

  public global::System.IntPtr pMediaMemory { set { AkSoundEnginePINVOKE.CSharp_AkSourceSettings_pMediaMemory_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkSourceSettings_pMediaMemory_get(swigCPtr); }
  }

  public uint uMediaSize { set { AkSoundEnginePINVOKE.CSharp_AkSourceSettings_uMediaSize_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkSourceSettings_uMediaSize_get(swigCPtr); } 
  }

  public AkSourceSettings() : this(AkSoundEnginePINVOKE.CSharp_new_AkSourceSettings(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.