using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster raycastHit;
	// Use this for initialization
	void Start () {
        raycastHit = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        print(raycastHit.layerHit);
	}
}
