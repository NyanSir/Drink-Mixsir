using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixerSwitch : MonoBehaviour {

    public delegate bool FinishProductDelegate(Collectable[] ingredients, Collectable[] liquids);
    public event FinishProductDelegate FinishProduct;
    
    public Recipe mix;
    
    private Bowl bowl;
    private Glass glass;

    public Sprite upImage;
    public Sprite downImage;

    private void Awake() {
        bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
        glass = GameObject.Find("Glass").GetComponent<Glass>();
    }

    public void OnOpen() {
        if (FinishProduct(bowl.innerCollects, glass.innerCollects)) {
            bowl.EmptyContainer();
            glass.EmptyContainer();
        }
    }

    public void ReplaceSprite(Sprite s) {
        GetComponent<Image>().sprite = s;
    }

}
