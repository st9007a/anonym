using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    public GameObject ConnectLine;
    public GameObject DEBUG;

    public int Id;
    public string MachineName;
    public ConnectionInfo.Relative ConnectType;

    private Dictionary<int, Machine> LinkTo = new Dictionary<int, Machine>();
    private Dictionary<int, ConnectionInfo> BeLinked = new Dictionary<int, ConnectionInfo>();

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
        LinkTo.Add(m.Id, m);
        m.BeConnected(Id, this, ConnectType);
        DrawConnectLine(machine);
    }

    void Disconnect (GameObject machine) {
        Machine m = machine.GetComponent<Machine>();
        LinkTo.Remove(m.Id);
        m.BeDisconnected(Id);
        RemoveConnectLine(machine);
    }

    public void BeConnected (int id, Machine machine, ConnectionInfo.Relative connectType = ConnectionInfo.Relative.Connect) {
        BeLinked.Add(id, new ConnectionInfo(id, connectType, machine));
    }

    public void BeDisconnected (int id) {
        BeLinked.Remove(id);
    }

    private void DrawConnectLine(GameObject machine) {
        GameObject line = Instantiate(ConnectLine);

        line.transform.parent = gameObject.transform;
        line.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, machine.transform.position);

        machine.transform.parent = line.transform;
    }

    private void RemoveConnectLine(GameObject machine) {
        GameObject line = machine.transform.parent.gameObject;
        machine.transform.parent = null;
        Destroy(line);
    }
}
