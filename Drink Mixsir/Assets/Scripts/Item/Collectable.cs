using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectType 
{
    Ingredient,
    Liquid
}

public class Collectable : AbstractItem {

    public CollectType collectType;

    public Sprite uiSprite;

    public bool isCollected;

    public bool deactiveAfterCollect;

    //public delegate void BagDelegate();
    //public BagDelegate bag;

    protected override void OnDown() {
        AddToBag();

        //if (deactiveAfterCollect)
        //    gameObject.SetActive(false);
        
        GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);

        base.OnDown();
    }

    protected virtual void AddToBag() {
        
        if (!isCollected) {
            switch (collectType) {
                case CollectType.Ingredient:
                    GameObject.Find("Bag - Ingredients").GetComponent<Bag>().AddToBag(this);
                    break;

                case CollectType.Liquid:
                    GameObject.Find("Bag - Liquid").GetComponent<Bag>().AddToBag(this);
                    break;
            }

            isCollected = true;
        }
        
    }

    public Sprite GetSprite() {
        return uiSprite;
    }

    public void DeactiveCollider() {
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
