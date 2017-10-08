using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject bulletPrefab;

    public float speed = 10f;
    public float fire_delay = 0.25f;
           float fire_cooldown = 0;

    void Start() {

    }

    void Update() {

        //MOVEMENT/////////////////////////////////////////////////////

        Vector3 pos = transform.position;

        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;

        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position = pos;

        //RESTRICT/////////////////////////////////////////////////////

        float screen = (float)Screen.width / (float)Screen.height;

        float height = Camera.main.orthographicSize;
        float width = Camera.main.orthographicSize * screen;

        //TOP
        if (pos.y > height) { pos.y = height; }
        //BOTTOM
        if (pos.y < -height) { pos.y = -height; }
        //LEFT
        if (pos.x > width) { pos.x = width; }
        //RIGHT
        if (pos.x < -width) { pos.x = -width; }

        transform.position = pos;

        //SHOOTING/////////////////////////////////////////////////////

        fire_cooldown -= Time.deltaTime;
        
        if ( Input.GetButton("Fire1") && fire_cooldown <= 0 ) {
            fire_cooldown = fire_delay;

            Vector3 offset = new Vector3(0, 0.6f, 0);
            Instantiate(bulletPrefab, pos + offset, transform.rotation);
        }

    }

}        


