using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBars : MonoBehaviour
{
    [SerializeField] private float direction = 0f;
    private BoxCollider2D boxCollider;
    private float horizontalLength = 0f;
    private RectTransform myTransform;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        horizontalLength = boxCollider.size.x;
        myTransform = GetComponent<RectTransform>();
        //limitY = transform.position.y;
    }

    private void Update()
    {
        myTransform.localPosition += direction * Vector3.right;

        if (myTransform.offsetMax.x < -horizontalLength)
        {
            Vector3 groundOffSet = new Vector3(horizontalLength * 2f, 0, 0);

            myTransform.localPosition = (Vector3)myTransform.localPosition + groundOffSet;
        }

        if (myTransform.offsetMax.x > horizontalLength)
        {
            Vector3 groundOffSet = new Vector3(-horizontalLength * 2f, 0, 0);

            myTransform.localPosition = (Vector3)myTransform.localPosition + groundOffSet;
        }

    }
}
