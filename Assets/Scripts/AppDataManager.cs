using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using Pathfinding.Serialization.JsonFx;



public class AppDataManager : MonoBeheviurSingletoneBase<AppDataManager> {

	private Library _library;
	private string _fullPath;

	public Library Library {
		get
		{ 
			return _library;
		}
	}

	public int LibrarySize
	{
		get{ 
			if (!_library||_library.Dictionaryy==null)
				return 0;
			return _library.Dictionaryy.Count;

		}
	}

	protected override void Awake () {
		base.Awake ();
		DontDestroyOnLoad (this);
		_library = LoadData ();
	}

	private void OnDestroy()
	{
		SaveLibrary ();
	}

	public Word GetWord (int index)
	{
		if (!_library || _library.Dictionaryy == null)
			return null;

		if (index < 0 || index >= _library.Dictionaryy.Count)
			return null;

		return _library.Dictionaryy [index];
	}

	public void DeleteWord(int index)
	{
		if (!_library || _library.Dictionaryy == null || _library.Dictionaryy.Count==0)
			return;

		if (index < 0 || index >= _library.Dictionaryy.Count)
			throw new IndexOutOfRangeException(index.ToString());

		_library.Dictionaryy.RemoveAt (index);
	}

	private Library LoadData(){
		CheckDirectory ();

		_fullPath += AppConfig.DataFileName;

		if (!File.Exists (_fullPath)) {
			return null;
		}

		var stream = new StreamReader (_fullPath);
		var data = stream.ReadToEnd ();
		stream.Close ();
		return JsonReader.Deserialize<Library> (data);
	}

	public void AddWord(Word word)
	{
		if (!word)
			return;
		if (!_library) {
		
			_library = new Library ();
		}

		if (_library.Dictionaryy == null) {
			_library.Dictionaryy = new List<Word> ();
		}
		_library.Dictionaryy.Add (word);

		Debug.LogFormat("{0}","word served");

	}

	private void SaveLibrary()
	{
		string library = JsonWriter.Serialize (_library);

		var stream = new StreamWriter (_fullPath);
		stream.Write (library);
		stream.Close ();
	}
	private void CheckDirectory()
	{
		_fullPath = string.Format ("{0}{1}", Application.persistentDataPath, AppConfig.DataFolderName);
	
		if(!Directory.Exists(_fullPath))
			{
				Directory.CreateDirectory(_fullPath);
			}
		Debug.Log (_fullPath.ToString ());
	}
}
