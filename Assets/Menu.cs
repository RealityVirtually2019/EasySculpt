using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour, IInputClickHandler {

	static public string model = "none";
	// Use this for initialization
	void Start () {

	}

	public float speed = 3f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		model = gameObject.name;
//		SceneManager.LoadScene("Default", LoadSceneMode.single);
	}
}
