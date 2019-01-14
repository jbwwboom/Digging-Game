using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Data  {

    private static int points;
    private static int hitpoints = 10;

    public static int  GetPoints()
    {
        return points;
    }
    
    public static void AddPoints(int value)
    {
        points += value;
    }

    public static int GetHitpoints()
    {
        return hitpoints;
    }

    public static void AddHitpoints(int hp)
    {
        hitpoints += hp;
    }

    public static void LoseHitpoints()
    {
        hitpoints -= 1;
    }

    public static void Restart()
    {
        hitpoints = 10;
        points = 0;
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Board"));
        SceneManager.LoadScene("SampleScene");
    }
}

