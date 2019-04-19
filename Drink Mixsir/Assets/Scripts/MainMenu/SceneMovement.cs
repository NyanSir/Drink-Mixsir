using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour {

	public Vector3 oriPlace;
    public Vector3 target;
    public float speed;
    public float t;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartMove() {
        StartCoroutine(Move());
    }

    private IEnumerator Move() {
        while (t < 1) {
            yield return new WaitForEndOfFrame();
            
            transform.position = Vector3.Lerp(oriPlace, target, t);
            t += speed * Time.deltaTime;
        }

        yield return new WaitForSeconds(0.5f);
        GameObject.Find("GameManager").GetComponent<SceneSwitch>().ChangeScene();

    }

}
