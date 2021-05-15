using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class growUp : MonoBehaviour
{
    playerMovement movement;
    public GameObject myPrefab;
    public List<GameObject> list_growups = new List<GameObject>();
    public Rigidbody rb;
    bool alive = false;
    playerCollision player_col;
   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        
        {
            /*
            GameObject go = GameObject.Find("Player");
            playerCollision player_col = go.GetComponent<playerCollision>();
            float total_Children = player_col.getTotalChildren();
            total_Children += 1;
            player_col.setTotalChildren(total_Children);
            Debug.Log(total_Children);

            //this.gameObject.SetActive(false); //destroy vardı normalde 
            Destroy(this.gameObject);

           
            playerMovement player_mov = go.GetComponent<playerMovement>();
            //go.transform.position = new Vector3(go.transform.position.x, (total_Children * 1.1f), go.transform.position.z);
            player_mov.setNewHeight(new Vector3(go.transform.position.x,(total_Children*1.1f),go.transform.position.z));


            List<GameObject> growUpList = player_col.growUp_list;
            for (int i = 0; i<total_Children;i++)
            {
                growUpList[i].transform.position = new Vector3(go.transform.position.x, go.transform.position.y+1.1f, go.transform.position.z);
                //growUpList[i].transform.parent = other.GetComponent<Rigidbody>().transform;
                growUpList[i].transform.parent = go.transform;



            }
            GameObject a;
            //a = Instantiate(myPrefab, new Vector3(other.transform.position.x, (other.transform.position.y + (total_Children*1.1f)), other.transform.position.z), Quaternion.identity);
            a = Instantiate(myPrefab, new Vector3(go.transform.position.x, 1, go.transform.position.z), Quaternion.identity);

            rb = a.GetComponent<Rigidbody>();
            a.transform.parent = go.transform;



            alive = true;

            
            player_col.growUp_list.Add(a);


            */
            
                
            GameObject go = GameObject.Find("Player");
            playerCollision player_col = go.GetComponent<playerCollision>();
            float total_Children = player_col.getTotalChildren();
            total_Children += 1;
            player_col.setTotalChildren(total_Children);
            ////Debug.Log(total_Children);

            //this.gameObject.SetActive(false); //destroy vardı normalde 
            Destroy(this.gameObject);

           
            playerMovement player_mov = go.GetComponent<playerMovement>();
            //player_mov.setNewHeight(new Vector3(transform.position.x,(total_Children*1.1f),transform.position.z));


            GameObject a;
            a = Instantiate(myPrefab, new Vector3(other.transform.position.x, (other.transform.position.y + (total_Children*1.1f)), other.transform.position.z), Quaternion.identity);
          
            rb=a.GetComponent<Rigidbody>();
            a.transform.parent = other.GetComponent<Rigidbody>().transform;



            alive = true;
          
            player_col.growUp_list.Add(a);

            
             


        }

    }
    
     void FixedUpdate()
    {
        /*
        if (alive)
        {
            rb.AddForce(0, 0, 4000 * Time.deltaTime,ForceMode.Force);
            Debug.Log("aaa"); 
        }
        */

        
    }
}
