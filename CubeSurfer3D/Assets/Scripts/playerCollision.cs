using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCollision : MonoBehaviour
{
    public GameObject extraText; // text for +1 after player collects cube for growing
    public GameObject extraTextCoin; //text for last screen total (multiplied) coin number
    public playerMovement movement; //for using playermovement class
    public Rigidbody rb; //player's rigidbody
    int total_scale = 1;
    public GameObject myPrefab; // for instantiating cubes

    public float total_children = 1;

    public float getTotalChildren()
    {

        return total_children;

    }

    public void setTotalChildren(float k)
    {
        total_children = k;
    }
    public List<GameObject> growUp_list = new List<GameObject>();
  
    private void OnCollisionEnter(Collision collision) // if player collide with below objects
    {
        
         if (collision.collider.tag == "Coin")
        {

            Destroy(collision.gameObject);


        }
        
        else if (collision.collider.tag == "growUp")
        {

            Debug.Log("dsfd");
            total_children += 1;




        }
        
        
    }

    private void OnTriggerEnter(Collider other) // if player triggers below objects's triggers
    {
        if (other.tag == "Coin")
        {
            
            Destroy(other.gameObject);
            GameObject textObjectCoin = Instantiate(extraTextCoin, this.transform.position + new Vector3(20, 10, 10), Quaternion.identity);
            StartCoroutine(DestroyObject(textObjectCoin));

        }

        else if (other.tag == "growUp")
        {

            GameObject textObject = Instantiate(extraText, this.transform.position + new Vector3(1, 6, 10), Quaternion.identity);
            StartCoroutine(DestroyObject(textObject));

        }

        else if (other.tag == "Obstacle")
        {
            Component[] k = this.transform.GetComponentsInChildren(typeof(Transform)); // get the children transforms of main player cube


            int a = k.Length;
         

            if (a <= other.transform.localScale.y) // if our player has less than or equal to the obstacle
            {
                StartCoroutine(instantiateGameObjecct(a));
                
            }

            else // if our player has more cubes than obstacle
            {
                StartCoroutine(instantiateGameObjecct(other.transform.localScale.y));
            }
        }

        else if (other.tag == "lastObstacle")
        {
            StartCoroutine(instantiateGameObjecct(1));
        }
        

    }

    IEnumerator instantiateGameObjecct(float total_ch) //instantiates gameobject, for instaniating lost cubes
    {
        List<GameObject>arrOfCubes =new List<GameObject>();

        for (int i=0; i<total_ch;i++)
        {

            GameObject lost_cube = Instantiate(myPrefab, this.transform.position + new Vector3(0, i*1.1f, -2), Quaternion.identity);
            arrOfCubes.Add(lost_cube);
        }
        
        yield return null;
        StartCoroutine(DestroyObject(arrOfCubes));

    }

    IEnumerator DestroyObject(GameObject gam) //destroying gameobject slowly
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gam);
    }

    IEnumerator DestroyObject(List<GameObject> list_of_gam) //above function function overloading, when a gameobject list comes rather than a single gameobject
    {
        yield return new WaitForSeconds(0.35f);
        foreach (GameObject g in list_of_gam)
        {
            Destroy(g);


        }
        
        
    }



}
