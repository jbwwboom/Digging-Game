using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInformation : MonoBehaviour {
    [SerializeField] private int hitPoints; //show damage
    [SerializeField] private int level; //show color


	// Use this for initialization
	void Awake () {
        SetHitPoints();
        level = 0;
        UpdateState(this.gameObject);
	}

    public void SetHitPoints()
    {
        hitPoints = Random.Range(0, 60);
        if (hitPoints != 0)
        { hitPoints = hitPoints % 2 + 1; }
    }

    public void IsHit(int toolLv, int toolStr, GameObject thisObject)
    {
        if(level < toolLv)
        {
            hitPoints -= toolStr;
        }
        UpdateState(thisObject);
    }

    private void UpdateState(GameObject thisObject)
    {
        if(hitPoints<=0)
        {
            Destroy(thisObject);
        }
    }
}
