using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityMeshSimplifier;

public class Model : MonoBehaviour {

	private Mesh mesh;
	private MeshSimplifier meshSimplifier;
	private KeywordRecognizer keywordRecognizer;
	private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	private float meshQuality = 0.5f;
	private const float meshStep = 0.2f;
	private const float meshMin = 0.5f;
	private bool isDown;
	
	void Start ()
	{
		mesh = gameObject.GetComponent<MeshFilter>().mesh;
		meshSimplifier = new MeshSimplifier();
		meshSimplifier.Initialize(mesh);
		
		//keywords
		keywords.Add("less detail", () =>
		{
			meshQuality -= meshStep;
			meshQuality = Math.Min(meshQuality, meshMin);
		});
		keywords.Add("more detail", () =>
		{
			meshQuality += meshStep;
			meshQuality = Math.Max(meshQuality, 1f);
		});
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
		}
		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
		{
			isDown = false;
		}
	}

	private void moreDetail()
	{
			meshQuality += meshStep;
			meshQuality = Math.Max(meshQuality, 1f);
			updateMesh();
	}
	private void lessDetail()
	{
			meshQuality -= meshStep;
			meshQuality = Math.Min(meshQuality, meshMin);
			updateMesh();
	}
	public void updateMesh()
	{
		meshSimplifier.SimplifyMesh(meshQuality);
		gameObject.GetComponent<MeshFilter>().mesh = meshSimplifier.ToMesh();
	}
}
