using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearCounter : BaseCounter, IKitchenobjectReference
{
	[SerializeField] private Transform counterTopPoint;
	private KitchenObjectReference kitchenObjectReference;
	public override void Interact(PlayerController player)
	{
		if (HasKitchenObject() == false)
		{
			if (player.HasKitchenObject())
			{
				player.GetKitchenObject().SetkitchenObjectBelong(this);
			}
			else
			{
			}
		}
		else
		{
			if (player.HasKitchenObject())
			{
				if (player.GetKitchenObject() is PlateKitchenObject)
				{
					PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
					if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectScriptOb()) == true)
					{
						plateKitchenObject.AddIngredient(GetKitchenObject().GetKitchenObjectScriptOb());
						GetKitchenObject().Cutted();

					}
					else
					{
					}
				}
				else
				{
					if (GetKitchenObject() is PlateKitchenObject)
					{
						PlateKitchenObject plateKitchenObject = GetKitchenObject() as PlateKitchenObject;
						if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectScriptOb()) == true)
						{
							plateKitchenObject.AddIngredient(player.GetKitchenObject().GetKitchenObjectScriptOb());
							player.GetKitchenObject().Cutted();
						}
						else
						{
						}
					}
				}
			}
			else
			{
				this.GetKitchenObject().SetkitchenObjectBelong(player);
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

