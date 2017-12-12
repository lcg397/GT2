using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAddForce : MonoBehaviour {



    public Camera fpsCam;
    public float range, forwardSTR;
    LayerMask Dest_mask = -8;
    [SerializeField] Rigidbody rb;
    Vector3 ForForce;

    public GameObject FirePoint, Bullet;

	// Use this for initialization
	void Start () {
        ForForce = forwardSTR * transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.F))
        {

           

            GunAddForce();

        }
   
        if(Input.GetButtonDown("Fire1"))
        {

            Debug.Log("MouseClick");

    
            FireBullet();
        }
	}



    public void GunAddForce()
    {
        RaycastHit Hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out Hit, range, Dest_mask.value))
        {

            Debug.Log(Hit.transform.gameObject.name.ToString());
            rb = Hit.transform.gameObject.GetComponent<Rigidbody>();

            rb.isKinematic = false;
            rb.AddRelativeForce(ForForce);
            


        }



    }

 


    public void FireBullet()
    {

        Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);


    }
}
