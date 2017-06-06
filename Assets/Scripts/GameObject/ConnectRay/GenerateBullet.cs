using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullet : MonoBehaviour {

    public GameObject Bullet;
    public Vector3 End;
    public float Delay = 1.0f;
    public float BulletSpeed = 3;

    private float _countDown;

	void Start () {
        _countDown = Delay;
	}
	
	void Update () {
        _countDown -= Time.deltaTime;

        if (_countDown <= 0) {
            _countDown = Delay;

            GameObject bullet = Instantiate(Bullet);
            bullet.GetComponent<BulletMove>().Speed = BulletSpeed;
            bullet.GetComponent<BulletMove>().End = End - transform.position;
            bullet.transform.parent = transform;
            bullet.transform.localPosition = Vector3.zero;
            
            
        }
	}
}
