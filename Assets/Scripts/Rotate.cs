using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public GameObject obj;

    float angle = 360f;
    float time = 1f;

    Vector3 axis = Vector3.forward;
	
	void Update () {
        obj.GetComponent<Transform>().RotateAround(Vector3.zero, axis, angle * Time.deltaTime / time);
	}
}
