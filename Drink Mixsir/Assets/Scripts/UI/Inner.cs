using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inner : MonoBehaviour {

    public delegate void RemoveDelegate(Inner i);
    public event RemoveDelegate Remove;

    

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDown() {
        Remove(this);
        //Debug.Log("mouse down");
    }

    

}
