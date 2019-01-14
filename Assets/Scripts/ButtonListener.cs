using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button button;
    public Button[] buttons;
    public GameObject panel;
    public int cost = 10;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);

        for (int i = 0; i < buttons.Length; i++)
        {
            int y = i;
            buttons[i].GetComponentInChildren<Text>().text = ((y + 1) * cost) + "";
            buttons[i].onClick.AddListener(delegate { BuyOnClick(y);});
        }
    }

    void TaskOnClick()
    {
        if(panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    void BuyOnClick(int i)
    {
        int gold = int.Parse(buttons[i].GetComponentInChildren<Text>().text);


        if(Data.GetPoints() >= gold)
        {
            Data.AddPoints(-gold);
            Data.AddHitpoints(gold * 5);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>().UpdateScoreText();
        }
    }

}
