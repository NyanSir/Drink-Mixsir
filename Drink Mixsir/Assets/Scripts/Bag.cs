using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ContentType
{
    Ingredient,
    Liquid
}

public class Bag : MonoBehaviour {
    
    public ContentType bagType;
    
    public BagContent[] contents = new BagContent[10];

    public BagUI bagUI;

    // Use this for initialization
    void Start () {
        contents = GetComponentsInChildren<BagContent>();

        for (int i = 0; i < contents.Length; i++) {
            contents[i].gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 添加GameObject到Bag中
    /// </summary>
    /// <param name="go">将要添加的GameObject</param>
    public void AddToBag(Collectable go) {
        
        int index = 0;
        foreach (BagContent content in contents) {
            
            if (content.content == null) {
                content.SetContent(go);
                content.SetInteractive(true);
                //Debug.Log(content.gameObject.name + ": " + content.GetComponent<EventTrigger>().enabled);
                bagUI.UpdateSprite(index, contents[index].sprite);
                //Debug.Log(contents[index]);
                break;
            }
            index++;

        }
        
    }

    /// <summary>
    /// 从Bag中移除指定id的BagContent
    /// </summary>
    /// <param name="id">将要移除的id</param>
    public void RemoveFromBag(int id) {
        contents[id] = null;

        bagUI.UpdateSprite(id, null);
    }

}
