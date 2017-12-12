using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{



    public GameObject FirePoint, Bullet;

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }
    




    public void FireBullet()
    {

        Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);


    }
}
