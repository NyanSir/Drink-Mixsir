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

    private FMODUnity.StudioEventEmitter emitter;

    private void Awake() {
        bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
        glass = GameObject.Find("Glass").GetComponent<Glass>();

        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    public void OnOpen() {
        if (FinishProduct(bowl.innerCollects, glass.innerCollects)) {
            bowl.EmptyContainer();
            glass.EmptyContainer();

            SetAudioState(1.0f);
            PlayAudio();
        }
    }

    public void ReplaceSprite(Sprite s) {
        GetComponent<Image>().sprite = s;
    }

    private void PlayAudio() {
        if (emitter != null && !emitter.IsPlaying())
        {
            emitter.Play();
        }
    }

    private void SetAudioState(float state) {
        if (emitter != null)
        {
            emitter.Params[0].Value = state;
            //emitter.SetParameter("State", state);
        }
    }

}
