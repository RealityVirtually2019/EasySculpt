using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Events;

public class UIButton : MonoBehaviour, IInputClickHandler
{
	public UnityEvent onClick;
	public ModelManager manager;
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
        onClick.Invoke();
	}

	public void moreDetail()
	{
		manager.getModel().moreDetail();
	}

	public void lessDetail()
	{
		manager.getModel().lessDetail();
	}

	public void objectMode()
	{
		manager.getModel().outlineMode();
	}

	public void solidMode()
	{
		manager.getModel().solidMode();
	}

}
