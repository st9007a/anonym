using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject MachineTemp;
    public GameObject Aim;

    public List<GameObject> AllMachines { set; get; }

    private SystemStructure _systemInfo;

    void Awake () {
        _systemInfo = SystemStructure.CreateDefault();
        AllMachines = new List<GameObject>();
	}

    void Start() {
        CreateMachines();
        SetupConnect();
        StartConnect();

        TriggerScene();
    }

    // Update is called once per frame
    void Update () {
	}

    private void TriggerScene() {
        Instantiate(Aim);
    }

    private void CreateMachines() {
        int count = _systemInfo.Machines.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject machine = Instantiate(MachineTemp);
            machine.transform.position = new Vector3(_systemInfo.Machines[i].PosX, 0, _systemInfo.Machines[i].PosZ);
            machine.GetComponent<Machine>().Info = _systemInfo.Machines[i];
            machine.GetComponent<Machine>().Init();
            AllMachines.Add(machine);
        }
    }

    private void SetupConnect() {
        int count = _systemInfo.Machines.Count;
        
        for (int i = 0; i < count; i++)
        {
            List<GameObject> connect = new List<GameObject>();
            for (int j = 0; j < AllMachines[i].GetComponent<Machine>().Info.Connection.Count; j++)
            {
                connect.Add(AllMachines.Find(
                    x => x.GetComponent<Machine>().Info.Id == AllMachines[i].GetComponent<Machine>().Info.Connection[j].Id)
                );
            }
            AllMachines[i].GetComponent<Machine>().ConnectMachines = connect;
        }
    }

    private void StartConnect() {
        int count = _systemInfo.Machines.Count;
        for (int i = 0; i < count; i++)
        {
            AllMachines[i].GetComponent<Machine>().StartConnect();
        }
    }
}
