using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Transform player;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the user fail, the same level restarted in two seconds, in this time period, unity gives errors in console and in order to prevent this error, try catch used
        try
        {
            text.text = (player.position.z).ToString("0");
        }
        catch { }
    }
}
