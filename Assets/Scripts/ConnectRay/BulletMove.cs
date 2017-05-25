using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public Vector3 End;
    public float Speed;

	void Start () {
        transform.localRotation = Quaternion.LookRotation(Vector3.up, End);
	}
	
	void Update () {

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, End, Time.deltaTime * Speed);

        if (transform.localPosition == End) {
            Destroy(gameObject);
        }
	}

    private float GetAngle(Vector2 from, Vector2 to) {
        return Vector2.Angle(from, to) * Mathf.Sign(Vector2.Dot(from, to));
    }
}
