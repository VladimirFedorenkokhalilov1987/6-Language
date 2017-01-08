using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppConfig {

	public const int MenuScene=0;
	public const int WordScene=1;
	public const int EngScene=2;
	public const int RusScene=3;
	public const int ViewCollection=4;

	public const int MinButtonQuantity=1;
	public const int MaxButtonQuantity=4;



	public const string DataFolderName = @"\AppData\";
	public const string DataFileName = @"data.txt";

	public const string NoWord = "Collection is empty";
	public const string WordDeleted = "Слово удалено";
	public const string WordAdded = "Слово добавлено";
	public const string WrongAnswer = "Wrong answer";
	public const string RightAnswer= "Right answer";
}

public class Library:OverrodedOperators
{
	public List<Word> Dictionaryy {
		get;
		set;
	}
}

public class Word: OverrodedOperators
{
	public string Key {
		get;
		set;
	}

	public List<string> Translation {
		get;
		set;
	}
}

public class OverrodedOperators
{
	public static implicit operator bool (OverrodedOperators data)
	{
		return data !=null;
	}
}