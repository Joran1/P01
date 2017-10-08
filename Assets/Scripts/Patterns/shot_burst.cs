using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_burst : MonoBehaviour {

    public GameObject bulletPrefab;

    public float fire_delay = 0.25f;
           float fire_cooldown = 0;

    public float burst_amount;
           float burst;
    public float burst_delay = 0.25f;


    void Start() {
        burst = burst_amount;
    }

    void Update() {

    //SHOOTING/////////////////////////////////////////////////////

        fire_cooldown -= Time.deltaTime;

        if ( fire_cooldown <= 0) {
            fire_cooldown = fire_delay;

            StartCoroutine(Burst(burst_amount, burst_delay));
            burst_amount = burst;
        }
    }

    //BURST////////////////////////////////////////////////////////

    IEnumerator Burst(float burst_amount, float burst_delay) {
        while (burst_amount > 0) {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(burst_delay);
            burst_amount -= 1;
        }
    }
}


