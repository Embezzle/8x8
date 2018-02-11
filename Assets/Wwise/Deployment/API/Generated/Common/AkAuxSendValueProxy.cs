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


public class AkAuxSendValueProxy : AkAuxSendValue {
  private global::System.IntPtr swigCPtr;

  internal AkAuxSendValueProxy(global::System.IntPtr cPtr, bool cMemoryOwn) : base(AkSoundEnginePINVOKE.CSharp_AkAuxSendValueProxy_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkAuxSendValueProxy obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~AkAuxSendValueProxy() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkAuxSendValueProxy(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public void Set(UnityEngine.GameObject listener, uint id, float value) {

	var listener_id = AkSoundEngine.GetAkGameObjectID(listener);
	AkSoundEngine.PreGameObjectAPICall(listener, listener_id);

    { AkSoundEnginePINVOKE.CSharp_AkAuxSendValueProxy_Set(swigCPtr, listener_id, id, value); }
  }

  public bool IsSame(UnityEngine.GameObject listener, uint id) {

	var listener_id = AkSoundEngine.GetAkGameObjectID(listener);
	AkSoundEngine.PreGameObjectAPICall(listener, listener_id);

    { return AkSoundEnginePINVOKE.CSharp_AkAuxSendValueProxy_IsSame(swigCPtr, listener_id, id); }
  }

  public static int GetSizeOf() { return AkSoundEnginePINVOKE.CSharp_AkAuxSendValueProxy_GetSizeOf(); }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.