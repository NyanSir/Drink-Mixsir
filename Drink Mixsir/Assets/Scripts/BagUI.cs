using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour {
    
    
    
    //BagContent贴图
    public Sprite[] contentSprites = new Sprite[10];

    //BagUI下包含的Image对象
    protected Image[] imgs;

    private void Awake() {
        imgs = GetComponentsInChildren<Image>();
    }

    /// <summary>
    /// 更新BagUI中BagContent贴图
    /// </summary>
    public void UpdateSprites() {
        int index = 0;
        foreach (Image img in imgs) {
            img.sprite = contentSprites[index];
            index++;
        }
    }

    public void UpdateSprite(int index, Sprite sprite) {
        imgs[index].sprite = sprite;
        imgs[index].gameObject.SetActive(true);
    }
    
}
