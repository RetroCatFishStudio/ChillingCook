using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlateKitchenObject;

public class FullIngredientVisual : MonoBehaviour
{
	[Serializable]
	public struct ScriptObjectAndGameObject
	{
		public KitchenObjectScriptOb kitchenObject;
		public GameObject gameObject;
	}
	[SerializeField] private PlateKitchenObject plateKitchenObject;
	[SerializeField] private List<ScriptObjectAndGameObject> kitchenObjectAndGameObjectList;
	private void Start()
	{
		plateKitchenObject.IngredientAdd += AddToPlate; 
		foreach (ScriptObjectAndGameObject go in kitchenObjectAndGameObjectList)
		{
			go.gameObject.SetActive(false);
		}
	}
	private void AddToPlate(object sender, PlateKitchenObject.InGredientAddEventArgs e)
	{
		foreach (ScriptObjectAndGameObject go in kitchenObjectAndGameObjectList)
		{
			if (go.kitchenObject == e.kitchenObject)
			{
				go.gameObject.SetActive(true);
			}
		}
	}
public void ClearVisual()
	{
		foreach (ScriptObjectAndGameObject go in kitchenObjectAndGameObjectList)
		{
			go.gameObject.SetActive(false);
		}
	}
}
