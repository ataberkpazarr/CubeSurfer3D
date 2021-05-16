using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour
{

    public Rigidbody rb; // for attaching our player (moving) cube 
    public float forwardForce = 20f; // can be changed by inspector 
    public float sidewaysForce = 500f;
    public GameObject myPrefab;
    public GameObject a;


    public void setNewHeight(Vector3 vec)
    {
        rb.transform.position = vec;
    }
    


 

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (rb.position.x >= 6.9f) 
        {

            rb.constraints = RigidbodyConstraints.FreezePositionX; // dont let player to go outside of the ground

            //when it reach most-right, its movement in x-axis freezed until it make movement to left (with pressing "a" ) which will unfreeze it
            if (Input.GetKey("a")) 
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(-sidewaysForce *1.5f* Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }


        }

        else if (rb.position.x <= -6.9f) 
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;// dont let player to go outside of the ground


            if (Input.GetKey("d")) // most-left version of above situation
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(sidewaysForce *1.5f* Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }

        }

        else // if it is not in the most-left or most-right 
        {
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            else if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

        }

        if (rb.position.y < -1f) // if our player cube falls down from the surface somehow, defensive programming
        {
            FindObjectOfType<gameManager>().endGame();

        }
    }


    }


