using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 2f;
    public float constraint = 4f;

	void Update () {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

        if (transform.position.x >= constraint || transform.position.x <= -constraint) {
            speed *= -1;
        }
    }
}
