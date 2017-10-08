using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour {

    public float speed = 5f;
    public float timer = 2f;

    void Start () {

    }

    void Update () {

        //MOVEMENT/////////////////////////////////////////////////////

        Vector3 pos = transform.position;
        Vector3 vel = new Vector3(0, speed * Time.deltaTime , 0);
        pos += transform.rotation * vel;

        transform.position = pos;
        

        //KILL

        timer -= Time.deltaTime;
        if ( timer <= 0 ) { Destroy(gameObject); }
    }

}
