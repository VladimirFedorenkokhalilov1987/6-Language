using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AnswerButtonComponent : MonoBehaviour {

	public Action<string> OnClic;

	private void OnClicHandler(string val)
	{
		if (OnClic != null)
			OnClic (val);
	}

	[SerializeField]
	private Text _text;

	public string Text
	{
		get{ 
			if (!_text)
				return null;
			return _text.text;
				
		}		
		set
		{ 
			if (_text)
				_text.text = value;
		}
	}

	public void OnButtonClic () {
		if (!_text)
			return;
		OnClicHandler (_text.text);
	}
}