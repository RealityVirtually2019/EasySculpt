using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityMeshSimplifier;

public class Model : MonoBehaviour {

	private Mesh origMesh;
	private Mesh[] meshes;
	private MeshSimplifier meshSimplifier;
	private KeywordRecognizer keywordRecognizer;
	private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	public float meshQuality = 0.5f;
	public float meshStep = 0f;
	public float meshMin = 0.001f;
	private bool isDown;
	private int currMesh;
	
	void Start ()
	{
		meshes = new Mesh[5];
		origMesh = gameObject.GetComponent<MeshFilter>().mesh;
		meshSimplifier = new MeshSimplifier();
		generateMeshes();
		updateMesh();

		//keywords
		keywords.Add("less detail", () =>
		{
            lessDetail();
		});
		keywords.Add("more detail", () =>
		{
            moreDetail();
		});
		
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
		if (!isDown)
		{
			
		if (Input.GetMouseButton(0))
		{
			Debug.Log("hi");
			isDown = true;
			moreDetail();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			isDown = true;
			lessDetail();
		}
		else if (Input.GetMouseButtonDown(3))
			updateMesh();
		}
		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(3))
		{
			isDown = false;
		}
	}

	void generateMeshes()
	{
		meshes[4] = origMesh;
		meshSimplifier.Initialize(origMesh);
		meshSimplifier.SimplifyMesh(0.5f);
		meshes[3] = meshSimplifier.ToMesh();
		meshSimplifier.Initialize(origMesh);
		meshSimplifier.SimplifyMesh(0.1f);
		meshes[2] = meshSimplifier.ToMesh();
		meshSimplifier.Initialize(origMesh);
		meshSimplifier.SimplifyMesh(0.001f);
		meshes[1] = meshSimplifier.ToMesh();
		meshSimplifier.Initialize(origMesh);
		meshSimplifier.SimplifyMesh(0.00001f);
		meshes[0] = meshSimplifier.ToMesh();
	}
	private void moreDetail()
	{
		currMesh++;
		currMesh = Math.Min(4, currMesh);
		updateMesh();
	}
	private void lessDetail()
	{
		currMesh--;
		currMesh = Math.Max(0, currMesh);
		updateMesh();
	}
	public void updateMesh()
	{
		Debug.Log("change mesh");
		gameObject.GetComponent<MeshFilter>().mesh = meshes[currMesh];
	}
}
