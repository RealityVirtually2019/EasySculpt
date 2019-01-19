using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSimple : MonoBehaviour {
	// Use this for initialization
	int meshNum = 65;
	Mesh[] ms = new Mesh[65];
	int counter = 0;
	bool firstRun = true;
	bool increase = true;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log (counter);
		if (counter < meshNum-1 && firstRun) {
			float quality = 0.95f;
			var meshSimplifier = new UnityMeshSimplifier.MeshSimplifier ();
			meshSimplifier.Initialize (GetComponent<MeshFilter> ().mesh);
			meshSimplifier.SimplifyMesh (quality);
			var destMesh = meshSimplifier.ToMesh ();
			GetComponent<MeshFilter> ().mesh = destMesh;
			ms [counter] = destMesh;
			counter++;
		} else if (counter == meshNum -1 && firstRun) {
			firstRun = false;
			increase = false;
			float quality = 0.95f;
			var meshSimplifier = new UnityMeshSimplifier.MeshSimplifier ();
			meshSimplifier.Initialize (GetComponent<MeshFilter> ().mesh);
			meshSimplifier.SimplifyMesh (quality);
			var destMesh = meshSimplifier.ToMesh ();
			GetComponent<MeshFilter> ().mesh = destMesh;
			ms [counter] = destMesh;
			counter--;
		} else if(!firstRun){
			GetComponent<MeshFilter> ().mesh = ms [counter];
			if (increase) {
				if (counter == meshNum-1) {
					increase = false;
					counter--;
				} else {
					counter++;
				}
			} else {
				if (counter == 0) {
					increase = true;
					counter++;
				} else {
					counter--;
				}
			}
		}


	}
}
