using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteNode : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public int noteSegments = 1;
    public float direction = 0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(BPM._bPM.startGame)
            rigidbody.angularVelocity = (((2 * Mathf.PI) * BPM._bPM.bPM) / noteSegments) * direction;
    }
}
