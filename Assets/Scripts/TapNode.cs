using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNode : MonoBehaviour
{/*
    private CircleCollider2D tapNodeCollider;
    public float nodeNote = 0f;
    public GameObject notePlayer;
    Note note;

    private void Awake()
    {
        tapNodeCollider = GetComponent<CircleCollider2D>();
        note = notePlayer.GetComponent<Note>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (tapNodeCollider.OverlapPoint(collision.transform.position))
            {
                note.RankNote(0);
            }
            else
            {
                note.RankNote(1);
            }
            note.tapNodePosition = transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            note.RankNote(2);
        }
    }*/
}
