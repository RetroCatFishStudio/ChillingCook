using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeliveryManager : Singleton<DeliveryManager>
{
	[SerializeField] private List<RecipieScriptOb> recipieScriptObList;
	private List<RecipieScriptOb> waitingRecipeScriptsObList;
	private float spawnRecipeTimer;
	private float spawnRecipeTimerRate = 15f;
	public int point = 0;

	private void Start()
	{
		waitingRecipeScriptsObList = new List<RecipieScriptOb>();
		spawnRecipeTimer = spawnRecipeTimerRate;
	}

	private void Update()
	{
		spawnRecipeTimer -= Time.deltaTime;
		if (spawnRecipeTimer <= 0 && GameManager.Instance.IsGamePlaying())
		{
			spawnRecipeTimer = spawnRecipeTimerRate;
			int num = UnityEngine.Random.Range(0, recipieScriptObList.Count);
			RecipieScriptOb waitingRecipe = recipieScriptObList[num];
			Debug.Log(waitingRecipe.recipieName);
			waitingRecipeScriptsObList.Add(waitingRecipe);
			Observer.Instance.Notify("RecipeSpawn");
		}
	}

	public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
	{
		for (int i = 0; i < waitingRecipeScriptsObList.Count; i++)
		{
			RecipieScriptOb waitRecipe = waitingRecipeScriptsObList[i];
			if (waitRecipe.kitchenObjectList.Count == plateKitchenObject.GetKitchenObScriptList().Count)
			{
				bool plateMatch = true;
				foreach (KitchenObjectScriptOb go in waitRecipe.kitchenObjectList)
				{
					bool ingredientFound = false;
					foreach (KitchenObjectScriptOb go1 in plateKitchenObject.GetKitchenObScriptList())
					{
						if (go1 == go)
						{
							ingredientFound = true;
							break;
						}
					}
					if (!ingredientFound)
					{
						plateMatch = false;
						break;
					}
				}
				if (plateMatch)
				{
					AudioManager.Instance.PlayeSFX("Right");
					point++;
					GameManager.Instance.gamePlayTimer += 15f;
					waitingRecipeScriptsObList.RemoveAt(i);
					Observer.Instance.Notify("RecipeComplete");
					return;
				}
			}
		}
		AudioManager.Instance.PlayeSFX("Wrong");
	}

	public List<RecipieScriptOb> GetWaitingRecipeList()
	{
		return waitingRecipeScriptsObList;
	}

	public int GetPoint()
	{
		return point;
	}
}
