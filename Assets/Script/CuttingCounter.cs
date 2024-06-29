using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IKitchenobjectReference
{
	[SerializeField] private CuttingRecipieScriptOb[] cuttingScriptObArray;
	[SerializeField] private Transform counterTopPoint;
	[SerializeField] Animator _animator;
	private KitchenObjectReference KitchenObjectReference;
	private int cuttingProgress;
	public override void Interact(PlayerController player)
	{
		if (HasKitchenObject() == false)
		{
			if (player.HasKitchenObject())
			{
				if (CheckRight(player.GetKitchenObject().GetKitchenObjectScriptOb()) == true)
				{
					player.GetKitchenObject().SetkitchenObjectBelong(this);
					cuttingProgress = 0;
				}
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
			}
			else
			{
				this.GetKitchenObject().SetkitchenObjectBelong(player);
			}
		}
	}
	private KitchenObjectScriptOb GetCorrectKitchenObForCutting(KitchenObjectScriptOb kitchenObject)
	{
		foreach (CuttingRecipieScriptOb go in cuttingScriptObArray)
		{
			if (go.input == kitchenObject)
			{
				return go.output;
			}
		}
		return null;
	}
	public override void InteractCutting(PlayerController player)
	{
		if (HasKitchenObject() == true)
		{
			if (CheckRight(this.KitchenObjectReference.GetKitchenObjectScriptOb()) == true)
			{
				AudioManager.Instance.PlayeSFX("Cutting");
				cuttingProgress += 1;

				CuttingRecipieScriptOb cuttingRecipie = GetCuttingRecipiScriptOb(GetKitchenObject().GetKitchenObjectScriptOb());
				_animator.SetTrigger("Cut");

				if (cuttingProgress >= cuttingRecipie.cuttingProgressMax)
				{
					KitchenObjectScriptOb outPut = GetCorrectKitchenObForCutting(GetKitchenObject().GetKitchenObjectScriptOb());
					GetKitchenObject().Cutted();
					Transform kitchenObjectTran = ObjectPooling.Instance.getObj(outPut.prefab.gameObject).transform;
					kitchenObjectTran.gameObject.SetActive(true);
					kitchenObjectTran.localPosition = Vector3.zero;
					KitchenObjectReference = kitchenObjectTran.GetComponent<KitchenObjectReference>();
					KitchenObjectReference.SetkitchenObjectBelong(this);
				}
			}
		}
	}
	private bool CheckRight(KitchenObjectScriptOb kitchenObject)
	{
		foreach (CuttingRecipieScriptOb go in cuttingScriptObArray)
		{
			if (go.input == kitchenObject)
			{
				return true;
			}
		}
		return false;
	}
	public void SetKitchenObject(KitchenObjectReference kitchenObjectRef)
	{
		KitchenObjectReference = kitchenObjectRef;
	}
	public void ClearKitchenObject()
	{
		KitchenObjectReference = null;
	}

	public KitchenObjectReference GetKitchenObject()
	{
		return this.KitchenObjectReference;
	}

	public Transform GetKitchenObjectFollowTransform()
	{
		return counterTopPoint;
	}

	public bool HasKitchenObject()
	{
		return KitchenObjectReference != null;
	}
	private CuttingRecipieScriptOb GetCuttingRecipiScriptOb(KitchenObjectScriptOb kitchenObject)
	{
		foreach (CuttingRecipieScriptOb go in cuttingScriptObArray)
		{
			if (go.input == kitchenObject)
			{
				return go;
			}
		}
		return null;
	}
}
