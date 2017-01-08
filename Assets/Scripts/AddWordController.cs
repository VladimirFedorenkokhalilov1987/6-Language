using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.Collections.Generic;



public class AddWordController : MonoBehaviour {

	[SerializeField]
	private InputField _wordField;

	[SerializeField]
	private InputField _translField;

	[SerializeField]
	private Text _translates;

	[SerializeField]
	private GameObject _otherTranslatesVersion;

	[SerializeField]
	private Button _addTranslate;

	[SerializeField]
	private Button _addWordBtn;

	[SerializeField]
	private FadeText _fadeText;

	private Word _currWord;
	private StringBuilder _translations = new StringBuilder ();

	// Use this for initialization
	void Start () {
		if (_otherTranslatesVersion)
			_otherTranslatesVersion.SetActive (false);


		if (_addTranslate)
			_addTranslate.onClick.AddListener (AddTranslate);
		if (_addWordBtn)
			_addWordBtn.onClick.AddListener (AddWord);
	}

	private void OnDestroy()
	{
		if (_addTranslate)
			_addTranslate.onClick.RemoveListener (AddTranslate);
		if (_addWordBtn)
			_addWordBtn.onClick.RemoveListener (AddWord);

	}

	void AddWord () {
		if (string.IsNullOrEmpty (_wordField.text)) {
			Debug.LogFormat ("{0}","word field is empty");
			return;
		}

		AddTranslate ();

		if (!_currWord) {
			_currWord = new Word ();
			_currWord.Translation = new List<string> ();
			_currWord.Key = _wordField.text;
			if (!string.IsNullOrEmpty (_translField.text))
				_currWord.Translation.Add (_translField.text);
		}
			if(AppDataManager.Instance)
			{
				AppDataManager.Instance.AddWord(_currWord);
			if (_fadeText)
				_fadeText.StartFade (AppConfig.WordAdded);
			}

		_currWord = new Word ();
		_currWord.Translation = new List<string> ();

			_wordField.text = string.Empty;
			if (_otherTranslatesVersion)
				_otherTranslatesVersion.SetActive (false);
			_translField.text = string.Empty;

			Debug.LogFormat("{0}","слово было добавлено");
	}

	void AddTranslate () {
		if (string.IsNullOrEmpty (_wordField.text) || string.IsNullOrEmpty (_translField.text)) {
			Debug.LogFormat ("{0}", "word field is empty");
			return;
		}
		if (!_currWord) {
			_currWord = new Word ();
			_currWord.Translation = new List<string> ();
		}
		_currWord.Key = _wordField.text;
		_currWord.Translation.Add (_translField.text);
		if (_otherTranslatesVersion)
			_otherTranslatesVersion.SetActive (true);

		if (!_translates)
			return;

		_translations.Length = 0;

		foreach (var item in _currWord.Translation) {
			_translations.Append(string.Format(" {0}",item));
		}

		_translates.text=_translations.ToString();
		_translField.text=string.Empty;
	}
}
