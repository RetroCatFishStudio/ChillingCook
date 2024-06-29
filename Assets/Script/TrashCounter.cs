using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
	[SerializeField] private Transform counterTopPoint;
	public override void Interact(PlayerController player)
	{
		if (player.HasKitchenObject())
		{
			if (player.GetKitchenObject() is PlateKitchenObject)
			{
				player.GetKitchenObject().Cutted2(player.GetKitchenObject() as PlateKitchenObject);
			}
			else
			{
				player.GetKitchenObject().Cutted();

			}
		}
	}
}
