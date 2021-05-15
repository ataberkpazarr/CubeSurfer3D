using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform player; // position of the player 
    public Vector3 cameraPosition;
    Vector3 a = new Vector3(5,7,-12);
    

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition + player.position+a;

    }
}
