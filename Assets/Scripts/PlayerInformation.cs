﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour {

    //@TODO: object  actual gameComponent
    public class Equipment
    {
        private int level;
        private int strength;

        public Equipment(int lv, int str)
        {
            level = lv;
            strength = str;
        }

        public int getLevel()
        {
            return level;
        }
        public int getStrength()
        {
            return strength;
        }
        public void setLevel(int lv)
        {
            level = lv;
        }
        public void setStrength(int str)
        {
            strength = str;
        }

    };

    private int gold;
    public int hitpoints;
    private bool alive;
    private GameObject player;
    private Equipment currentTool;


	// Use this for initialization
	void Start () {
        alive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        gold = 0;   //TODO: maybe take gold on adventure
        currentTool = new Equipment(1, 1); //get Equipment 
	}
	
    public void UpdateScore(int score)
    {
        gold += score;
        print(gold);
    }

    private void CheckPlayerState()
    {
        if(!alive)
        {
            gold = 0;
            //TODO:Put score on screen with UI Sript 
            player.SetActive(false);
        }
    }

    private void ExitDungeon()
    {
        //TODO:Put score on screen with UI Sript
        player.SetActive(false);
    }

    public int GetToolStrength()
    {
        return currentTool.getStrength();
    }

    public int GetToolLevel()
    {
        return currentTool.getLevel();
    }

    public void UpdateTool(Equipment equipment)
    {
        currentTool = equipment;
    }
}