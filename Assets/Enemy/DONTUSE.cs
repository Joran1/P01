using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONTUSE : MonoBehaviour
{
    public Transform shooter;
    public Transform bulletPrefab;
    public float speed = 2f;
    Vector3 direct = -Vector3.forward;
    Vector3 orgPos;

    void Start()
    {
        StartCoroutine(StartBulletPattern());
        InvokeRepeating("ChangeDirect", 0f, 2f);
        orgPos = transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position + direct * speed * Time.deltaTime;
        pos = orgPos + Vector3.ClampMagnitude(pos - orgPos, 4f);
        transform.position = pos;
    }

    void ChangeDirect()
    {
        direct = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * Vector3.forward;
    }

    IEnumerator StartBulletPattern()
    {
        StartCoroutine(Blast(shooter, bulletPrefab, 20, 1, 120, 0.1f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Blast(shooter, bulletPrefab, 20, 1, 120, 0.1f));
        yield return new WaitForSeconds(6f);
        StartCoroutine(Spiral(shooter, bulletPrefab, 20, 2, 0.1f, true));
        StartCoroutine(Burst(shooter, bulletPrefab, 20, 5, 1.0f));
        yield return new WaitForSeconds(6f);
        StartCoroutine(Burst(shooter, bulletPrefab, 20, 3, 1.0f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Burst(shooter, bulletPrefab, 20, 3, 1.0f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(Burst(shooter, bulletPrefab, 20, 3, 1.0f));
        StartCoroutine(Flower(shooter, bulletPrefab, 5, 6, 5, 0.1f));
        yield return new WaitForSeconds(8f);
        StartCoroutine(StartBulletPattern());
    }

    IEnumerator Blast(Transform shooter, Transform bulletTrans, int shotNum, int volly, float spread, float shotTime)
    {
        float bulletRot = shooter.eulerAngles.y;
        if (shotNum <= 1)
        {
            Instantiate(bulletTrans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
        }
        else
        {
            while (volly > 0)
            {
                bulletRot = bulletRot - (spread / 2);
                for (var i = 0; i < shotNum; i++)
                {
                    Instantiate(bulletTrans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
                    bulletRot += spread / (shotNum - 1);
                    if (shotTime > 0)
                    {
                        yield return new WaitForSeconds(shotTime);
                    }
                }
                bulletRot = shooter.eulerAngles.y;
                volly--;
            }
        }
    }

    IEnumerator Spiral(Transform shooter, Transform bulletTrans, int shotNum, int volly, float shotTime, bool clockwise)
    {
        float bulletRot = shooter.eulerAngles.y;
        while (volly > 0)
        {
            for (var i = 0; i < shotNum; i++)
            {
                Instantiate(bulletTrans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
                if (clockwise)
                {
                    bulletRot += 360.0f / shotNum;
                }
                else
                {
                    bulletRot -= 360.0f / shotNum;
                }
                if (shotTime > 0)
                {
                    yield return new WaitForSeconds(shotTime);
                }
            }
            volly--;
        }
    }

    IEnumerator Burst(Transform shooter, Transform bulletTans, int shotNum, int volly, float vollyTime)
    {
        float bulletRot = 0.0f;
        while (volly > 0)
        {
            for (var i = 0; i < shotNum; i++)
            {
                Instantiate(bulletTans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
                bulletRot += 360.0f / shotNum;
            }
            bulletRot = 0.0f;
            volly--;
            yield return new WaitForSeconds(vollyTime);
        }
    }

    IEnumerator Flower(Transform shooter, Transform bulletTrans, float flowerTime, int directions, float rotTime, float waitTime)
    {
        float bulletRot = 0.0f;
        while (flowerTime > 0)
        {
            for (var i = 0; i < directions; i++)
            {
                Instantiate(bulletTrans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
                bulletRot += 360.0f / directions;
            }
            bulletRot += rotTime;
            if (bulletRot > 360)
            {
                bulletRot -= 360;
            }
            else if (bulletRot < 0)
            {
                bulletRot += 360;
            }
            flowerTime -= waitTime;
            yield return new WaitForSeconds(waitTime);
        }
    }
}