using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecker : MonoBehaviour {

    public GameObject larva;

    public Transform[] points;

    public Transform locatePoint;

    public Transform target;

    [SerializeField]
    private bool isMove;

    [SerializeField]
    private bool isTouched;
    
    [SerializeField]
    private float t;

    private void Awake() {
        //locatePoint = points[0];
        //target = locatePoint;

        larva.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        GetComponent<Touchable>().TouchEvent += GiveLarva;
        
        //StartCoroutine(Stay());
    }
	
	// Update is called once per frame
	void Update () {
        //MoveTo(target);
    }

    private void GiveLarva() {

        if (!isMove) {
            larva.SetActive(true);
            //larva.transform.SetParent(GameObject.Find("Materials").transform);
            isTouched = true;

            //target = new GameObject().transform;
            //target.position = new Vector3(10, 0, 0);
            //isMove = true;

            GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
        
    }



    //Pecker movement
    public Transform ChoosePoint() {
        return points[(int)Random.Range(0, points.Length)];
    }

    public void MoveTo(Transform target) {
        
        //transform.Translate(target);

        if (isMove) {
            transform.position = Vector3.Lerp(locatePoint.position, target.position, t);
            t += Time.deltaTime;
        }
        
        if (t >= 1) {
            isMove = false;
            locatePoint = target;
            t = 0;
        }
    }

    public IEnumerator Stay() {
        while (!isTouched) {
            yield return new WaitForSeconds(Random.Range(5, 10));

            if (!isTouched) {
                target = ChoosePoint();
                isMove = true;
            }
                
        }
    }

}
