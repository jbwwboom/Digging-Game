using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
            }

        }
    }
}
