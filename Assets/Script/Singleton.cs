using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance => instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this.GetComponent<T>();
		}
		else if (Instance.GetInstanceID() != this.GetInstanceID())
		{
			Destroy(this.gameObject);
		}
	}
}
