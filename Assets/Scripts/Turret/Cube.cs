using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour        
{
    public GameObject bulletPrefab;
    public float makeBulletMin = 0.5f;
    public float makeBulletMax = 3f;
    public float speed = 5f;

    private Transform target;
    private float makeBullet;
    private float elaspedtime;

    private void Start()
    {
        elaspedtime = 0f;
        makeBullet = Random.Range(makeBulletMin, makeBulletMax);
        target = FindObjectOfType<PlayerControl>().transform;

    }

    void Update()
    {
        elaspedtime += Time.deltaTime;

        transform.Rotate(Vector3.up, speed * Time.deltaTime, 0f);

        if (elaspedtime >= makeBullet)
        {
            elaspedtime = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            makeBullet = Random.Range(makeBulletMin, makeBulletMax);
        }

        
        Vector3 distanceVector = target.position - transform.position;

        Debug.DrawRay(transform.position, distanceVector, Color.blue); 



    }
}
