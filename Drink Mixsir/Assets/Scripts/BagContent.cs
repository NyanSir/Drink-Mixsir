using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagContent : MonoBehaviour {
    
    //物品种类（Ingredient / Liquid）
    public ContentType type;
    //物品名称
    public new string name;

    public int id;
    public string contentName;
    public Collectable content;
    public Sprite sprite;
    
    public void SetContent(Collectable go) {
        content = go;
        sprite = go.GetSprite();
    }

    private void Awake () {
        GetComponent<UIMouseEvent>().InTargetExecute += AddToContainer;
    }

    private void Start() {
        //SetInteractive(false);
    }

    private void Update () {
        
    }

    private void AddToContainer(GameObject container) {
        //Debug.Log("put success: " + container.name);

        container.GetComponent<Container>().PutIn(this.content);
    }

    public void SetInteractive(bool flag) {
        GetComponent<EventTrigger>().enabled = flag;
    }

    /*
    public void OnDrag() {
        if (content != null) {
            transform.position = Input.mousePosition;
            isOnDrag = true;
        }
    }

    public void EndDrag() {
        transform.localPosition = originPosition;
        isOnDrag = false;
        //添加至容器内
        if (isInContainer) {
            Debug.Log("put success: " + targetContainer.name);

            targetContainer.GetComponent<Container>().PutIn(this.content);

            isInContainer = false;
        }
    }

    //拖动进目标容器
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.Equals(targetContainer)) {
            isInContainer = true;
        }

        //Debug.Log("trigger stay: " + other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.Equals(targetContainer)) {
            isInContainer = false;
        }
    }
    */
}
