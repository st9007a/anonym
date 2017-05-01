using System.Collections;
using System.Collections.Generic;

public class Machine {

	public enum Display {
		Show,
		Hide,
		Forbidden,
	}

	public enum Status {
		Normal,
		Crash,
		PowerOff,
	}

	public int id { set; get; }
	public string name { set; get; }
	public Display display { set; get; }
	public Status status { set; get; }

	public Dictionary<int, Machine> connection = new Dictionary<int, Machine> ();

	public Machine () {
		id = 0;
		name = "Machine";
		display = Display.Show;
		status = Status.Normal;
	}

	public Machine (int id, string name, Display display, Status status) {
		this.id = id;
		this.name = name;
		this.display = display;
		this.status = status;
	}

	public void connect (int id, Machine m) {
		connection.Add (id, m);
	}

	public void disconnect (int id) {
		connection.Remove (id);
	}

	public void beConnected () {
		
	}

	public void beDisconnected () {
		
	}

}
