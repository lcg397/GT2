using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletBeHavior : MonoBehaviour {

    
    public float BulletForce, BulletHealth;
    [SerializeField] Rigidbody rb, ColRB;
	// Use this for initialization
	void Start () {
        rb = this.transform.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(BulletForce * transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
        BulletHealth -= Time.deltaTime; 

        if(BulletHealth <= 0f)
        {

            Destroy(this.gameObject);

        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("ChunkNotHit"))
        {

           ColRB = col.gameObject.GetComponent<Rigidbody>();
           ColRB.isKinematic = false;
            ColRB.AddForce(Vector3.forward * 100f);
            col.gameObject.GetComponent<WallBehavior>().IsRB = true;

            col.gameObject.tag = "Chunk";

        }
    }
   
    }


