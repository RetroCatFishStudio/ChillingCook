using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenobjectReference
{
	public Transform GetKitchenObjectFollowTransform();
	public void SetKitchenObject(KitchenObjectReference kitchenObjectRef);
	public KitchenObjectReference GetKitchenObject();
	public void ClearKitchenObject();
	public bool HasKitchenObject();
}
