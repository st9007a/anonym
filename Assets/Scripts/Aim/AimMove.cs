using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour {

    public float PositionOffset = 0.375f;

    private Vector3 _nowMachinePos;
    private GameManager _manager;
    private GameObject _camera;

	void Start () {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _camera = GameObject.Find("Main Camera");

        if (_manager == null || _camera == null) {
            Debug.LogError("GameObject not found.");
            return;
        }

        _nowMachinePos = _manager.AllMachines[0].transform.position;
        transform.position = Vector3.Lerp(_nowMachinePos, _camera.transform.position, PositionOffset);
        
    }
	
	void Update () {

        if (Input.GetKeyDown("up"))
        {
            _nowMachinePos = GetNeighboringMachinePos(_nowMachinePos, Vector3.forward);
            transform.position = Vector3.Lerp(_nowMachinePos, _camera.transform.position, PositionOffset);
        }
        else if (Input.GetKeyDown("left"))
        {
            _nowMachinePos = GetNeighboringMachinePos(_nowMachinePos, Vector3.left);
            transform.position = Vector3.Lerp(_nowMachinePos, _camera.transform.position, PositionOffset);
        }
        else if (Input.GetKeyDown("down"))
        {
            _nowMachinePos = GetNeighboringMachinePos(_nowMachinePos, Vector3.back);
            transform.position = Vector3.Lerp(_nowMachinePos, _camera.transform.position, PositionOffset);
        }
        else if (Input.GetKeyDown("right"))
        {
            _nowMachinePos = GetNeighboringMachinePos(_nowMachinePos, Vector3.right);
            transform.position = Vector3.Lerp(_nowMachinePos, _camera.transform.position, PositionOffset);
        }
		
	}

    Vector3 GetNeighboringMachinePos(Vector3 aimMachinePos, Vector3 dir)
    {
        Vector3 pos = _nowMachinePos;

        return pos;
    }
}
