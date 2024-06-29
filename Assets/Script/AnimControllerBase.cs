using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public abstract class AnimControllerBase : MonoBehaviour
{
    protected PLAYER_STATE _currentState;
    public abstract AnimControllerBase ChangeAnim(PLAYER_STATE newState);
}
