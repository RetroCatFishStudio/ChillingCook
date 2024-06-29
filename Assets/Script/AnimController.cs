using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER_STATE = PlayerController.PLAYER_STATE;

public class AnimController : AnimControllerBase
{
	PLAYER_STATE _currentState = PLAYER_STATE.Idle;
	Animator _animator;
	void Start()
	{
		_animator = GetComponent<Animator>();
	}
	public override AnimControllerBase ChangeAnim(PLAYER_STATE newState)
	{
		_currentState = newState;
		_animator.SetTrigger(newState.ToString());
		return this;
	}
   
}
