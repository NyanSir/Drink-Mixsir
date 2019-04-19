using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchable : AbstractItem {

    public delegate void TouchDelegate();
    public event TouchDelegate TouchEvent;
    
    public bool isTouched = false;
    public bool isClicked = false;
    
    protected override void OnDown() {
        isTouched = true;
        TouchEvent();
        base.OnDown();
    }

    protected override void OnUp() {
        isTouched = false;
        isClicked = true;
        base.OnUp();
    }

}
