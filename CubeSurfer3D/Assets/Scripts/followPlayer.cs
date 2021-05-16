using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform player; // position of the player 
    public Vector3 cameraPosition;
    Vector3 a = new Vector3(5,7,-13.5f); //z -12 idi
    

    // Update is called once per frame
    void Update()
    {
        // when the user fail, the same level restarted in two seconds, in this time period, unity gives errors in console and in order to prevent this error, try catch used
        try
        {
            transform.position = cameraPosition + player.position + a;
        }
        catch { }

    }
}
