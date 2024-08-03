using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour
{
    [SerializeField]Animator animator;

    private void Start()
    {
        animator.SetBool("Start", true);
    }

}
