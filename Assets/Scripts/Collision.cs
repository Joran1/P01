using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public int health = 1;
    float invlunerable_timer = 0;
    float flash_timer = 0;

    int layer;

    public Sprite flash;
    public Sprite regular;

    private void Start() {
        layer = gameObject.layer;
    }

    void OnTriggerEnter2D() {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = flash;
        
        health--;
        flash_timer = 0.1f;

        if ( this.gameObject.GetComponent<Player>()) {
            invlunerable_timer = 1f;
            flash_timer = 1f;
        }

        gameObject.layer = 10;
    }

    private void Update() {
        invlunerable_timer -= Time.deltaTime;
        if (invlunerable_timer <= 0) { gameObject.layer = layer; }

        flash_timer -= Time.deltaTime;
        if ( flash_timer <= 0 ) { this.gameObject.GetComponent<SpriteRenderer>().sprite = regular; }

        if ( health <= 0 ) { Destroy(gameObject); }
    }

}
