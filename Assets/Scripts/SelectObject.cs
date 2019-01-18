using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SelectObject : MonoBehaviour, IFocusable, IInputClickHandler {
    public void OnFocusEnter()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.green;
        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        this.GetComponent<MeshRenderer>().material.color = Color.green;

        //throw new System.NotImplementedException();
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
