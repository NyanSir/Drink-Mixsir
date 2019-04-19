using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : Container {
    
    [SerializeField]
    private bool isMixed = false;
    private bool isOnDrag = false;
    private bool isInGlass = false;
    
    protected override void Start() {
        base.Start();
        GetComponent<UIMouseEvent>().InTargetExecute += InTargetExecute;
    }

    private void InTargetExecute(GameObject target) {
        
        if (target.name == "Glass") {
            target.GetComponent<Glass>().CombineWith(innerCollects);
            Debug.Log("Mixed");
        }

        if (target.name == "TrashCan") {
            EmptyContainer();
        }

    }

    /*
    public void OnDrag() {
        transform.position = Input.mousePosition;
        isOnDrag = true;
    }

    public void EndDrag() {
        transform.position = originPosition;
        isOnDrag = false;
        //添加至Glass内
        if (isInGlass) {
            GameObject.Find("Glass").GetComponent<Glass>().CombineWith(innerCollects);
        }
    }

    //拖动进目标容器
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Glass") {
            isInGlass = true;
        }

        //Debug.Log("trigger stay: " + other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Glass") {
            isInGlass = false;
        }
    }
    */

}
