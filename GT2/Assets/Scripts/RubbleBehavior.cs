using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RubbleBehavior : MonoBehaviour {
    float TimeD;



    private void Awake()
    {
        TimeD = 2f;
        StartCoroutine(WaitForRubble(TimeD));
    }




    private IEnumerator WaitForRubble(float DTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(DTime);
            
            Destroy(this.gameObject);
        }
    }






}
