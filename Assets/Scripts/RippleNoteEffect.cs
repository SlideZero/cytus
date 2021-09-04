using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleNoteEffect : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            animator.SetTrigger("PlayRipple");
        }
        if (animator.GetNextAnimatorStateInfo(0).IsName("None"))
            gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
