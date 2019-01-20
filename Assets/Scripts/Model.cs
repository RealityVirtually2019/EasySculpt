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
	private int meshNum = 8;

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
	}

	public void moreDetail()
	{
		Debug.Log("more");
		meshNum++;
		meshNum = Math.Min(meshNum, ms.Length-1);
		gameObject.GetComponent<MeshFilter>().mesh = ms[meshNum];
	}
	public void lessDetail()
	{
		Debug.Log("less");
		meshNum--;
		meshNum = Math.Max(meshNum, 0);
		gameObject.GetComponent<MeshFilter>().mesh = ms[meshNum];
	}

	public void outlineMode()
	{
		Material[] mats = gameObject.GetComponent<Renderer>().materials;
        for (int i=0; i<mats.Length; i++)
		{
			mats[i] = outlineMat;
		}
        gameObject.GetComponent<Renderer>().materials = mats;
	}

	public void solidMode()
	{
		Material[] mats = gameObject.GetComponent<Renderer>().materials;
		Debug.Log(mats.Length);
        for (int i=0; i<mats.Length; i++)
		{
			mats[i] = solidMat;
		}

        gameObject.GetComponent<Renderer>().materials = mats;

	}
}
