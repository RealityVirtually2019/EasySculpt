using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Select : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {
        Debug.Log("hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData e)
    {
        Debug.Log("cliiiikc");
    }
}
