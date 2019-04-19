using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Collectable,
    Touchable,
    Movable
}

public class AbstractItem : MonoBehaviour {
    
    protected Collider2D c2d;
    protected Animator animator;
    protected SpriteRenderer spr;
    
    protected virtual void Awake () {
        c2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void OnMouseDown() {
        OnDown();
    }

    protected virtual void OnDown() { }

    protected void OnMouseUpAsButton() {
        OnUp();
    }

    protected virtual void OnUp() { }

    protected void OnMouseExit() {
        OnExit();
    }

    protected virtual void OnExit() { }

    protected void OnMouseDrag() {
        OnDrag();
    }

    protected virtual void OnDrag() { }

    protected void OnDestroy() {
        gameObject.SetActive(false);
    }

}
