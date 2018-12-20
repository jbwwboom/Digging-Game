using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private PlayerInformation playerInformation;


    private void Awake()
    {
        playerInformation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
    }



   public void SwapScene(string nextScene)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "SampleScene":
                Data.AddPoints(playerInformation.GetScore());
                if(nextScene != null)
                    SceneManager.LoadScene(nextScene);
                else
                    SceneManager.LoadScene("SaveScene");
                break;

            case "SaveScene":
                if (nextScene != null)
                    SceneManager.LoadScene(nextScene);
                else
                    SceneManager.LoadScene("SampleScene");
                break;

            default:
                break;
        }
    }
}
