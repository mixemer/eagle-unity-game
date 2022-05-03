using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject firePos;
    public GameObject projectile;

    float fireElapsedTime = 0;
    float fireDelay = 0.1f;

    private void Start()
    {
        fireDelay += Globals.instance.level * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            GameObject clone = Instantiate(projectile, firePos.transform.position, projectile.transform.rotation) as GameObject;
        }

        fireElapsedTime += Time.deltaTime;
    }
}
