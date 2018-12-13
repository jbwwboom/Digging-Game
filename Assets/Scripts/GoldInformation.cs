using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldInformation : MonoBehaviour {
    [SerializeField] private int hitPoints; //show damage
    [SerializeField] private int level; //show color
    [SerializeField] private int score;
    // Use this for initialization
    void Awake()
    {
        hitPoints = 2;
        level = 0;
        score = Random.Range(1, 5);
    }

    public int IsHit(int toolLv, int toolStr, GameObject thisObject)
    {
        if (level < toolLv)
        {
            hitPoints -= toolStr;
        }
       return UpdateState(thisObject);
    }

    private int UpdateState(GameObject thisObject)
    {
        if (hitPoints <= 0)
        {
            thisObject.SetActive(false);
            return score;
        }
        return 0;
    }

    private void LateUpdate()
    {
        if(hitPoints<=0)
        {
            Destroy(this.gameObject);
        }
    }
}

