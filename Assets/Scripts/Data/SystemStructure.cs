using System.Collections;
using System.Collections.Generic;

public class SystemStructure {

    public List<MachineInfo> Machines = new List<MachineInfo>();

    public static SystemStructure CreateDefault() {
        SystemStructure sys = new SystemStructure();

        MachineInfo m1 = new MachineInfo(0, "Computer 1");
        m1.MachineFunc = MachineInfo.Function.Defense;
        m1.PosX = 0;
        m1.PosZ = 0;

        MachineInfo m2 = new MachineInfo(1, "Computer 2");
        m2.PosX = 5;
        m2.PosZ = 5;

        MachineInfo m3 = new MachineInfo(2, "Computer 3");
        m3.MachineFunc = MachineInfo.Function.Power;
        m3.PosX = -5;
        m3.PosZ = 0;

        MachineInfo m4 = new MachineInfo(3, "Computer 4");;
        m4.PosX = 7;
        m4.PosZ = 0;


        MachineInfo m5 = new MachineInfo(4, "Computer 5");
        m5.PosX = 5;
        m5.PosZ = -5;

        m1.AddConnect(m2);
        m1.AddConnect(m4);
        m1.AddConnect(m5);

        m3.AddConnect(m1);

        m2.AddConnect(m4);
        m2.AddConnect(m5);

        sys.Machines.Add(m1);
        sys.Machines.Add(m2);
        sys.Machines.Add(m3);
        sys.Machines.Add(m4);
        sys.Machines.Add(m5);

        return sys;
    }

}
