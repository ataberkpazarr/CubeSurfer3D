using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelPanel;
    public void endGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", 2f); // 2f can be changed, it means that it will call the Restart() function, after 2 seconds
           // Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // scene name could be written directly but in this generic case, it wil be resetted from the level that it ended 
    }


    public void CompleteLevel()
    {
        completeLevelPanel.SetActive(true); // if the level completed, then the panel should be activated 
        gameHasEnded = true; 
    }
}
