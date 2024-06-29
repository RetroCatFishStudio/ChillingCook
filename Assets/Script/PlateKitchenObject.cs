using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateKitchenObject : KitchenObjectReference
{
	public event EventHandler<InGredientAddEventArgs> IngredientAdd;
	public class InGredientAddEventArgs : EventArgs
	{
		public KitchenObjectScriptOb kitchenObject;
	}

	[SerializeField] private List<KitchenObjectScriptOb> validObjects;
	private List<KitchenObjectScriptOb> kitchenObjectList;
	private void Awake()
	{
		kitchenObjectList = new List<KitchenObjectScriptOb>();
	}

	public bool TryAddIngredient(KitchenObjectScriptOb kitchenObject)
	{
		if (validObjects.Contains(kitchenObject))
		{
			foreach (KitchenObjectScriptOb obj in kitchenObjectList)
			{
				if (obj == kitchenObject)
				{
					return false;
				}
			}
			return true;
		}
		else
		{
			return false;
		}
	}
	public void AddIngredient(KitchenObjectScriptOb kitchenObject)
	{
		IngredientAdd?.Invoke(this, new InGredientAddEventArgs
		{
			kitchenObject = kitchenObject
		});
		kitchenObjectList.Add(kitchenObject);
	}
	public List<KitchenObjectScriptOb> GetKitchenObScriptList()
	{
		return kitchenObjectList;
	}
	public void ClearKitchenobjListAndVisual()
	{
		kitchenObjectList.Clear();
		GetComponentInChildren<FullIngredientVisual>().ClearVisual();
	}
}
