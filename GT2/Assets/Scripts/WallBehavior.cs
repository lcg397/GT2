using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WallBehavior : MonoBehaviour {
    [SerializeField] float RayDis;
    [SerializeField] float DistToNext;
    [SerializeField] float Gap, MagMax;
    [SerializeField] GameObject Rubble;
    public float TimeRubHit, TimeRubRB;
    public bool IsRB, IsHitBull;
    LayerMask Dest_mask = -8;
    Rigidbody RB;
    public UnityEvent RubbleExplosion;
    ParticleSystem Rubb;
    public Collider[] cols;
    public List<Vector3> locs;
    public Vector3 StartPos;


    private void Start()
    {
        MagMax = 5f;
        RayDis = 10f;
        Gap = 1.2f;
        RB = this.gameObject.GetComponent<Rigidbody>();
        StartPos = this.gameObject.transform.position;
        //Rubb = this.gameObject.GetComponentInChildren<ParticleSystem>();
        //Rubb.shape.mesh.Equals(this.gameObject.GetComponents<MeshFilter>());
       
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
       if (RB.velocity.magnitude >= MagMax)
        {

            //Debug.Log("Boom");
            //Instantiate(Rubble, this.gameObject.transform.localPosition, this.gameObject.transform.localRotation);
            //Destroy(this.gameObject);
            Debug.Log("FallApart");
          

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
                if (DistToNext <= Gap)
                {
                 Debug.Log("NotFar");
                }
            }
            else
            {

                Debug.Log("Already nonK");

            }
        }    
    private IEnumerator WaitForRubble(float DTime)
    { while(true)
        {
            yield return new WaitForSeconds(DTime);
            Debug.Log("DoneCO");
            //Instantiate(Rubble, this.gameObject.transform.localPosition, this.gameObject.transform.localRotation);
            Destroy(this.gameObject);
        }
    }


    void ParticleExplosion()
    {

        RubbleExplosion.Invoke();



    }

}
