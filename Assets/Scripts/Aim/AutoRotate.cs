using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public float InitialSpeed = 120.0f;
    public Vector3 Axis;

    private float _speed;

    void Start() {
        _speed = InitialSpeed;
    }

    void Update () {
        transform.Rotate(Axis * Time.deltaTime * _speed);
	}

    public void StopRotate() {
        _speed = 0;
    }

    public void setSpeed(float speed) {
        _speed = speed;
    }

    public void ResetRotate() {
        _speed = InitialSpeed;
    }
}
