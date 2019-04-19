using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan_Mice : MonoBehaviour {

    private Bowl bowl;
    private Glass glass;

    private Animator animator;

    private void Awake() {
        bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
        glass = GameObject.Find("Glass").GetComponent<Glass>();
        animator = GetComponent<Animator>();
    }

    public void Release() {
        gameObject.SetActive(true);
        animator.SetBool("isOut", true);
    }

    public void Back() {
        gameObject.SetActive(false);
        animator.SetBool("isOut", false);
    }

    public void EmptyBowl() {
        bowl.EmptyContainer(); 
    }

    public void EmptyGlass() {
        glass.EmptyContainer();
    }

}
