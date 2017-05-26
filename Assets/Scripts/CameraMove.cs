using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Vector3 OriginPos;
    public float MoveDuration;

    private Vector3 _aimMachinePos;
    private float _speed;
    private bool _isMoving;

    void Start () {
        OriginPos = transform.position;
	}

	void Update () {
        if (Input.GetKeyDown("tab") && !_isMoving) {
            Debug.Log("t");
        }

        transform.position = Vector3.MoveTowards(transform.position, _aimMachinePos + OriginPos, _speed * Time.deltaTime);

        if (transform.position == _aimMachinePos + OriginPos) {
            _isMoving = false;
        }
    }

    public void Move(Vector3 pos) {
        _aimMachinePos = pos;
        _speed = Vector3.Distance(transform.position, _aimMachinePos + OriginPos) / MoveDuration;
        _isMoving = true;

    }
}
