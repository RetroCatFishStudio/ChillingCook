using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeliveryUIManager : MonoBehaviour
{
	[SerializeField] private Transform container;
	[SerializeField] private Transform recipeBox;

	private void Awake()
	{
		recipeBox.gameObject.SetActive(false);
	}

	private void Start()
	{
		Observer.Instance.AddListener("RecipeSpawn", OnRecipeSpawn);
		Observer.Instance.AddListener("RecipeComplete", OnRecipeComplete);
		UpdateVisual();
	}

	private void OnDestroy()
	{
		Observer.Instance.RemoveListener("RecipeSpawn", OnRecipeSpawn);
		Observer.Instance.RemoveListener("RecipeComplete", OnRecipeComplete);
	}

	private void OnRecipeSpawn(object[] args)
	{
		UpdateVisual();
	}

	private void OnRecipeComplete(object[] args)
	{
		UpdateVisual();
	}

	private void UpdateVisual()
	{
		foreach (Transform child in container)
		{
			if (child == recipeBox)
			{
				continue;
			}
			child.gameObject.SetActive(false);
		}
		List<RecipieScriptOb> waitList = DeliveryManager.Instance.GetWaitingRecipeList();
		foreach (RecipieScriptOb go in waitList)
		{
			Transform RecipieBox = ObjectPooling.Instance.getObj(recipeBox.gameObject).transform;
			RecipieBox.gameObject.SetActive(true);
			RecipieBox.gameObject.GetComponentInChildren<Text>().text = go.recipieName;
			RecipieBox.SetParent(container);
		}
	}
}
