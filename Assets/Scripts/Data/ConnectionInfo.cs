using System.Collections;
using System.Collections.Generic;

public class ConnectionInfo {

    public enum Relative {
        Connect,  //green solid line
        Transfer, //green dashed line
        Defense,  //red solid line
        Power,    //yellow solid line
    }

    public int Id;
    public Relative ConnectType;
    public Machine Machine;

    public ConnectionInfo(int id, Relative connectType, Machine machine) {
        Id = id;
        ConnectType = connectType;
        Machine = machine;
    }

}
