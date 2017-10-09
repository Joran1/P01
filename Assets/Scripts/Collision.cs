using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

    public Slider healthbar;
    public int health = 1;
           int layer;

    public Sprite Shield;
    public Sprite Standard;

    float invlunerable_timer = 0;

    private void Start() {
        layer = gameObject.layer;
        healthbar.value = health;
    }

    void OnTriggerEnter2D()
    {
        health--;
        healthbar.value = health;
        gameObject.layer = 10;
        invlunerable_timer = 0.1f;
        if (this.gameObject.GetComponent<Player>()) { invlunerable_timer = 1f; }
    }

    private void Update() {
        invlunerable_timer -= Time.deltaTime;
        if (invlunerable_timer >= 0) { this.gameObject.GetComponent<SpriteRenderer>().sprite = Shield; }
        if (invlunerable_timer <= 0) { gameObject.layer = layer; this.gameObject.GetComponent<SpriteRenderer>().sprite = Standard; }
        if (health <= 0) { Destroy(gameObject); }
    }
}
