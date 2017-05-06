using System.Collections;
using System.Collections.Generic;

public class ConnectionInfo {

    public int Id;
    public MachineInfo.Function ConnectType;
    public Machine Machine;

    public ConnectionInfo(int id, MachineInfo.Function connectType, Machine machine) {
        Id = id;
        ConnectType = connectType;
        Machine = machine;
    }

}
