using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMouseEvent : MonoBehaviour {

    public GameObject[] targets;
    
    public delegate void InTargetDelegate(GameObject target);
    public event InTargetDelegate InTargetExecute;
    
    private bool isOnDrag = false;
    private int isInTargetIndex = -1;
    
    private Vector3 originPosition;

    private void Start () {
        originPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnDrag() {
        transform.position = Input.mousePosition;
        isOnDrag = true;
    }

    public void EndDrag() {
        isOnDrag = false;
        transform.localPosition = originPosition;
        if (isInTargetIndex >= 0) {
            //Debug.Log("UI Event: " + targets[isInTargetIndex].name);
            InTargetExecute(targets[isInTargetIndex]);
        }
        isInTargetIndex = -1;
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        for (int i = 0; i < targets.Length; i++) {
            if (other.gameObject.Equals(targets[i])) {
                isInTargetIndex = i;
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isInTargetIndex = -1;
    }

}
