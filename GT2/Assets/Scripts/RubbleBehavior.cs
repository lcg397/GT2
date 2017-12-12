using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RubbleBehavior : MonoBehaviour {
    float TimeD;
    public ParticleSystem Rubb;
    public Mesh PartMesh;
    public GameObject Daddy;
    private void Awake()
    {
        Rubb = this.gameObject.GetComponent<ParticleSystem>();
        Daddy = this.gameObject.transform.parent.gameObject;
        PartMesh = Daddy.GetComponent<MeshFilter>().sharedMesh;
        var sh = Rubb.shape;
        sh.enabled = true;
        sh.shapeType = ParticleSystemShapeType.Mesh;
        sh.mesh = PartMesh;
        TimeD = 2f;
    }
  






}
