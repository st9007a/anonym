using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    private Ray _detector;
    private GameObject _aimedMachine = null;

	void Start () {
        _detector = new Ray(Camera.main.transform.position, transform.position - Camera.main.transform.position);    
	}
	
	void Update () {
        RaycastHit hit;

        //update ray origin and direction
        _detector.origin = Camera.main.transform.position;
        _detector.direction = transform.position - Camera.main.transform.position;

        //
        Debug.DrawRay(_detector.origin, _detector.direction * 15, Color.red);

        if (Physics.Raycast(_detector, out hit)) {
            if (_aimedMachine == null && hit.collider.tag == "Ray") {
                _aimedMachine = hit.collider.gameObject;
                _aimedMachine.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Aimed");
                
            }
        }
        else {
            if (_aimedMachine != null)
                _aimedMachine = null;
        }
	}
}
