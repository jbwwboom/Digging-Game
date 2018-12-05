using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    bool destroy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            destroy = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (destroy)
        {
            destroy = false;
            if(collision.gameObject.tag != "Impassable")
                Destroy(collision.gameObject);
        }
    }
}
