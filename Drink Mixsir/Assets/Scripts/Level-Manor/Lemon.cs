using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : Ingredient {

    public Sprite[] sprites;
    [SerializeField]
    private int index;
    [SerializeField]
    private bool canCollect;

    // Use this for initialization
    void Start () {
        spr.sprite = sprites[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnDown() {

        if (!canCollect) {
            if (index < sprites.Length - 2) {
                SetAudioState(index);
                PlayAudio();

                index++;
                spr.sprite = sprites[index];

            } 
            
            if (index >= sprites.Length - 2) {

                canCollect = true;
            }
        }
        else {
            AddToBag();
            spr.sprite = sprites[index + 1];

            SetAudioState(2.0f);
            PlayAudio();

            GetComponent<BoxCollider2D>().enabled = false;
        }
          
    }

}
