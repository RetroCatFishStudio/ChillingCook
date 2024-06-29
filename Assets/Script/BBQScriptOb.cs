using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class BBQScriptOb : ScriptableObject
{
	public KitchenObjectScriptOb input;
	public KitchenObjectScriptOb output;
	public float fryingTimerMax;
}
