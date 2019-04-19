using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] customers;
    public int customersRemain;

    public GameObject resultMenu;

    public float resultDelay;
    
    private void Awake() {
        resultMenu.SetActive(false);

        customers = GameObject.FindGameObjectsWithTag("Customer");
        customersRemain = customers.Length;

        foreach (GameObject customer in customers) {
            customer.GetComponent<Customer>().Satisfy += SatisfyCustomer;
        }
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCustomer() {
        customersRemain++;
    }

    public void SatisfyCustomer() {
        customersRemain--;

        if (customersRemain <= 0) {
            StartCoroutine(ShowResult());
        }
    }

    public void ChangeScene() {
        GetComponent<SceneSwitch>().ChangeScene();
    }

    public IEnumerator ShowResult() {
        yield return new WaitForSeconds(resultDelay);
        resultMenu.SetActive(true);
    }
    
}
