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

    public int columns = 25;
    public int rows = 25;
    public Count goldCount = new Count(20, 50);
    public GameObject terrainTile;
    public GameObject goldTile;
    public GameObject outerTerrainTile;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for(int x = 1; x < columns - 1; x++)
        {
            for(int y = -1; y > -rows + 1; y--)
            {   
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        int totalGrid = rows * columns;
        int objectCount = Random.Range(goldCount.minimum, goldCount.maximum + 1);

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = 0; y > -rows - 1; y--)
            {
                GameObject instantiate = terrainTile;

                int randomGrid = Random.Range(0, totalGrid);
                if (x == -1 || x == columns || y == -rows)
                {
                    instantiate = outerTerrainTile;
                }else if (objectCount > randomGrid)
                {
                    instantiate = goldTile; 
                }
                GameObject instance = Instantiate(instantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    /*Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject goldObject = goldTile;
            Instantiate(goldObject, randomPosition, Quaternion.identity);
        }
    }*/

    public void SetupScene()
    {
        BoardSetup();
        InitialiseList();
        //LayoutObjectAtRandom(goldTile, goldCount.minimum, goldCount.maximum);
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }


    // Use this for initialization
    void Start () {
        SetupScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
