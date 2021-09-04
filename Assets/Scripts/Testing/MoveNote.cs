using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{/*
    public Transform[] tapPoints;
    public float[] notes;
    public int nextIndex = 0;

    float moveTime = 0f;
    float dist = 0f;
    float velocity = 0f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for(int i = 0; i < notes.Length; i++)
        {
            notes[i] = tapPoints[i].GetComponent<Node>().nodeNote;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM._bPM.startGame)
        {
            if (nextIndex < tapPoints.Length)
            {
                NextPosition();

                transform.position = Vector3.MoveTowards(transform.position, tapPoints[nextIndex].position, velocity);//* Time.deltaTime);//BPM._bPM.secPerBeat / tapPoints[nextIndex].GetComponent<Node>().nodeNote);

                if(transform.position == tapPoints[nextIndex].position)
                {
                    nextIndex++;
                }
            }
            //Debug.Log(BPM._bPM.songPosInBeats);
            //Debug.Log(transform.position);
        }
        
    }

    private void NextPosition()
    {
        moveTime = (((notes[nextIndex] - BPM._bPM.songPosInBeats) * 8f) / BPM._bPM.secPerBeat);
        dist = Vector3.Distance(tapPoints[nextIndex].position, transform.position);
        velocity = dist / moveTime;
    }*/
}
