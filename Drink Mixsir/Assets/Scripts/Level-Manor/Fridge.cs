using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : AbstractItem {

    public GameObject contain;

    public Sprite idleSprite;
    public Sprite openSprite;

    private bool isOpen;
    
	// Use this for initialization
	void Start () {
        if (contain != null)
            contain.SetActive(false);
        spr.sprite = idleSprite;
        GetComponent<Touchable>().TouchEvent += OnTouch;
	}

    private void OnTouch() {
        if (!isOpen) {
            //GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
            spr.sprite = openSprite;
            if (contain != null)
                contain.SetActive(true);
            isOpen = true;

            GetComponent<BoxCollider2D>().enabled = false;
        }        
    }

}
