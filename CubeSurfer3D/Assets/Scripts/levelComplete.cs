using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelComplete : MonoBehaviour
{
    public void loadNextLevel()
    {

        Debug.Log("aead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //load next level, take it from scenes


    }
}
