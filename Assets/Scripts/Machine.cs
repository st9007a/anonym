using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    public GameObject ConnectLine;
    public List<GameObject> ConnectMachines { set; get; }
    public MachineInfo Info { set; get; }

    private Dictionary<int, Machine> LinkTo = new Dictionary<int, Machine>();
    private Dictionary<int, ConnectionInfo> BeLinked = new Dictionary<int, ConnectionInfo>();

    void Start() {
        
	}
	
	void Update () {
	}

    void Connect (GameObject machine) {
        Machine m = machine.GetComponent<Machine>();
        LinkTo.Add(m.Info.Id, m);
        m.BeConnected(Info.Id, this, Info.MachineFunc);
        DrawConnectLine(machine);
    }

    void Disconnect (GameObject machine) {
        Machine m = machine.GetComponent<Machine>();
        LinkTo.Remove(m.Info.Id);
        m.BeDisconnected(Info.Id);
        RemoveConnectLine(machine);
    }

    public void StartConnect() {
        for (int i = 0; i < ConnectMachines.Count; i++) {
            Connect(ConnectMachines[i]);
        }
        
    }

    public void Init() {
        ConnectMachines = new List<GameObject>();

        switch (Info.MachineFunc)
        {
            case MachineInfo.Function.Connect:
                ConnectLine = Resources.Load("Prefabs/ConnectLine") as GameObject;
                break;
            case MachineInfo.Function.Defense:
                ConnectLine = Resources.Load("Prefabs/DefenseLine") as GameObject;
                break;
            case MachineInfo.Function.Power:
                ConnectLine = Resources.Load("Prefabs/PowerLine") as GameObject;
                break;
            default:
                ConnectLine = Resources.Load("Prefabs/ConnectLine") as GameObject;
                break;
        }
    }

    public void BeConnected (int id, Machine machine, MachineInfo.Function connectType = MachineInfo.Function.Connect) {
        BeLinked.Add(id, new ConnectionInfo(id, connectType, machine));
    }

    public void BeDisconnected (int id) {
        BeLinked.Remove(id);
    }

    private void DrawConnectLine(GameObject machine) {
        GameObject line = Instantiate(ConnectLine);

        line.transform.parent = gameObject.transform;
        line.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, Vector3.Lerp(gameObject.transform.position, machine.transform.position, 0.2f));
        line.GetComponent<LineRenderer>().SetPosition(2, machine.transform.position);

        //machine.transform.parent = line.transform;
    }

    private void RemoveConnectLine(GameObject machine) {
        GameObject line = machine.transform.parent.gameObject;
        //machine.transform.parent = null;
        Destroy(line);
    }
}
