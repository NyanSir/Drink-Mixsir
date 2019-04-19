using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Ingredient {

    public GameObject cat;

    [SerializeField]
    private bool isRelease;

    private void Start() {
        //cat.GetComponent<Cat>().Satisfy += Release;
    }

    public void Release() {
        GetComponent<AnimationManager>().SetAnimationState(AnimationState.Finish);
        isRelease = true;
    }

    protected override void OnDown() {
        if (isRelease) {
            AddToBag();
            GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
        }
        else {
            cat.GetComponent<Cat>().Stare();
        }
    }

}
