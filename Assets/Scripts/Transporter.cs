using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public Button button;
    private GameController gameController;
        

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    void TaskOnClick()
    {
        GameObject board = GameObject.Find("Board");
        Vector3 temp = new Vector3(100, 0, 0);
        board.transform.position = temp;
        DontDestroyOnLoad(board);
        gameController.SwapScene(null);
    }
}
