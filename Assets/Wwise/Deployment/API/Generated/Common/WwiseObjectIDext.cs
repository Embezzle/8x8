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


public class WwiseObjectIDext : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal WwiseObjectIDext(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(WwiseObjectIDext obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~WwiseObjectIDext() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_WwiseObjectIDext(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public bool IsEqualTo(WwiseObjectIDext in_rOther) { return AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_IsEqualTo(swigCPtr, WwiseObjectIDext.getCPtr(in_rOther)); }

  public AkNodeType GetNodeType() { return (AkNodeType)AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_GetNodeType(swigCPtr); }

  public uint id { set { AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_id_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_id_get(swigCPtr); } 
  }

  public bool bIsBus { set { AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_bIsBus_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_bIsBus_get(swigCPtr); } 
  }

  public WwiseObjectIDext() : this(AkSoundEnginePINVOKE.CSharp_new_WwiseObjectIDext(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.