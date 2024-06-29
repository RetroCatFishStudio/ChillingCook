using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class CuttingRecipieScriptOb : ScriptableObject
{
	public KitchenObjectScriptOb input;
	public KitchenObjectScriptOb output;
	public int cuttingProgressMax;
}
