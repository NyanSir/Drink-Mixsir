using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drink : MonoBehaviour {

    private Image drinkImage;
    private Image drinkName;
    [SerializeField]
    private GameObject official;

    private int state = 0;
    private Animator animator;

    private FMODUnity.StudioEventEmitter emitter;

    private void Awake() {
        animator = GetComponent<Animator>();
        drinkImage = transform.Find("Image").GetComponent<Image>();
        drinkName = transform.Find("Name").GetComponent<Image>();

        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }
    
	// Use this for initialization
	private void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
        switch (state) {
            case 0:
                animator.SetInteger("state", 0);
                break;
            case 1:
                animator.SetInteger("state", 1);
                break;
            case 2:
                animator.SetInteger("state", 2);
                break;
        }
		
	}

    public void DisplayDrink(Sprite image, Sprite name, bool isOfficial) {
        if (isOfficial) {
            official.SetActive(true);
        } else {
            official.SetActive(false);
        }
        
        drinkImage.sprite = image;
        drinkName.sprite = name;
        
        gameObject.SetActive(true);

        state = 0;

        PlayAudio();
    }

    public void SetState(int i) {
        state = i;
    }

    private void PlayAudio() {
        if (emitter != null) {
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


    public void OnDestroy() {
        gameObject.SetActive(false);
    }

}
