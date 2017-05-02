using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    public GameObject ConnectLine;
    public GameObject DEBUG;

    public int Id;
    public string MachineName;

    private Dictionary<int, Machine> Connection = new Dictionary<int, Machine>();

    // Use this for initialization
    void Start() {
        if (DEBUG != null) {
            Connect(DEBUG);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Connect (GameObject machine) {
        Machine m = machine.GetComponent<Machine>();
        Connection.Add(m.Id, m);
        DrawConnectLine(machine);
    }

    void Disconnect (GameObject machine) {
        Machine m = machine.GetComponent<Machine>();
        Connection.Remove(m.Id);
        RemoveConnectLine(machine);
    }

    private void DrawConnectLine(GameObject machine) {
        GameObject line = Instantiate(ConnectLine);

        line.transform.parent = gameObject.transform;
        line.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, machine.transform.position);

        machine.transform.parent = line.transform;
    }

    private void RemoveConnectLine(GameObject machine) {
        Destroy(machine.transform.parent.gameObject);
    }
}
