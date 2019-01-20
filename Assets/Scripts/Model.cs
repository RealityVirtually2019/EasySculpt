using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Model : MonoBehaviour {

	private KeywordRecognizer keywordRecognizer;
	private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	
	public Mesh[] ms = new Mesh[8];
	public int meshNum = 8;

	public Material outlineMat;
	public Material solidMat;
	private bool isDown;
	
	void Start ()
	{
		//keywords
		keywords.Add("fewer detail", () => { lessDetail(); });
		keywords.Add("outline mode", () => { outlineMode(); });
		keywords.Add("solid mode", () => { solidMode(); });
		keywords.Add("more detail", () => { moreDetail(); });
		
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();

		solidMat = gameObject.GetComponent<Renderer>().material;
	}
	
	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		// if the keyword recognized is in our dictionary, call that Action.
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}	
	
	// Update is called once per frame
	void Update ()
	{
		if (!isDown)
		{
			
		if (Input.GetMouseButton(0))
		{
			isDown = true;
			moreDetail();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			isDown = true;
			lessDetail();
		}
		}
		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(3))
		{
			isDown = false;
		}
	}

	private void moreDetail()
	{
		Debug.Log("more");
		meshNum++;
		meshNum = Math.Min(meshNum, ms.Length-1);
		gameObject.GetComponent<MeshFilter>().mesh = ms[meshNum];
	}
	private void lessDetail()
	{
		Debug.Log("less");
		meshNum--;
		meshNum = Math.Max(meshNum, 0);
		gameObject.GetComponent<MeshFilter>().mesh = ms[meshNum];
	}

	private void outlineMode()
	{
		gameObject.GetComponent<Renderer>().material = outlineMat;
	}

	private void solidMode()
	{
		gameObject.GetComponent<Renderer>().material = solidMat;
	}
}
