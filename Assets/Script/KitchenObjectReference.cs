using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectReference : MonoBehaviour
{
	[SerializeField] private KitchenObjectScriptOb kitchenObjectScripReference;
	private IKitchenobjectReference kitchenObjectBelong;
	public KitchenObjectScriptOb GetKitchenObjectScriptOb()
	{
		return kitchenObjectScripReference;
	}
	public void SetkitchenObjectBelong(IKitchenobjectReference kitchenObjectBelong)
	{
		if (this.kitchenObjectBelong != null)
		{
			this.kitchenObjectBelong.ClearKitchenObject();
		}
		this.kitchenObjectBelong = kitchenObjectBelong;
		if (kitchenObjectBelong.HasKitchenObject())
		{
		}
		kitchenObjectBelong.SetKitchenObject(this);
		transform.parent = kitchenObjectBelong.GetKitchenObjectFollowTransform();
		transform.localPosition = Vector3.zero;
	}
	public IKitchenobjectReference GetKitchenObjectBelong()
	{
		return kitchenObjectBelong;
	}
	public void Cutted()
	{
		kitchenObjectBelong.ClearKitchenObject();
		this.kitchenObjectBelong = null;
		gameObject.SetActive(false);
		gameObject.transform.SetParent(null);
	}
	public void Cutted2(PlateKitchenObject obj)
	{
		obj.ClearKitchenobjListAndVisual();
		kitchenObjectBelong.ClearKitchenObject();
		this.kitchenObjectBelong = null;
		gameObject.SetActive(false);
		gameObject.transform.SetParent(null);
	}
}
