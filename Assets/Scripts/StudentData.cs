using UnityEngine;
using System.Collections;
using System;
using Pathfinding.Serialization.JsonFx;
using System.IO;
using System.Text;

[Serializable]
public class Student  {

	public string Name {
		get;
		set;
	}

	public string Surname {
		get;
		set;
	}

	public enum Orientation {
		Male,
		Famale
	}

	public Orientation Sex {
		get;
		set;
	}

	public override string ToString ()
	{
		return string.Format ("[StudentData: Name={0}, Surname={1}, \n Flag={2}, Sex={3}]", Name, Surname, Sex);
	}
}
public class StudentData : MonoBehaviour {

	void Start () 
	{

		var Students = new Student[5];

		Students [0] = new Student ();
		Students [1] = new Student ();
		Students [2] = new Student ();
		Students [3] = new Student ();
		Students [4] = new Student ();

		Students [0].Name = "Vasia";
		Students [0].Surname = "Vasiliev";
		Students [0].Sex = Student.Orientation.Male;

		Students [1].Name = "Olia";
		Students [1].Surname = "Oliinavina";
		Students [1].Sex = Student.Orientation.Famale;

		Students [2].Name = "Vanya";
		Students [2].Surname = "Vaniinin";
		Students [2].Sex = Student.Orientation.Male;

		Students [3].Name = "Jenin";
		Students [3].Surname = "Gabrielovas";
		Students [3].Sex = Student.Orientation.Famale;

		Students [4].Name = "Franklin";
		Students [4].Surname = "Bangamin";
		Students [4].Sex = Student.Orientation.Male;


	
				

		string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\Students";

		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
		}

		for (int i = 0; i < Students.Length; i++) {
			
			string pathTemp = path+@"\"+Students[i].Name+" "+Students[i].Surname+@"\";
			if (!Directory.Exists (pathTemp)) {
				Directory.CreateDirectory (pathTemp);
			}
			string pathFile = pathTemp+Students[i].Name+" "+Students[i].Surname+".txt";
			var data = JsonWriter.Serialize(Students[i]);
			var stream = new StreamWriter (pathFile);
			stream.Write (data);
			stream.Close ();
			//Debug.LogFormat("{0}", data.ToString());

		}




//		path += @"test.txt";
//
//		if(File.Exists(path)) Debug.LogFormat("{0} exist", path);
//
//
//				var stream = new StreamWriter (path);
//		
//				var tempVal = new TestDataIO{ Name = "Katia", Age = 19, Flag = true, Cash = 2.5f };
//		
//				string jsonViev = JsonWriter.Serialize (tempVal);
//		
//				stream.Write (jsonViev);
//				stream.Close ();

//		var stream = new StreamReader (path);
//		var result = stream.ReadToEnd();
//		stream.Close ();
		//Debug.LogFormat("{0}", result);

//		Debug.LogFormat("{0}", data.ToString());



	
	
	// Update is called once per frame
		}
}