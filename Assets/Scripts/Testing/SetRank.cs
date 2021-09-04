using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRank : MonoBehaviour
{
    private CircleCollider2D NodeCollider;
    public GameObject player;
    private int rank = 0;

    private void Start()
    {
        NodeCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Note"))
        {
            if (NodeCollider.OverlapPoint(other.transform.position))
            {
                SetRankNote = 0;
            }
            else
            {
                SetRankNote = 1;
            }
        }
    }

    public int SetRankNote
    {
        get { return rank; }
        set { rank = value; }
    }
}
