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


public class Iterator : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal Iterator(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(Iterator obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  ~Iterator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_Iterator(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public PlaylistItem pItem { set { AkSoundEnginePINVOKE.CSharp_Iterator_pItem_set(swigCPtr, PlaylistItem.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_Iterator_pItem_get(swigCPtr);
      PlaylistItem ret = (cPtr == global::System.IntPtr.Zero) ? null : new PlaylistItem(cPtr, false);
      return ret;
    } 
  }

  public Iterator NextIter() {
    Iterator ret = new Iterator(AkSoundEnginePINVOKE.CSharp_Iterator_NextIter(swigCPtr), false);
    return ret;
  }

  public Iterator PrevIter() {
    Iterator ret = new Iterator(AkSoundEnginePINVOKE.CSharp_Iterator_PrevIter(swigCPtr), false);
    return ret;
  }

  public PlaylistItem GetItem() {
    PlaylistItem ret = new PlaylistItem(AkSoundEnginePINVOKE.CSharp_Iterator_GetItem(swigCPtr), false);
    return ret;
  }

  public bool IsEqualTo(Iterator in_rOp) { return AkSoundEnginePINVOKE.CSharp_Iterator_IsEqualTo(swigCPtr, Iterator.getCPtr(in_rOp)); }

  public bool IsDifferentFrom(Iterator in_rOp) { return AkSoundEnginePINVOKE.CSharp_Iterator_IsDifferentFrom(swigCPtr, Iterator.getCPtr(in_rOp)); }

  public Iterator() : this(AkSoundEnginePINVOKE.CSharp_new_Iterator(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.