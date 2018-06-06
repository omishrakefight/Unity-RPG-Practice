using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {
    /*
    Vector3 startPosition;
    Vector3 offset;
    Vector3 cameraStart;
    */
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        /*
        startPosition = player.transform.position;
        cameraStart = gameObject.transform.position;
        */
    }

    private void LateUpdate()
    {
        gameObject.transform.position = player.transform.position;
        /*
        offset = player.transform.position - startPosition;
        gameObject.transform.position = cameraStart + offset;
        */
    }
}
