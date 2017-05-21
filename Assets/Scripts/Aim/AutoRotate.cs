using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public float Speed = 120.0f;
    public Vector3 Axis;

    private Vector3 rotate;
    private float speed;

    void Start() {
        speed = Speed;
    }

    void Update () {
        transform.Rotate(Axis * Time.deltaTime * speed);
	}

    public void StopRotate() {
        speed = 0;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void ResetRotate() {
        speed = Speed;
    }
}
