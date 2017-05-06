using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject MachineTemp;
    public List<GameObject> AllMachines { set; get; }

    private SystemStructure SystemInfo;

    void Awake () {
        SystemInfo = SystemStructure.CreateDefault();
        AllMachines = new List<GameObject>();
	}

    void Start() {
        CreateMachines();
        SetupConnect();
        StartConnect();
    }

    // Update is called once per frame
    void Update () {
	}

    private void CreateMachines() {
        int count = SystemInfo.Machines.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject machine = Instantiate(MachineTemp);
            machine.transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * 360 * i / count) * 3, 0, Mathf.Sin(Mathf.Deg2Rad * 360 * i / count) * 3);
            machine.GetComponent<Machine>().Info = SystemInfo.Machines[i];
            machine.GetComponent<Machine>().Init();
            AllMachines.Add(machine);
        }
    }

    private void SetupConnect() {
        int count = SystemInfo.Machines.Count;
        
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
        int count = SystemInfo.Machines.Count;
        for (int i = 0; i < count; i++)
        {
            AllMachines[i].GetComponent<Machine>().StartConnect();
        }
    }
}
