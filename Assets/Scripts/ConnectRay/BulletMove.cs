using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public Vector3 End;
    public float Speed;

	void Start () {
        Vector3 dir = End;

        transform.localRotation = Quaternion.LookRotation(Vector3.up, End);
            /*= Quaternion.Euler(
            GetAngle(new Vector2(1, 0), new Vector2(dir.y, dir.z)),
            GetAngle(new Vector2(0, 0), new Vector2(dir.x, dir.z)),
            GetAngle(new Vector2(0, 1), new Vector2(dir.x, dir.y))
        );*/
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
