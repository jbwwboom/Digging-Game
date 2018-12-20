using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {
    private GameController gameController; 

	void Awake () {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameController.SwapScene(null);
        }
        
    }
}
