using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
public class WallBehavior : MonoBehaviour {
    float RayDis;
    float DistToNext;
    float Gap, MagMax;
    GameObject Rubble;

    public bool IsRB, IsHitBull, IsMoving;
    LayerMask Dest_mask = -8;
    Rigidbody RB;
    Collider MCOL;
    public Vector3 StartPos;
    public ParticleSystem Rubb;
    Mesh RubbRend;
    MeshRenderer Self;
    public int particleNum;
    AudioSource RubbleClick;
    private void Start()
    {
        RubbleClick = this.gameObject.GetComponent<AudioSource>();
        MCOL = this.gameObject.GetComponent<MeshCollider>();
        Self = this.gameObject.GetComponent<MeshRenderer>();
        Rubble = this.gameObject.transform.GetChild(0).gameObject;
        Rubb = Rubble.GetComponent<ParticleSystem>();
        RubbRend = this.gameObject.GetComponent<Mesh>();
        MagMax = 5f;
        RayDis = 10f;
        Gap = 1.2f;
        RB = this.gameObject.GetComponent<Rigidbody>();
        StartPos = this.gameObject.transform.position; 
    
    }
   
    private void Update()
    {
        if (this.gameObject.transform.position != StartPos)
        {
            RB.isKinematic = false;
            IsRB = true;
        }
        if (IsRB == false)
        {
            CheckBelowMe();
        }
        if(IsHitBull == true)
        {   
            StartCoroutine("WaitForRubble", 2f);
        }
        if (RB.velocity.magnitude >= 5f)
        {
            IsMoving = true;
        }
    }
    void CheckBelowMe()
    {
        RaycastHit HitInfo;
        if (Physics.Raycast(this.gameObject.transform.localPosition, -Vector3.up, out HitInfo, RayDis, Dest_mask.value))
        {     
                DistToNext = this.gameObject.transform.localPosition.magnitude - HitInfo.transform.gameObject.transform.localPosition.magnitude;
                if (DistToNext >= Gap)
                {
                    RB.isKinematic = false;
                    this.gameObject.tag = "Chunk";
                    IsRB = true;
                }
            }
        }
    private IEnumerator WaitForRubble(float DTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(DTime);
            Self.enabled = false;
            MCOL.enabled = false;
            Rubb.Emit(particleNum);
            StartCoroutine("WaitForDestroy", 12f);
        }
    }
    private IEnumerator WaitForDestroy(float DTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(DTime);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator WaitForDestroyFall(float DTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(DTime);            
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision col)
    {if(col.transform.gameObject.tag == "Floor")
        {
            Debug.Log("HitFloor");
            if (IsMoving == true)
            {
                RubbleClick.Play();
                Self.enabled = false;
                MCOL.enabled = false;
                Rubb.Emit(particleNum);
                StartCoroutine("WaitForDestroyFall", 2f);
            }
        }
        if (col.transform.gameObject.tag == "Chunk" || col.transform.gameObject.tag == "ChunkNotHit")
        {
            if (IsMoving == true)
            {
                RubbleClick.Play();  
            }
        }
    }
}
