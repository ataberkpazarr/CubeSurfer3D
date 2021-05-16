using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text CoinText;
    public Text FinalScore;
    bool gameHasEnded = false;
    public GameObject completeLevelPanel;
    public void endGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", 2f); 
                                
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // scene name could be written directly but in this generic case, it wil be resetted from the level that it ended 
    }

    public void CompleteLevel(float m) // complete level function if the player could not pass all steps
    {
        StartCoroutine(waitCoupleSecs(m));

    }
    public void CompleteLevel() // complete level function for the situation which player passes all levels
    {

        StartCoroutine(waitCoupleSecs(4));
        
    }

    IEnumerator waitCoupleSecs(float total_multiplier) //for waiting couple seconds before changing scene etc.
    {
        yield return new WaitForSeconds(0.45f);
        completeLevelPanel.SetActive(true); // if the level completed, then the panel should be activated 
        FinalScore.text ="Total  Score: "+ (int.Parse(CoinText.text.ToString()) * total_multiplier).ToString();
        yield return new WaitForSeconds(1f);

        gameHasEnded = true;

    }
}
