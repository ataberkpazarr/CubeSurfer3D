using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCollision : MonoBehaviour
{
    public GameObject extraText;
    //public gameManager gm;
    public playerMovement movement;
    public Rigidbody rb;
    int total_scale = 1;
    public GameObject myPrefab;
    //public GameObject myPrefab;
    public Text extra;
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
    /*
    private void Start()
    {
        growUp_list = new List<GameObject>();
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.collider.tag == "Obstacle")   
        {
            Component [] k = this.GetComponentsInChildren(typeof(Transform)); // get the children transforms of main player cube
            //movement.enabled = false;
            //FindObjectOfType<gameManager>().endGame();
            int a = k.Length;
            Component will_be_destroyed = k[a - 1]; // go to the last added one

            //growUp_list.Remove(will_be_destroyed);
            //will_be_destroyed.SetActive(false);
            Destroy(will_be_destroyed.gameObject); // destroy it 
            total_children = total_children - 1;
        }
        */
         if (collision.collider.tag == "Coin")
        {
            //movement.enabled = false;
            //FindObjectOfType<gameManager>().endGame();
            //rb.isKinematic = true;
            Destroy(collision.gameObject);
            //rb.isKinematic = false;

        }
        
        else if (collision.collider.tag == "growUp")
        {
            //Destroy(collision.gameObject);
            //total_scale = total_scale + 1;
            Debug.Log("dsfd");
            total_children += 1;

            //transform.localScale += new Vector3(0, 2, 0);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);




        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);

            // PickUpCoins(other);
        }

       else  if (other.tag == "growUp")
        {
            Debug.Log("adadasd");

            

            //Text tempTextBox = Instantiate(extra, this.transform.position + new Vector3(4, 4, 0), Quaternion.identity) as Text;

            //tempTextBox.text = "+1";
            /*
            extra.text = "+1";
           extra.rectTransform.SetParent(this.transform);
            GameObject go = GameObject.Find("textObject");
            go.transform.position = this.transform.position + new Vector3(4, 0, 0);
            */
            GameObject textObject =Instantiate(extraText, this.transform.position + new Vector3(1, 6, 10), Quaternion.identity);
            // Vector2 kk = new Vector2(this.transform.position.x, this.transform.position.y) + new Vector2(4, 0);
            ////////extra.rectTransform.localPosition = this.transform.position + new Vector3(4,0,0);
            //rec.localPosition = kk;
            StartCoroutine(DestroyText(textObject));



            //go.text.enabled = true;


        }
        /*
       else  if (other.tag == "Obstacle" )
        {
            // Destroy(collision.gameObject);

           GameObject a = Instantiate(myPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
            //a.GetComponent<Rigidbody>().useGravity = false;
            a.transform.parent = rb.transform;
            //GameObject childObject = Instantiate(myPrefab) as GameObject;

            //childObject.transform.position = childObject.transform.position+ new Vector3(0, childObject.transform.position.y + 5, 0);
            //childObject.transform.parent = rb.transform;



            //a.transform.parent = rb.transform;
            
        }
        */

    }

    IEnumerator DestroyText(GameObject gam)
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(gam);
    }
    


}
