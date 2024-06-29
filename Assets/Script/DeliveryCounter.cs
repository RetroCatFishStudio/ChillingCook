using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
	[SerializeField] private Transform counterTopPoint;
	private KitchenObjectReference kitchenObjectReference;
	public override void Interact(PlayerController player)
	{
		if (player.HasKitchenObject())
		{
			if (player.GetKitchenObject() is PlateKitchenObject)
			{
				DeliveryManager.Instance.DeliverRecipe(player.GetKitchenObject() as PlateKitchenObject);
				player.GetKitchenObject().Cutted2(player.GetKitchenObject() as PlateKitchenObject);
			}
		}
	}
}
