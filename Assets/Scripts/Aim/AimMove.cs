using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour {

	void Start () {
        GameObject manager = GameObject.Find("GameManager");
        GameObject mainCamera = GameObject.Find("Main Camera");
        if (manager == null || mainCamera == null) {
            Debug.LogError("GameObject not found.");
            return;
        }

        transform.position = Vector3.Lerp(manager.GetComponent<GameManager>().AllMachines[0].transform.position, mainCamera.transform.position, 0.375f);
	}
	
	void Update () {

        if (Input.GetKeyDown("up"))
        {
        }
        else if (Input.GetKeyDown("left"))
        {

        }
        else if (Input.GetKeyDown("down"))
        {

        }
        else if (Input.GetKeyDown("right"))
        {

        }
		
	}
}
