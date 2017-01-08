using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestController : MonoBehaviour {

	[SerializeField]
	protected Text _word;

	[SerializeField]
	private Transform _answerWrapper;

	[SerializeField]
	private AnswerButtonComponent _answerButtonPrefab;

	[SerializeField]
	protected FadeText _fadeText;

	protected AnswerButtonComponent[] _answerButtons;
	protected Word _currentWord;
	protected List<string> _answers = new List<string> ();

	void Start () {
		ConfigButtons ();
		SetNewTestWord ();
	}
	
	private void OnDestroy () {
		if (_answerButtons == null)
			return;
		foreach (var item in _answerButtons) {
			if (!item)
				continue;
			item.OnClic -= OnButtonClick;
		}
	}

	private void ConfigButtons()
	{
		if (!_answerButtonPrefab)
			return;

		if (!AppDataManager.Instance || AppDataManager.Instance.LibrarySize == 0) {
			if (_fadeText)
				_fadeText.StartFade (AppConfig.NoWord);
			return;
		}

		int buttonQantity = AppDataManager.Instance.LibrarySize;
		buttonQantity = Mathf.Clamp (buttonQantity, AppConfig.MinButtonQuantity, AppConfig.MaxButtonQuantity);

		_answerButtons = new AnswerButtonComponent[buttonQantity];

		for (int i = 0; i < _answerButtons.Length; i++) {
			var temp = _answerButtonPrefab.GetClone ();
			if (!temp)
				continue;
			temp.transform.SetParent (_answerWrapper, false);
			_answerButtons [i] = temp;
			temp.OnClic += OnButtonClick;
		}
	}

	protected virtual void OnButtonClick(string val)
	{
		if (!_currentWord)
			return;

		if(_currentWord.Translation.IsNullOrEmpty()) return;

		if (_currentWord.Translation.Contains (val)) {
			if (_fadeText)
				_fadeText.StartFade (AppConfig.RightAnswer);
				SetNewTestWord ();
		} else {
			if (_fadeText)
				_fadeText.StartFade (AppConfig.WrongAnswer);
		}
	}

	protected virtual void SetNewTestWord()
	{
		if (!AppDataManager.Instance || AppDataManager.Instance.LibrarySize == 0)
			return;
		
		Word newWord = _currentWord;

		while (newWord==_currentWord) {
			newWord = AppDataManager.Instance.Library.Dictionaryy.GetRandomItem ();
		}

		_currentWord = newWord;

		if (!_currentWord)
			return;

		if (_word)
			_word.text = _currentWord.Key;

		_answers.Clear ();

		foreach (var item in _answerButtons) {
			if (!item)
				continue;

			Word tempWord = _currentWord;

			while (tempWord == _currentWord || IsTranslateUsed (tempWord)) {
				tempWord = AppDataManager.Instance.Library.Dictionaryy.GetRandomItem ();
			}

			if (!tempWord || tempWord.Translation.IsNullOrEmpty ())
				continue;
			item.Text = tempWord.Translation.GetRandomItem ();
			_answers.Add (item.Text);
		}
			var tempAnswer = _answerButtons.GetRandomItem ();
			if (tempAnswer)
				tempAnswer.Text = _currentWord.Translation.GetRandomItem ();
		
	}

	 protected bool IsTranslateUsed(Word word)
	{
		if (word == null || word.Translation.IsNullOrEmpty ())
			return false;

		foreach (var translate in word.Translation) {
			if(_answers.Contains(translate))
			{
				return true;
			}
		}
		return false;
	}
}
