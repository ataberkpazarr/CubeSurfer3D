using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coin : MonoBehaviour
{

    public Text coinText;
     int total_coin = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            
            Destroy(this.gameObject);

            
                total_coin = int.Parse(coinText.text.ToString()) + 1;
                // total_coin = total_coin * 2;
                //total_coin = total_coin + 5;
                coinText.text = total_coin.ToString();
                // PickUpCoins(other);
            
        }

    }
}
