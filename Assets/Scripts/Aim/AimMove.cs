using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour {

    public float PositionOffset = 0.375f;
    public float Speed;

    private GameManager _manager;

	void Start () {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
	
	void Update () {

        Vector3 hor = Input.GetAxis("Horizontal") * Camera.main.transform.right * Time.deltaTime * Speed;
        Vector3 ver = Input.GetAxis("Vertical") * Camera.main.transform.up * Time.deltaTime * Speed;

        transform.position += hor + ver;
        Vector3 aimScreenPos =  Camera.main.WorldToScreenPoint(transform.position);
        
        if (aimScreenPos.y > Screen.height || aimScreenPos.y < 0) {
            Camera.main.transform.position += ver;
        }
        if (aimScreenPos.x > Screen.width || aimScreenPos.x < 0) {
            Camera.main.transform.position += hor;
        }
	}
}
