using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 50;
    public int rows = 25;
    private int oldRows = 0;
    private int addRows;
    public Count goldCount = new Count(100, 120);
    public GameObject terrainTile;
    public GameObject goldTile;
    public GameObject outerTerrainTile;
    private GameObject player;

    private Transform boardHolder;

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        int totalGrid = rows * columns;
        int objectCount = Random.Range(goldCount.minimum, goldCount.maximum + 1);

        for (int x = 0; x < columns + 1; x++)
        {
            for (int y = -oldRows; y > -rows - 1; y--)
            {
                GameObject instantiate = terrainTile;

                int randomGrid = Random.Range(0, totalGrid);
                if (objectCount > randomGrid)
                {
                    instantiate = goldTile;
                }
                GameObject instance = Instantiate(instantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

        for (int y = -oldRows; y > -rows - 1; y--)
        {
            int randomBorder = Random.Range(1, 4);
            for (int i = 1; i <= 3; i++)
            {
                GameObject border;
                if (i >= randomBorder)
                {
                    border = outerTerrainTile;
                }
                else
                {
                    border = terrainTile;
                }

                GameObject borderObject = Instantiate(border, new Vector3(0 - i, y, 0f), Quaternion.identity) as GameObject;
                GameObject borderObject2 = Instantiate(border, new Vector3(columns + i, y, 0f), Quaternion.identity) as GameObject;
                borderObject.transform.SetParent(boardHolder);
                borderObject2.transform.SetParent(boardHolder);
            }
        }
    }

    public void BorderSetup()
    {   
        for(int bY = 1; bY <= 10; bY++)
        {
            for (int i = 1; i <= 3; i++)
            {
                GameObject border = outerTerrainTile;

                GameObject borderObject = Instantiate(border, new Vector3(0 - i, bY, 0f), Quaternion.identity) as GameObject;
                GameObject borderObject2 = Instantiate(border, new Vector3(columns + i, bY, 0f), Quaternion.identity) as GameObject;
                borderObject.transform.SetParent(boardHolder);
                borderObject2.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene()
    {
        BoardSetup();
        BorderSetup();
        //InitialiseList();
    }


    // Use this for initialization
    void Start () {
        SetupScene();
        player = GameObject.FindGameObjectWithTag("Player");
        addRows = rows;

    }
	
	// Update is called once per frame
	void Update () {
	    if(-rows + addRows / 5 > player.transform.position.y)
        {
            int goldIncrease = addRows / 5 * 2;
            goldCount.minimum += goldIncrease;
            goldCount.maximum += goldIncrease * 2;
            oldRows = rows;
            rows += addRows;
            BoardSetup();
        }
	}
}
