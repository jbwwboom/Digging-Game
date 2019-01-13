using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour {
    public float playerRange;
    private Vector3 playerPos;
    private PlayerInformation playerInformation;
    

	// Use this for initialization
	void Start () {
        playerInformation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInformation>();
        
	}

    // Update is called once per frame
    void Update() 
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (Input.touchCount == 2)
        {
            PinchZoom();
        }
        else {
            ClickedOnScreen();
            //@TODO:clickedOnUI(); check layers?? 
        }
    }

    private void ClickedOnScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, playerRange);

            if (hit.collider != null)
            {
                GameObject currentHit = hit.collider.gameObject;
                Vector3 range = currentHit.transform.position - playerPos;
                float rangeID = Mathf.Sqrt((range.x * range.x) + (range.y * range.y));
                
                if (rangeID <= playerRange)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PlayerDig");
                    switch(currentHit.tag)
                    {
                        case "Pickups":
                            GoldInformation goldInformation = currentHit.gameObject.GetComponent<GoldInformation>();
                            playerInformation.UpdateScore(goldInformation.IsHit(playerInformation.GetToolLevel(), playerInformation.GetToolStrength(), currentHit));
                            break;
                        case "Amethyst":
                            AmethystInformation amethystInformation = currentHit.gameObject.GetComponent<AmethystInformation>();
                            playerInformation.UpdateScore(amethystInformation.IsHit(playerInformation.GetToolLevel(), playerInformation.GetToolStrength(), currentHit));
                            break;
                        case "Terrain":
                            TerrainInformation terrainInformation = currentHit.gameObject.GetComponent<TerrainInformation>();
                            terrainInformation.IsHit(playerInformation.GetToolLevel(), playerInformation.GetToolStrength(), currentHit);
                            break;
                        default:
                            break;
                    }
                    
                }
            }
        }
    }

    private void PinchZoom()
    {
        //@TODO: zoom 
    }
}
