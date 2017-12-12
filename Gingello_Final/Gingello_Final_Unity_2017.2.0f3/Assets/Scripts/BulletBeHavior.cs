using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletBeHavior : MonoBehaviour {
    public float BulletForce, BulletHealth;
    Rigidbody rb, ColRB;
    AudioSource RubbAudio;
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
           RubbAudio = col.gameObject.GetComponent<AudioSource>();
           RubbAudio.Play();
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
            RubbAudio.Play();
            RubbAudio = col.gameObject.GetComponent<AudioSource>();
            if (col.gameObject.GetComponent<WallBehavior>().IsHitBull == false)
            {
                col.gameObject.GetComponent<WallBehavior>().IsHitBull = true;
            }      
        }
    }
}


