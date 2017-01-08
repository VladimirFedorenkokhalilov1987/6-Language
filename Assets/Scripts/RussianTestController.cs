using UnityEngine;
using System.Collections;

public class RussianTestController : TestController {

	protected override void SetNewTestWord () {
		if (!AppDataManager.Instance || AppDataManager.Instance.LibrarySize == 0)
			return;

		Word newWord = null;

		do {
			newWord = AppDataManager.Instance.Library.Dictionaryy.GetRandomItem ();
		} 
		while (newWord == _currentWord);

		_currentWord = newWord;

		if (!_currentWord)
			return;
		
		if (_word)
			_word.text = _currentWord.Translation.GetRandomItem();

		_answers.Clear ();

		foreach (var item in _answerButtons) {
			if (!item)
				continue;

			Word tempWord = null;

			do {
				tempWord = AppDataManager.Instance.Library.Dictionaryy.GetRandomItem ();
			} while (tempWord == _currentWord || _answers.Contains (tempWord.Key));

			if (!tempWord || tempWord.Translation.IsNullOrEmpty ())
				continue;
			
			item.Text = tempWord.Key;
			_answers.Add (item.Text);
		}

		var tempAnswer = _answerButtons.GetRandomItem ();
		if (tempAnswer)
			tempAnswer.Text = _currentWord.Key;
	}

	protected override void OnButtonClick(string val)
	{
		if (!_currentWord)	return;

		if(_currentWord.Translation.IsNullOrEmpty()) return;

		if (_currentWord.Key==val) {
			if (_fadeText)	_fadeText.StartFade (AppConfig.RightAnswer);
			SetNewTestWord ();
		} 
		else 
		{
			if (_fadeText)	_fadeText.StartFade (AppConfig.WrongAnswer);
		}
	}
	//"<color=red>(0)</color>"
}
