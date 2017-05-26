using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Vector3 Scale;
    public float MoveDuration;

    private Vector3 _aimMachinePos;
    private float _speed;

    private Vector3[] _scaleOption = new Vector3[3];
    private int _scaleStage;

    void Awake () {

        for (int i = 1; i <= _scaleOption.Length; i++) {
            _scaleOption[i - 1] = new Vector3(0, 4, 3) * i;
        }

        Scale = _scaleOption[_scaleStage = 1];
	}

	void Update () {
        if (Input.GetKeyDown("tab"))
        {
            Scale = _scaleOption[_scaleStage = (_scaleStage + 1) % 3];
            GameObject.Find("Aim(Clone)").GetComponent<AimMove>().Aim();
        }
           
        transform.position = Vector3.MoveTowards(transform.position, _aimMachinePos + Scale, _speed * Time.deltaTime);            

    }

    public void Move(Vector3 pos) {
        _aimMachinePos = pos;
        _speed = Vector3.Distance(transform.position, _aimMachinePos + Scale) / MoveDuration;
    }
}
