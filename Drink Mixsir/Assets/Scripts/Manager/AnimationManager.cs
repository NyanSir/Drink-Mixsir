using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState {
    //Customer Animation State
    Idle,
    Served,
    Satisfied,
    NeedMore,
    Dislike,
    Produce,
    Finish,

    //Interactable Animation State
    Touched,
    Move,
    Collected
}

public class AnimationManager : MonoBehaviour {

    private Animator animator;

    [SerializeField]
    private AnimationState animState;

    private string stateName = "state";
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        //Customer Animation
        switch (animState) {
            case AnimationState.Idle:
                animator.SetInteger(stateName, 0);
                break;

            case AnimationState.Satisfied:
                animator.SetInteger(stateName, 1);
                break;

            case AnimationState.Dislike:
                animator.SetInteger(stateName, 2);
                break;

            case AnimationState.Finish:
                animator.SetInteger(stateName, -1);
                break;
        }
        
        //Interactable Animation
        switch (animState) {
            
            case AnimationState.Touched:
                animator.SetInteger(stateName, 11);
                break;

            case AnimationState.Move:
                animator.SetInteger(stateName, 21);
                break;

            case AnimationState.Collected:
                animator.SetInteger(stateName, 12);
                break;
        }
        
    }

    public void SetAnimationState(AnimationState state) {
        animState = state;
    }

    public void SetTouched() {
        animator.SetBool("isTouched", false);
        SetAnimationState(AnimationState.Idle);
    }

    public void Play(string name) {
        animator.Play(name);
    }

}
