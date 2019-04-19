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
    
    private void Awake() {
        animator = GetComponent<Animator>();
        drinkImage = transform.Find("Image").GetComponent<Image>();
        drinkName = transform.Find("Name").GetComponent<Image>();
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
    }

    public void SetState(int i) {
        state = i;
    }

    public void OnDestroy() {
        gameObject.SetActive(false);
    }

}
