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
   // public Text extra;

    public void setNewHeight(Vector3 vec)
    {
        rb.transform.position = vec;
    }
    
    
    public List<GameObject> list_growups = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // rb.AddForce(0,200,500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        /*
        if (list_growups.Count > 0)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            for (int i = 0; i < list_growups.Count; i++)
            {
                list_growups[i].GetComponent<Rigidbody>().AddForce(0, 0, forwardForce * Time.deltaTime);
            }

        }

        else 
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        */
        Vector3 m_YAxis = new Vector3(0, 0, 5);
        Vector3 m_XAxis = new Vector3(5, 0, 0);
        Vector3 neg_m_XAxis = new Vector3(-5, 0, 0);


        if (rb.position.x >= 6.9f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            //rb.velocity = -m_YAxis;


            if (Input.GetKey("a"))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(-sidewaysForce *1.5f* Time.deltaTime, 0, 0, ForceMode.VelocityChange);
               // rb.velocity = -m_XAxis;
                //rb.velocity = -neg_m_XAxis;


            }


        }

        else if (rb.position.x <= -6.9f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            //rb.velocity = -m_YAxis;


            if (Input.GetKey("d"))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(sidewaysForce *1.5f* Time.deltaTime, 0, 0, ForceMode.VelocityChange);

               
            }


        }

        else
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

        if (rb.position.y < -1f) // if our player cube falls down from the surface
        {
            FindObjectOfType<gameManager>().endGame();

        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.collider.tag == "growUp")
        {
            Destroy(collision.gameObject);
   
            a =Instantiate(myPrefab, new Vector3(transform.position.x, transform.position.y+2, transform.position.z), Quaternion.identity);
            //a.GetComponent<Rigidbody>().useGravity = false;
            a.transform.parent = rb.transform;
            //GameObject childObject = Instantiate(myPrefab) as GameObject;

            //childObject.transform.position = childObject.transform.position+ new Vector3(0, childObject.transform.position.y + 5, 0);
            //childObject.transform.parent = rb.transform;



            //a.transform.parent = rb.transform;
            list_growups.Add(a);




        }
        
        
    }
*/


        /*
        private void OnTriggerEnter(Collider other)
        {
        
           
    
    }

    */

        
        

    }


