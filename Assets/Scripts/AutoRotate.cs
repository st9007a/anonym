using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public enum Direction {
        X,
        Y,
        Z,
    };

    public float Speed = 120.0f;
    public Direction Axis;

    private Vector3 rotate;
    private float speed;

    void Start() {

        speed = Speed;

        switch (Axis) {
            case Direction.X:
                rotate = new Vector3(1, 0, 0);
                break;
            case Direction.Y:
                rotate = new Vector3(0, 1, 0);
                break;
            case Direction.Z:
                rotate = new Vector3(0, 0, 1);
                break;
            default:
                rotate = Vector3.right;
                break;
        }
    }

    void Update () {
        transform.Rotate(rotate * Time.deltaTime * speed);
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
