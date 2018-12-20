using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInformation : MonoBehaviour {
    [SerializeField] private int hitPoints; //show damage
    [SerializeField] private int level; //show color
    public Sprite dmgSprite1;


    // Use this for initialization
    void Awake () {
        SetHitPoints();
        level = 0;
	}

    public void SetHitPoints()
    {
        hitPoints = Random.Range(0, 60);
        hitPoints = hitPoints % 2 + 1;
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
        GameObject childObject = thisObject.transform.GetChild(0).gameObject;
        childObject.GetComponent<SpriteRenderer>().sprite = dmgSprite1; 
    }
}
