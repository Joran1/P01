using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_circle : MonoBehaviour {
    
    public GameObject bulletPrefab;

    public float numberOfShots = 0;
    public float fire_delay = 0.25f;
           float fire_cooldown = 0;

    public float burst_amount;
           float burst;
    public float burst_delay = 0.25f;


    void Start() {
        burst = burst_amount;
    }

    void Update () {

    //SHOOTING/////////////////////////////////////////////////////

        fire_cooldown -= Time.deltaTime;

        if (fire_cooldown <= 0) {
            fire_cooldown = fire_delay;
            StartCoroutine(Burst(burst_amount, burst_delay));
            burst_amount = burst;
        }
    }

    //BURST////////////////////////////////////////////////////////

    IEnumerator Burst(float burst_amount, float burst_delay) {
        while (burst_amount > 0) {
            Vector3 localShotPos = new Vector3(0, -((new Vector2(transform.localScale.x, transform.localScale.y)).magnitude));
            float degree = 360f / numberOfShots;

            for (float i = -180f; i < 180f; i += degree) {
                Quaternion rotation = Quaternion.AngleAxis(i, transform.forward);
                Vector3 shotPosition = transform.position + rotation * localShotPos;
                Instantiate(bulletPrefab, shotPosition, rotation * transform.rotation);
            }
            yield return new WaitForSeconds(burst_delay);
            burst_amount -= 1;
        }
    }
}
