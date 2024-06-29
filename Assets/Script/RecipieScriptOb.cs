using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipieScriptOb : ScriptableObject
{
    public List<KitchenObjectScriptOb> kitchenObjectList;
    public string recipieName;
}
