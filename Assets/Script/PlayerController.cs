using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>, IKitchenobjectReference
{
	public EventHandler<OnSelectedCounterChanged> OnSelectedCounter;
	public class OnSelectedCounterChanged : EventArgs
	{
		public BaseCounter selectedCouter;
	}
	public enum PLAYER_STATE
	{
		Idle = 0,
		Walk = 1,
		Hold = 2
	}
	public PLAYER_STATE _state = PLAYER_STATE.Idle;
	public PLAYER_STATE state => _state;

	[SerializeField] private AnimControllerBase _animcontroller;
	[SerializeField] private float moveSpeed = 7f;
	[SerializeField] private LayerMask counterMask;
	[SerializeField] private Transform holdingPoint;

	KitchenObjectReference kitchenObjectReference;
	private BaseCounter selectedCouter;
	private bool _isMoving = false;

	private void Start()
	{
		_animcontroller = this.GetComponentInChildren<AnimControllerBase>();
	}
	void Update()
	{
		if (GameManager.Instance.IsGamePlaying() == true)
		{
			MovementHandle();
			UpdateState();
			_animcontroller.ChangeAnim(_state);
		}
	}
	void UpdateState()
	{
		if (_isMoving == true)
		{
			_state = PLAYER_STATE.Walk;
		}
		else
		{
			_state = PLAYER_STATE.Idle;
		}
		if (kitchenObjectReference != null)
		{
			_state = PLAYER_STATE.Hold;
		}
	}
	private void HandleInteraction(Vector3 moveDir)
	{
		float interDistance = 2f;
		if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObj, interDistance, counterMask))
		{
			BaseCounter clearCounter = hitObj.transform.GetComponent<BaseCounter>();
			if (clearCounter != selectedCouter)
			{
				SetSelectedCounter(clearCounter);
			}
		}
		else
		{
			SetSelectedCounter(null);
		}
		if (selectedCouter != null && Input.GetKeyDown(KeyCode.E))
		{
			selectedCouter.Interact(this);
		}
		if (selectedCouter != null && Input.GetKeyDown(KeyCode.Space))
		{
			selectedCouter.InteractCutting(this);
		}
	}
	void MovementHandle()
	{
		Vector2 inputVector = new Vector2(0, 0);
		if (Input.GetKey(KeyCode.W))
		{
			inputVector.y = 1;
		}
		if (Input.GetKey(KeyCode.S))
		{
			inputVector.y = -1;

		}
		if (Input.GetKey(KeyCode.D))
		{
			inputVector.x = 1;

		}
		if (Input.GetKey(KeyCode.A))
		{
			inputVector.x = -1;
		}
		float rotateSpeed = 7f;
		inputVector = inputVector.normalized;
		Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
		HandleInteraction(moveDir);
		float moveDistance = moveSpeed * Time.deltaTime;
		float playerRadius = 0.7f;
		float playerHeight = 1.5f;
		bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
		if (!canMove)
		{
			Vector3 moveDirx = new Vector3(moveDir.x, 0, 0).normalized;
			canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirx, moveDistance);
			if (canMove)
			{
				moveDir = moveDirx;
			}
			else
			{
				Vector3 moveDirz = new Vector3(0, 0, moveDir.z).normalized;
				canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirz, moveDistance);
				if (canMove)
				{
					moveDir = moveDirz;
				}
			}

		}
		if (canMove)
		{
			transform.position += moveDir * moveDistance;
		}
		transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
		if (moveDir.x != 0 || moveDir.z != 0)
		{
			_isMoving = true;
		}
		else
		{
			_isMoving = false;
		}
	}
	private void SetSelectedCounter(BaseCounter selectedCounter)
	{
		this.selectedCouter = selectedCounter;
		OnSelectedCounter?.Invoke(this, new OnSelectedCounterChanged
		{
			selectedCouter = this.selectedCouter
		});
	}

	public Transform GetKitchenObjectFollowTransform()
	{
		return holdingPoint;
	}

	public void SetKitchenObject(KitchenObjectReference kitchenObjectRef)
	{
		kitchenObjectReference = kitchenObjectRef;
	}

	public KitchenObjectReference GetKitchenObject()
	{
		return kitchenObjectReference;
	}

	public void ClearKitchenObject()
	{
		kitchenObjectReference = null;
	}

	public bool HasKitchenObject()
	{
		return kitchenObjectReference != null;
	}
}
