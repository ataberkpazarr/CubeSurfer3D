using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    playerCollision playercol;
    bool last = false;

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.name=="4")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other) // when player touches to yo obstacles
    {
        
        
         if (other.tag == "Player" )
        {
            GameObject go = GameObject.Find("Player");
            playerCollision player_col = go.GetComponent<playerCollision>();
            float total_Children = player_col.getTotalChildren(); // check the total children of player object
            float m;
            if (this.tag == "lastObstacle") // this tag is for the last multiplication steps
            {
                
                Rigidbody rb = other.GetComponent<Rigidbody>(); 

                rb.constraints = RigidbodyConstraints.FreezePositionX; // when player reaches the final multiplication steps, do not let him/her to move it in x axis
                rb.freezeRotation = true; //also the collisions due to steps may cause rotation thats why rotation is freezed in the last steps

                m = int.Parse(this.gameObject.name); // take the name of the object, the names of multiplication steps are 1,2,3,4 respectively
                other.transform.position = new Vector3(other.transform.position.x,this.transform.position.y+2,other.transform.position.z);

                if (total_Children == 0)
                {
                    FindObjectOfType<gameManager>().CompleteLevel(m);
                }

               

                if (m != 4)
                {
                    this.gameObject.GetComponent<Collider>().isTrigger = false;
                }

                m = 1;

            }
            else // if not multiplication steps
            {

                m = this.transform.localScale.y; // take the y scale which determines the height of the obstacle. Destroy that much cube from player
            }

            if (last && total_Children==0)  // if last tour
            {
                FindObjectOfType<gameManager>().endGame();
            }

                
            Component[] k = other.transform.GetComponentsInChildren(typeof(Transform)); // get the children transforms of main player cube


            int a = k.Length;
            for (int i = 1; i < m +1; i++) // destroy last added cubes after player collides into the obstacles
            {
                if (a-i >=0)
                {
                    Component will_be_destroyed = k[a - i]; // go to the last added one
                    Destroy(will_be_destroyed.gameObject); // destroy it
                }
            }


            

            if (total_Children-m<0 ) // if total children is smaller than zero, than it means level is failed
            {
                FindObjectOfType<gameManager>().endGame();
                
            }
            else if (total_Children - m == 0) //when total children is equal to zero, then we also have player itself, so it did not failed yet but it is in the last collision in terms of 
            {
                
                last = true;
            }

            player_col.setTotalChildren(total_Children - m); //set total children info
            
        }

 
    }
}
