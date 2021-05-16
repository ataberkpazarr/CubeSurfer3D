using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{

    public gameManager gm;

    private void OnTriggerEnter(Collider other) //an object exists which is invisible, for ending level
    {
        gm.CompleteLevel(); 
    }
}
