using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletBeHavior : MonoBehaviour {
    public float BulletForce, BulletHealth;
    Rigidbody rb, ColRB;
	void Start () {
        rb = this.transform.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(BulletForce * transform.forward);
	}
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
            if (col.gameObject.GetComponent<WallBehavior>().IsRB == false)
            {
                col.gameObject.GetComponent<WallBehavior>().IsRB = true;
            }
            if (col.gameObject.GetComponent<WallBehavior>().IsHitBull == false)
            {
                col.gameObject.GetComponent<WallBehavior>().IsHitBull = true;
            }         
            col.gameObject.tag = "Chunk";
        }
        if (col.CompareTag("Chunk"))
        {
            if (col.gameObject.GetComponent<WallBehavior>().IsHitBull == false)
            {
                col.gameObject.GetComponent<WallBehavior>().IsHitBull = true;
            }      
        }
    }
}


