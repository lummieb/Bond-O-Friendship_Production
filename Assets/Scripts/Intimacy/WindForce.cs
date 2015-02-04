﻿using UnityEngine;
using System.Collections;

public class WindForce : MonoBehaviour {
	
	public float windStrength;
	private ConstantForce windForce;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider col) {
		if(col.GetComponent<ConstantForce>() == null)
		{
			windForce = col.gameObject.AddComponent<ConstantForce>();
			windForce.force = new Vector3(-windStrength, 0, 0);
		}
	}
	void OnTriggerExit (Collider col) {
		if(col.GetComponent<ConstantForce>() != null)
			Destroy(col.GetComponent<ConstantForce>());
	}
}
