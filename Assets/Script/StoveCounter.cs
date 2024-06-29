using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounter : BaseCounter, IKitchenobjectReference
{

	[SerializeField] private BBQScriptOb[] bBQScriptObs;
	[SerializeField] private Transform counterTopPoint;
	[SerializeField] private bool IsPlayingSfx = false;
	private KitchenObjectReference kitchenObjectReference;
	private float cookingProgress;
	private float burningProgress;
	private State state;
	private enum State
	{
		Idle = 0,
		Frying = 1,
		fried = 2,
		Burned = 3
	}
	public override void Interact(PlayerController player)
	{
		if (HasKitchenObject() == false)
		{
			if (player.HasKitchenObject())
			{
				if (CheckRight(player.GetKitchenObject().GetKitchenObjectScriptOb()) == true)
				{
					player.GetKitchenObject().SetkitchenObjectBelong(this);
					cookingProgress = 0;
					state = State.Frying;
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
				state = State.Idle;
			}
		}
	}
	private void Start()
	{
		state = State.Idle;
	}
	private void Update()
	{
		if (HasKitchenObject() == true)
		{
			if (IsPlayingSfx == false)
			{
				AudioManager.Instance.PlaySfxMusic("BBQ");
				IsPlayingSfx = true;
			}
			switch (state)
			{
				case State.Idle:
					break;
				case State.Frying:
					cookingProgress += Time.deltaTime;

					BBQScriptOb cookingRecipie = GetBBQScriptOb(GetKitchenObject().GetKitchenObjectScriptOb());
					if (cookingProgress >= cookingRecipie.fryingTimerMax)
					{
						KitchenObjectScriptOb outPut = GetCorrectKitchenObForCooking(GetKitchenObject().GetKitchenObjectScriptOb());
						GetKitchenObject().Cutted();
						Transform kitchenObjectTran = ObjectPooling.Instance.getObj(outPut.prefab.gameObject).transform;
						kitchenObjectTran.gameObject.SetActive(true);
						kitchenObjectTran.localPosition = Vector3.zero;
						kitchenObjectReference = kitchenObjectTran.GetComponent<KitchenObjectReference>();
						kitchenObjectReference.SetkitchenObjectBelong(this);
						state = state + 1;
					}
					burningProgress = 0;
					break;
				case State.fried:
					if (cookingProgress <= 5)
					{
						break;
					}
					burningProgress += Time.deltaTime;

					cookingRecipie = GetBBQScriptOb(GetKitchenObject().GetKitchenObjectScriptOb());
					if (burningProgress >= cookingRecipie.fryingTimerMax)
					{
						KitchenObjectScriptOb outPut = GetCorrectKitchenObForCooking(GetKitchenObject().GetKitchenObjectScriptOb());
						GetKitchenObject().Cutted();
						Transform kitchenObjectTran = ObjectPooling.Instance.getObj(outPut.prefab.gameObject).transform;
						kitchenObjectTran.gameObject.SetActive(true);
						kitchenObjectTran.localPosition = Vector3.zero;
						kitchenObjectReference = kitchenObjectTran.GetComponent<KitchenObjectReference>();
						kitchenObjectReference.SetkitchenObjectBelong(this);
						state = state + 1;
					}
					break;
				case State.Burned:
					break;

			}
		}
		else
		{
			if (IsPlayingSfx == true)
			{
				AudioManager.Instance.StopSfxMusic("BBQ");
				IsPlayingSfx = false;
			}
		}
	}
	public override void CookingProgressHandle(float Timer)
	{

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
	private bool CheckRight(KitchenObjectScriptOb kitchenObject)
	{
		foreach (BBQScriptOb go in bBQScriptObs)
		{
			if (go.input == kitchenObject)
			{
				return true;
			}
		}
		return false;
	}
	private BBQScriptOb GetBBQScriptOb(KitchenObjectScriptOb kitchenObject)
	{
		foreach (BBQScriptOb go in bBQScriptObs)
		{
			if (go.input == kitchenObject)
			{
				return go;
			}
		}
		return null;
	}
	private KitchenObjectScriptOb GetCorrectKitchenObForCooking(KitchenObjectScriptOb kitchenObject)
	{
		foreach (BBQScriptOb go in bBQScriptObs)
		{
			if (go.input == kitchenObject)
			{
				return go.output;
			}
		}
		return null;
	}
}
