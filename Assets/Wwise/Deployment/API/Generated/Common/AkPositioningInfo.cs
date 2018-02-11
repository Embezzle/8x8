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


public class AkPositioningInfo : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkPositioningInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkPositioningInfo obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~AkPositioningInfo() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkPositioningInfo(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public float fCenterPct { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fCenterPct_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fCenterPct_get(swigCPtr); } 
  }

  public AkPannerType pannerType { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_pannerType_set(swigCPtr, (int)value); }  get { return (AkPannerType)AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_pannerType_get(swigCPtr); } 
  }

  public AkPositionSourceType posSourceType { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_posSourceType_set(swigCPtr, (int)value); }  get { return (AkPositionSourceType)AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_posSourceType_get(swigCPtr); } 
  }

  public bool bUpdateEachFrame { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUpdateEachFrame_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUpdateEachFrame_get(swigCPtr); } 
  }

  public bool bUseSpatialization { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseSpatialization_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseSpatialization_get(swigCPtr); } 
  }

  public bool bUseAttenuation { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseAttenuation_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseAttenuation_get(swigCPtr); } 
  }

  public bool bUseConeAttenuation { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseConeAttenuation_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_bUseConeAttenuation_get(swigCPtr); } 
  }

  public float fInnerAngle { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fInnerAngle_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fInnerAngle_get(swigCPtr); } 
  }

  public float fOuterAngle { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fOuterAngle_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fOuterAngle_get(swigCPtr); } 
  }

  public float fConeMaxAttenuation { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fConeMaxAttenuation_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fConeMaxAttenuation_get(swigCPtr); } 
  }

  public float LPFCone { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_LPFCone_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_LPFCone_get(swigCPtr); } 
  }

  public float HPFCone { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_HPFCone_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_HPFCone_get(swigCPtr); } 
  }

  public float fMaxDistance { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fMaxDistance_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fMaxDistance_get(swigCPtr); } 
  }

  public float fVolDryAtMaxDist { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolDryAtMaxDist_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolDryAtMaxDist_get(swigCPtr); } 
  }

  public float fVolAuxGameDefAtMaxDist { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolAuxGameDefAtMaxDist_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolAuxGameDefAtMaxDist_get(swigCPtr); } 
  }

  public float fVolAuxUserDefAtMaxDist { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolAuxUserDefAtMaxDist_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_fVolAuxUserDefAtMaxDist_get(swigCPtr); } 
  }

  public float LPFValueAtMaxDist { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_LPFValueAtMaxDist_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_LPFValueAtMaxDist_get(swigCPtr); } 
  }

  public float HPFValueAtMaxDist { set { AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_HPFValueAtMaxDist_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkPositioningInfo_HPFValueAtMaxDist_get(swigCPtr); } 
  }

  public AkPositioningInfo() : this(AkSoundEnginePINVOKE.CSharp_new_AkPositioningInfo(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.