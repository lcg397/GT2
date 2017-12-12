using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticWallBehave : MonoBehaviour {


    MeshRenderer Wall;
    BoxCollider WallCollider;
    public GameObject[] Chunks;
    bool ChunksGo;
 


    private void Start()
    {
        Wall = this.gameObject.GetComponent<MeshRenderer>();
        WallCollider = this.gameObject.GetComponent<BoxCollider>();
        Chunks = GameObject.FindGameObjectsWithTag("ChunkNotHit");
        foreach (GameObject ch in Chunks)
        {
            ch.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider col)
    {if (col.CompareTag("Bullet"))
        {

            Wall.enabled = !enabled;
            WallCollider.enabled = !enabled;
            foreach (GameObject ch in Chunks)
            {
                ch.SetActive(true);
            }


        }
    }




}
