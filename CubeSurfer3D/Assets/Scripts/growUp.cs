using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class growUp : MonoBehaviour
{

    public GameObject myPrefab; //cube prefab attached
    public List<GameObject> list_growups = new List<GameObject>();
    public Rigidbody rb;

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player") //if player collects growup
        
        {
            
                
            GameObject go = GameObject.Find("Player");
            playerCollision player_col = go.GetComponent<playerCollision>();

            float total_Children = player_col.getTotalChildren();
            total_Children += 1; //increase its total children
            player_col.setTotalChildren(total_Children);
            Destroy(this.gameObject); //destroy collected one

           
            playerMovement player_mov = go.GetComponent<playerMovement>();

             

            //instantiate new cube
            GameObject a = Instantiate(myPrefab, new Vector3(other.transform.position.x, (other.transform.position.y + (total_Children*1.1f)), other.transform.position.z), Quaternion.identity); 
            rb=a.GetComponent<Rigidbody>();
            a.transform.parent = other.GetComponent<Rigidbody>().transform;



          //add it into the list
            player_col.growUp_list.Add(a);

        }

    }
    
   
}
