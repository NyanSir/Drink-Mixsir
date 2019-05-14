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

    protected FMODUnity.StudioEventEmitter emitter;

    //public delegate void BagDelegate();
    //public BagDelegate bag;

    protected override void Awake() {
        base.Awake();

        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    protected override void OnDown() {
        AddToBag();

        //if (deactiveAfterCollect)
        //    gameObject.SetActive(false);

        GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
        PlayAudio();

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

    protected void PlayAudio() {
        if (emitter != null) {
            emitter.Play();
        }
    }

    protected void SetAudioState(float state) {
        if (emitter != null) {
            emitter.Params[0].Value = state;
            //emitter.SetParameter("State", state);
        }
    }

}
