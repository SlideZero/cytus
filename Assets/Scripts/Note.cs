using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{/*
    enum noteRank
    {
        PERFECT, GOOD, BAD
    };
    noteRank Rank;

    public Vector2 tapNodePosition;

    Rigidbody2D rb;
    float moveTime = 0f;
    float dist = 0f;
    float velocity = 0f;
    Vector2 vec;

    Transform targetNode;
    float arrivalDistance = 0.1f;
    float lastDistanceToTarget = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastDistanceToTarget = Vector3.Distance(transform.position, BPM._bPM.tapPoints[BPM._bPM.nextIndex].position);
    }

    private void Update()
    {
        if (BPM._bPM.startGame)
        {
            if (BPM._bPM.nextIndex < BPM._bPM.tapPoints.Length)
            {
                velocity = (vec.magnitude * Time.deltaTime) / moveTime;
                transform.position = Vector2.MoveTowards(transform.position, BPM._bPM.tapPoints[BPM._bPM.nextIndex].position, velocity);
                
                if ((transform.position == BPM._bPM.tapPoints[BPM._bPM.nextIndex].position) && (BPM._bPM.nextIndex < BPM._bPM.tapPoints.Length - 1))
                {
                    BPM._bPM.nextIndex++;
                    vec = BPM._bPM.tapPoints[BPM._bPM.nextIndex].position - transform.position;
                    moveTime = (BPM._bPM.notes[BPM._bPM.nextIndex] - BPM._bPM.songPosInBeats) * BPM._bPM.secPerBeat;
                }
            }
        }
    }

    /*private void FixedUpdate()
    {
        float distanceTotarget = Vector3.Distance(transform.position, BPM._bPM.tapPoints[BPM._bPM.nextIndex].position);

        if (((distanceTotarget < arrivalDistance) || (distanceTotarget > lastDistanceToTarget)) && (BPM._bPM.nextIndex < BPM._bPM.tapPoints.Length - 1))
        {
            BPM._bPM.nextIndex++;
            targetNode = BPM._bPM.tapPoints[BPM._bPM.nextIndex];
            lastDistanceToTarget = Vector3.Distance(transform.position, BPM._bPM.tapPoints[BPM._bPM.nextIndex].position);

            vec = BPM._bPM.tapPoints[BPM._bPM.nextIndex].position - transform.position;
            moveTime = (BPM._bPM.notes[BPM._bPM.nextIndex] - BPM._bPM.songPosInBeats) * BPM._bPM.secPerBeat;
        }
        else
        {
            lastDistanceToTarget = distanceTotarget;
        }

        Vector3 dir = (BPM._bPM.tapPoints[BPM._bPM.nextIndex].position - transform.position).normalized;

        rb.MovePosition(transform.position + dir * (velocity));
    }*/

    /*private void NextPosition()
    {
        moveTime = (((BPM._bPM.notes[BPM._bPM.nextIndex] - BPM._bPM.songPosInBeats) * 8f) / BPM._bPM.secPerBeat);
        dist = Vector3.Distance(BPM._bPM.tapPoints[BPM._bPM.nextIndex].position, transform.position);
        velocity = dist / moveTime;
    }*/

    /*public void TapNote()
    {
        if (Rank == noteRank.PERFECT)
        {
            GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleNote");
            if (ripple != null)
            {
                ripple.SetActive(true);
                ripple.GetComponent<SpriteRenderer>().color = Color.yellow;
                ripple.transform.position = tapNodePosition;
            }
            ScoreManager.scoreManager.AddScorePoints(10);
        }
        else if (Rank == noteRank.GOOD)
        {
            GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleNote");
            if (ripple != null)
            {
                ripple.SetActive(true);
                ripple.GetComponent<SpriteRenderer>().color = Color.blue;
                ripple.transform.position = tapNodePosition;
            }
            ScoreManager.scoreManager.AddScorePoints(5);
        }
        else if(Rank == noteRank.BAD)
        {
            ScoreManager.scoreManager.AddScorePoints(-5);
        }
        ScoreManager.scoreManager.AddNote(Rank.ToString());
        
    }

    public void RankNote(int rank)
    {   
        Rank = (noteRank)rank;
    }*/
}
