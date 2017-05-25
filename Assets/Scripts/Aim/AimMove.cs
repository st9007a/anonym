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

        /*Vector3 hor = Input.GetAxis("Horizontal") * Camera.main.transform.right * Time.deltaTime * Speed;
        Vector3 ver = Input.GetAxis("Vertical") * Camera.main.transform.up * Time.deltaTime * Speed;

        //move aim
        transform.position += hor + ver;
        transform.position = new Vector3(transform.position.x, 3, transform.position.z);

        //move camera if aim is out of screen;
        Vector3 aimScreenPos =  Camera.main.WorldToScreenPoint(transform.position);
        
        if (aimScreenPos.y > Screen.height || aimScreenPos.y < 0) {
            Camera.main.transform.position += ver;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 8, Camera.main.transform.position.z);
        }
        if (aimScreenPos.x > Screen.width || aimScreenPos.x < 0) {
            Camera.main.transform.position += hor;
        }*/

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
        else if (Input.GetKeyDown("up")) {
            Move(Direction.Up);
        }
	}

    public void Aim(GameObject machine) {
        _aimMachinePos = machine.transform.position;
        transform.position = Vector3.Lerp(machine.transform.position, Camera.main.transform.position, PositionOffset);
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
