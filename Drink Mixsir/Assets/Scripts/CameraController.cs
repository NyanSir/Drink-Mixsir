using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    public int cameraMoveSpeed = 10;//相机移动速度

    private float originalPosX;//相机初始的横坐标位置
    private float originalPosY;

    private Vector3 initPos;
    private Vector2 maxPos;

    public float moveRank = 1;//移动段数，例子：有两个boss就是可以移动一段距离

    public float moveDistance = 5;//每段移动的距离

    private float maxMoveDistance;
    [SerializeField]
    private bool isOnUI;

    public bool xAxisMovement;
    public bool yAxisMovement;
    
    private void Start() {
        originalPosX = transform.position.x;
        originalPosY = transform.position.y;

        initPos = transform.position;
        maxMoveDistance = moveRank * moveDistance;
        maxPos = new Vector2(initPos.x + maxMoveDistance, initPos.y + maxMoveDistance);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                isOnUI = true;
            } else {
                isOnUI = false;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            isOnUI = false;
        }
    }

    private void OnGUI() {
        
        if (!isOnUI && Event.current.type == EventType.MouseDrag) {
            
            float x;
            float y;
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            //限制x坐标移动
            if (transform.position.x >= maxPos.x && x < 0) {
                x = 0;
            } 
            else if (transform.position.x <= -maxPos.x && x > 0) {
                x = 0;
            }

            //限制y坐标移动
            if (transform.position.y >= maxPos.y && y < 0) {
                y = 0;
            } 
            else if (transform.position.y <= -maxPos.y && y > 0) {
                y = 0;
            }
            
            //Camera移动
            if (xAxisMovement && yAxisMovement) {
                transform.Translate(new Vector3(-x, -y, 0) * Time.deltaTime * cameraMoveSpeed);
            }
            else if (xAxisMovement) {
                transform.Translate(new Vector3(-x, 0, 0) * Time.deltaTime * cameraMoveSpeed);
            }
            else if (yAxisMovement) {
                transform.Translate(new Vector3(0, -y, 0) * Time.deltaTime * cameraMoveSpeed);
            }
            
            
        }

    }

    private void OnDrawGizmosSelected() {
        maxMoveDistance = moveRank * moveDistance;
        maxPos = new Vector2(initPos.x + maxMoveDistance, initPos.y + maxMoveDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(0, 0, 0), maxPos * 2);
    }

}
