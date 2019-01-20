using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{

	public Model[] models = new Model[3];
	private int currModel = 0;

	
	public Model getModel()
	{
		return models[currModel];
	}

}
