using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour {

    enum Direction {
        Up,
        Down,
        Right,
        Left,
    }

    public float PositionOffset = 0.375f;
    public float Speed;

    private GameManager _manager;

	void Start () {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {

        Vector3 hor = Input.GetAxis("Horizontal") * Camera.main.transform.right * Time.deltaTime * Speed;
        Vector3 ver = Input.GetAxis("Vertical") * Camera.main.transform.up * Time.deltaTime * Speed;

        //move aim
        transform.position += hor + ver;
        transform.position = new Vector3(transform.position.x, 3, transform.position.z);

        //move camera if aim is out of screen;
        Vector3 aimScreenPos =  Camera.main.WorldToScreenPoint(transform.position);
        
        if (aimScreenPos.y > Screen.height || aimScreenPos.y < 0) {
            Camera.main.transform.position += ver;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 8, Camera.main.transform.position.z);
        }
        if (aimScreenPos.x > Screen.width || aimScreenPos.x < 0) {
            Camera.main.transform.position += hor;
        }
	}

    public void Aim() {

    }

    void Move(Direction dir)
    {

        _manager.AllMachines.FindAll(x => {
            return x.transform.position.y > transform.position.y;
         });
        
    }
}
