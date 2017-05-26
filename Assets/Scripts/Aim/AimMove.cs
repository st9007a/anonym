using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour {

    enum Direction {
        Up,
        Down,
        Right,
        Left,
    }

    public float PositionOffset = 0.375f;
    public float Speed;

    private GameManager _manager;
    private Vector3 _aimMachinePos;

	void Start () {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {
        if (Input.GetKeyDown("left"))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKeyDown("down"))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKeyDown("right"))
        {
            Move(Direction.Right);
        }
        else if (Input.GetKeyDown("up"))
        {
            Move(Direction.Up);
        }
	}

    public void Aim(GameObject machine =  null) {
        if (machine != null)
        {
            _aimMachinePos = machine.transform.position;
        }
        Camera.main.GetComponent<CameraMove>().Move(_aimMachinePos);
        transform.position = Vector3.Lerp(_aimMachinePos, _aimMachinePos + Camera.main.GetComponent<CameraMove>().Scale, PositionOffset);
        
    }

    void Move(Direction dir)
    {

        List<GameObject> moveTo = _manager.AllMachines.FindAll(x => {
            Vector3 relative = x.transform.position - _aimMachinePos;
            Vector3 mappingForwardAtXZ = (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z)).normalized;
            Vector3 mappingRightAtXZ = (new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z)).normalized;

            switch (dir) {
                case Direction.Up:
                    return Vector3.Dot(relative, mappingForwardAtXZ) > 1;
                case Direction.Down:
                    return Vector3.Dot(relative, mappingForwardAtXZ) < -1;
                case Direction.Left:
                    return Vector3.Dot(relative, mappingRightAtXZ) < -1;
                case Direction.Right:
                    return Vector3.Dot(relative, mappingRightAtXZ) > 1;
                default:
                    return false;
            }
         });

        int count = moveTo.Count;
        GameObject target = null;
        float distance = Mathf.Infinity;
        for (int i = 0; i < count; i++) {
            if (Vector3.Distance(transform.position, moveTo[i].transform.position) < distance) {
                target = moveTo[i];
                distance = Vector3.Distance(transform.position, target.transform.position);
            }
        }

        if (target != null) {
            Aim(target);
        }
        
    }
}
