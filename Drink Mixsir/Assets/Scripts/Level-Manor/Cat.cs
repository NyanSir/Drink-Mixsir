using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Customer_Producer {

    public GameObject protectObject;

    public void LiftTail() {
        protectObject.GetComponent<Tomato>().Release();
    }

    public void Stare() {
        GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
    }
    
}
