using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private bool isMouseDown;
    
    public static Vector3 mousePosition;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            isMouseDown = true;
            
        }

        if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
        }
		
	}

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(mousePosition, new Vector3(0.5f, 0.5f, 0));
    }

}
