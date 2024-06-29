using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter,IKitchenobjectReference
{
	[SerializeField] private KitchenObjectScriptOb kitchenObject;
	[SerializeField] private Transform counterTopPoint;
	private KitchenObjectReference kitchenObjectReference;
	public override void Interact(PlayerController player)
	{
		if (kitchenObjectReference == null)
		{
			Transform kitchenObjectTran = ObjectPooling.Instance.getObj(kitchenObject.prefab.gameObject).transform;
			kitchenObjectTran.localPosition = Vector3.zero;
			kitchenObjectReference = kitchenObjectTran.GetComponent<KitchenObjectReference>();
			kitchenObjectReference.SetkitchenObjectBelong(this);
			kitchenObjectTran.gameObject.SetActive(true);
		}
		else
		{
			if (!player.HasKitchenObject())
			{
				kitchenObjectReference.SetkitchenObjectBelong(player);
			}
		}
	}
	public void SetKitchenObject(KitchenObjectReference kitchenObjectRef)
	{
		kitchenObjectReference = kitchenObjectRef;
	}
	public void ClearKitchenObject()
	{
		kitchenObjectReference = null;
	}

	public KitchenObjectReference GetKitchenObject()
	{
		return this.kitchenObjectReference;
	}

	public Transform GetKitchenObjectFollowTransform()
	{
		return counterTopPoint;
	}

	public bool HasKitchenObject()
	{
		return kitchenObjectReference != null;
	}
}
