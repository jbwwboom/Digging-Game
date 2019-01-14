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
    public static int rowAmount = 1;
    private int oldRows = 0;
    private int addRows;
    public Count goldCount = new Count(100, 120);
    public Count amethystCount = new Count(0, 0);
    public GameObject terrainTile;
    public GameObject goldTile;
    public GameObject outerTerrainTile;
    public GameObject amethystTile;
    private GameObject player;

    private Transform boardHolder;

    void BoardSetup()
    {
        //boardHolder = new GameObject("Board").transform;
        int totalGrid = rows * columns;
        int goldAmount = Random.Range(goldCount.minimum, goldCount.maximum + 1);
        int amethystAmount = Random.Range(amethystCount.minimum, amethystCount.maximum + 1);

        for (int x = 0; x < columns + 1; x++)
        {
            for (int y = -oldRows; y > -rows - 1; y--)
            {
                GameObject instantiate = terrainTile;

                int randomGrid = Random.Range(0, totalGrid);
                if (amethystAmount > randomGrid)
                {
                    instantiate = amethystTile;
                } else if (goldAmount > randomGrid){
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
        if(GameObject.Find("Board") == null)
        {
            boardHolder = new GameObject("Board").transform;
            boardHolder.tag = "Board";
            BoardSetup();
            BorderSetup();
        }
        else
        {
            boardHolder = GameObject.Find("Board").GetComponent<Transform>();
            Vector3 temp = new Vector3(-100, 0, 0);
            boardHolder.transform.position += temp;
            boardHolder.tag = "Board";
            rows *= rowAmount;
        }
        
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
            amethystCount.minimum += goldIncrease / 2;
            amethystCount.maximum += goldIncrease;
            oldRows = rows + 1;
            rows += addRows;
            rowAmount++;
            BoardSetup();
        }
	}
}
