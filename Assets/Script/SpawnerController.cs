using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Singleton<SpawnerController>
{
	[SerializeField] GameObject Tomato;

	[SerializeField] GameObject TomatoSlide;

	[SerializeField] GameObject Cheese;

	[SerializeField] GameObject CheeseSlide;

	[SerializeField] GameObject Carbage;

	[SerializeField] GameObject CarbageSlide;

	[SerializeField] GameObject Plate;

	[SerializeField] GameObject RawMeat;

	[SerializeField] GameObject CookMeat;

	[SerializeField] GameObject BurnMeat;

	[SerializeField] GameObject RescipieBox;

	[SerializeField] int ObjNum;
	void Start()
	{
		ObjectPooling.Instance.CreatePool(Tomato, ObjNum);
		ObjectPooling.Instance.CreatePool(TomatoSlide, ObjNum);
		ObjectPooling.Instance.CreatePool(Cheese, ObjNum);
		ObjectPooling.Instance.CreatePool(CheeseSlide, ObjNum);
		ObjectPooling.Instance.CreatePool(Carbage, ObjNum);
		ObjectPooling.Instance.CreatePool(CarbageSlide, ObjNum);
		ObjectPooling.Instance.CreatePool(Plate, ObjNum);
		ObjectPooling.Instance.CreatePool(RawMeat, ObjNum);
		ObjectPooling.Instance.CreatePool(CookMeat, ObjNum);
		ObjectPooling.Instance.CreatePool(BurnMeat, ObjNum);
		ObjectPooling.Instance.CreatePool(RescipieBox, ObjNum);
	}
}
