using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    playerCollision playercol;
    private void OnTriggerEnter(Collider other)
    {
        
        
         if (other.tag == "Player" )
        {
          
                float m = this.transform.localScale.y; // take the y scale which determines the height of the obstacle. Destroy that much cube from player
                Debug.Log(m);
            
           // Component[] k = other.GetComponentsInChildren(typeof(Transform)); // get the children transforms of main player cube
            
            Component[] k = other.transform.GetComponentsInChildren(typeof(Transform)); // get the children transforms of main player cube
            //movement.enabled = false;
            //FindObjectOfType<gameManager>().endGame();
            int a = k.Length;
            for (int i = 1; i < m+1; i++)
            { 
            Component will_be_destroyed = k[a-i]; // go to the last added one
                Destroy(will_be_destroyed.gameObject); // destroy it
            }
           // Component will_be_destroyed = k[a - 1]; // go to the last added one

     
            //Destroy(will_be_destroyed.gameObject); // destroy it 


            GameObject go = GameObject.Find("Player");
            playerCollision player_col = go.GetComponent<playerCollision>();
            float total_Children = player_col.getTotalChildren();
            player_col.setTotalChildren(total_Children-m);
            
        }
        

    }
}
