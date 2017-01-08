using UnityEngine;
using System.Collections;
using System.IO;
using System;
using Pathfinding.Serialization.JsonFx;

public class TestDataIO
{
	public string Name {
		get;
		set;
	}

	public int Age {
		get;
		set;
	}

	public bool Flag {
		get;
		set;
	}

	public float Cash {
		get;
		set;
	}

	public override string ToString ()
	{
		return string.Format ("[TestDataIO: \n Name={0}, \n Age={1}, \n Flag={2},\n Cash={3}]", Name, Age, Flag,Cash);
	}
}

public class TestIO : MonoBehaviour {

	private string _folderName = @"\TestData\";

	void Start () {


		string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +_folderName;

		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
		}

		path += @"test.txt";

		if(File.Exists(path)) Debug.LogFormat("{0} exist", path);


//		var stream = new StreamWriter (path);
//
//		var tempVal = new TestDataIO{ Name = "Katia", Age = 19, Flag = true, Cash = 2.5f };
//
//		string jsonViev = JsonWriter.Serialize (tempVal);
//
//		stream.Write (jsonViev);
//		stream.Close ();

		var stream = new StreamReader (path);
		var result = stream.ReadToEnd();
		stream.Close ();
		//Debug.LogFormat("{0}", result);

		var data = JsonReader.Deserialize<TestDataIO> (result);
		Debug.LogFormat("{0}", data.ToString());

	}
	
	void Update () {
	
	}
}
