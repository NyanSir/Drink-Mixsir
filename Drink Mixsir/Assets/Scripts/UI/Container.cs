using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour {

    public Collectable[] innerCollects = new Collectable[5];
    public GameObject[] inners = new GameObject[5];
    public GameObject innerPrefab;

    [SerializeField]
    protected int countInContainer = 0;
    
	// Use this for initialization
	protected virtual void Start () {
        
        int index = 0;
        foreach (GameObject inner in inners) {
            inners[index] = Instantiate(innerPrefab, transform.position, Quaternion.identity);
            inners[index].transform.SetParent(gameObject.transform);
            inners[index].GetComponent<Inner>().Remove += Remove;
            index++;
        }
    
        /*
        int index = 0;
        foreach (GameObject inner in inners) {
            inners[index] = transform.GetChild(index).gameObject;
            index++;
        }
        */
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //放到容器内
    public virtual void PutIn(Collectable c) {
        
        //容器未满则放入，满则提示
        if (countInContainer < innerCollects.Length) {
            
            int index = 0;
            foreach (Collectable collect in innerCollects) {
                //发现空的innerCollerct[]，放入参数
                if (collect == null) {
                    innerCollects[index] = c;
                    countInContainer++;
                    SpawnInner(c, index);
                    break;
                }
                index++;
            }

        }
        else {
            Debug.Log("Container is full!!");
        }

    }

    //产生Inner物体
    public virtual void SpawnInner(Collectable c, int index) {
        inners[index].SetActive(true);
        inners[index].transform.position = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 10 , 0);
        inners[index].GetComponent<Image>().sprite = c.GetSprite();
    }

    public virtual void Remove(Inner i) {
        
        int index = 0;
        foreach (GameObject inner in inners) {
            if (i.gameObject.Equals(inner)) {
                inners[index].SetActive(false);
                innerCollects[index] = null;
                countInContainer--;
                break;
            }
            index++;
        }

    }

    public virtual void EmptyContainer() {
        for (int i = 0; i < innerCollects.Length; i++) {
            Remove(inners[i].GetComponent<Inner>());
        }
        countInContainer = 0;
    }

}
