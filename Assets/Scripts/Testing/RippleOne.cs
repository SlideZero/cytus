using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleOne : MonoBehaviour
{
    Vector2 positionPos;

    private void Start()
    {
        positionPos = transform.position;
    }

    private void Update()
    {
        //_spawnTimer += 1 * Time.deltaTime;
        if (BPM.beatFull)
        {
            //transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);
            Debug.Log("BeatFull");
        }

        if (BPM.beatD8 && BPM.beatCountD8 % 2 == 0)
        {
            //animator.SetTrigger("PlayRipple");
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);
        }
    }
}
