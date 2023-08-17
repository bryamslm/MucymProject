using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowInfo()
    {
        animator.SetBool("ShowInfo", true);
    }

    public void HideInfo()
    {
        animator.SetBool("ShowInfo", false);
    }
}
