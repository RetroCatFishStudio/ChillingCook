using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
	Dictionary<GameObject, List<GameObject>> _poolObjt = new Dictionary<GameObject, List<GameObject>>();

	public GameObject getObj(GameObject objKey)
	{
		if (!_poolObjt.ContainsKey(objKey))
		{
			_poolObjt.Add(objKey, new List<GameObject>());
		}

		foreach (GameObject g in _poolObjt[objKey])
		{
			if (g.activeSelf)
				continue;
			return g;
		}

		GameObject g2 = Instantiate(objKey);
		g2.SetActive(false);
		_poolObjt[objKey].Add(g2);
		return g2;
	}

	public T getObj<T>(GameObject objKey) where T : Component
	{
		return this.getObj(objKey).GetComponent<T>();

	}

	public void CreatePool(GameObject keyObj, int size)
	{
		if (!_poolObjt.ContainsKey(keyObj))
		{
			_poolObjt.Add(keyObj, new List<GameObject>());
		}
		for (int i = 0; i < size; i++)
		{
			GameObject g2 = Instantiate(keyObj);
			g2.SetActive(false);
			_poolObjt[keyObj].Add(g2);
		}
	}
}
