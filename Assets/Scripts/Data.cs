using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data  {

    private static int points;
 
    public static int  GetPoints()
    {
        return points;
    }
    
    public static void AddPoints(int value)
    {
        points += value;
    }
}

