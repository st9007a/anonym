using System.Collections;
using System.Collections.Generic;

public class MachineInfo {

    public enum Display {
        Show,
        Hide,
        Forbidden,
    }

    public enum Status {
        Normal,
        Crash,
    }

    public enum Function {
        Connect,
        Transfer,
        Power,
        Defense,
    }

    public int Id { set; get; }
    public string Name { set; get; }

    public Display DisplayType { set; get; }
    public Status MachineStatus { set; get; }
    public Function MachineFunc { set; get; }

    public List<MachineInfo> Connection = new List<MachineInfo>();

    public MachineInfo() {
        Name = "Default";
    }

    public MachineInfo(int Id, string Name) {
        this.Id = Id;
        this.Name = Name;
    }

    public void AddConnect(MachineInfo m) {
        Connection.Add(m);
    }

    public void RemoveConnect(int id) {
        MachineInfo m = Connection.Find(x => x.Id == id);
        Connection.Remove(m);
    }
}
