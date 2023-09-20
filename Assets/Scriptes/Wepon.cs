using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Cherry cherries;
    [SerializeField] Points scoring; // Reference to the Points script

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (cherries.point > 0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        cherries.point--;

        // Update the points text after shooting
        scoring.UpdatePoints(cherries.point);

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }

}
