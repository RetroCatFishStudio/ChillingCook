using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour
{
	public virtual void Interact(PlayerController player) { }
	public virtual void InteractCutting(PlayerController player) { }
	public virtual void CookingProgressHandle(float timer) { }
}
