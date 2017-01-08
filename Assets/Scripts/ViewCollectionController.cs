using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ViewCollectionController : MonoBehaviour {

	[SerializeField]
	private GameObject _buttonsWrapper;

	[SerializeField]
	private Button _forwardButton;

	[SerializeField]
	private Button _backButton;

	[SerializeField]
	private Text _currentIndexText;

	[SerializeField]
	private Text _word;

	[SerializeField]
	private Text _translations;

	[SerializeField]
	private Button _delButton;

	[SerializeField]
	private Dropdown _dropdown;

	[SerializeField]
	private Button _deleteTranlations;

	private int _currentIndex;
	private int _totalIndex;
	//private int _selectedIndex;

	[SerializeField]
	private FadeText _fadeText;


	void Start () {
		if (_forwardButton)
			_forwardButton.onClick.AddListener (OnForwardClic);

		if (_forwardButton)
			_backButton.onClick.AddListener (OnBackwardClik);

		if (_delButton)
			_delButton.onClick.AddListener (DeleteWord);
	

		if (_deleteTranlations)
			_deleteTranlations.onClick.AddListener (OndeleteTranlations);

		if (AppDataManager.Instance) {
			if (_buttonsWrapper)
				_buttonsWrapper.SetActive (AppDataManager.Instance.LibrarySize > 1);
			if (_delButton)
				_delButton.gameObject.SetActive (AppDataManager.Instance.LibrarySize > 0);
			_totalIndex = AppDataManager.Instance.LibrarySize;

			UpdateCurrentIndex ();
		}
		if (_delButton){
			_delButton.onClick.AddListener (DeleteWord);

			if (_dropdown)
				_dropdown.onValueChanged.AddListener (OnDropDown);


	}
	}
	void OnDestroy () {
		if (_forwardButton)
			_forwardButton.onClick.RemoveListener (OnForwardClic);

		if (_backButton)
			_backButton.onClick.RemoveListener (OnBackwardClik);

			if (_delButton){
					_delButton.onClick.RemoveListener (DeleteWord);

			if (_dropdown)
				_dropdown.onValueChanged.RemoveListener (OnDropDown);

			if (_deleteTranlations)
				_deleteTranlations.onClick.RemoveListener (OndeleteTranlations);
	}
	}
	void OnForwardClic () {
		_currentIndex++;
		if (_currentIndex >= _totalIndex)
			_currentIndex = 0;
		UpdateCurrentIndex ();
		if (_dropdown)
			_dropdown.value = 0;
	}

	private void OndeleteTranlations ()
	{
		if (!_dropdown)
			return;
		var tempWord = AppDataManager.Instance.GetWord (_currentIndex);

		if (!tempWord)
			return;

		//if(_selectedIndex<0||_selectedIndex>=tempWord.Translation.Count) return;
		tempWord.Translation.RemoveAt (_dropdown.value);
		if (_dropdown)			_dropdown.options = tempWord.Translation.GetOptionData();


	}
	void OnBackwardClik () {
		_currentIndex--;
		if (_currentIndex < 0)
			_currentIndex = _totalIndex - 1;
		UpdateCurrentIndex ();
		if (_dropdown)
			_dropdown.value = 0;
	}

	void DeleteWord () {

			if(AppDataManager.Instance)
			{
				AppDataManager.Instance.DeleteWord(_currentIndex);
			}
		if (_fadeText)
			_fadeText.StartFade (AppConfig.WordDeleted);
			_totalIndex=AppDataManager.Instance.LibrarySize;

			if(_currentIndex==0) OnForwardClic();
			else OnBackwardClik();

		if (_buttonsWrapper)
			_buttonsWrapper.SetActive (AppDataManager.Instance.LibrarySize > 1);
	}

	private void OnDropDown(int index)
	{
		//Debug.LogFormat ("{0}", index);
	}

	void UpdateCurrentIndex () {
		if (_currentIndexText && AppDataManager.Instance) {
			_currentIndexText.text = AppDataManager.Instance.LibrarySize == 0 ? AppDataManager.Instance.LibrarySize.ToString () :
				(_currentIndex+1).ToString();
		}
		//	return;
		if (AppDataManager.Instance) {
			var word = AppDataManager.Instance.GetWord (_currentIndex);

			if (_word)
				_word.text = word ? word.Key : string.Empty;

			//if (_word)				_word.text = word.Key;

			if (_translations)		_translations.text = word ? word.Translation.GetTotalString ():string.Empty;
			var translations = word ? word.Translation.GetOptionData ():null;

			if (_buttonsWrapper)
				_buttonsWrapper.SetActive (AppDataManager.Instance.LibrarySize > 1);

			if (_delButton)
				_delButton.gameObject.SetActive (AppDataManager.Instance.LibrarySize > 0);
//			if (!translations)
//				return word.Translation.GetOptionData (); 
			if (_dropdown) {
				if (translations == null)
					_dropdown.ClearOptions ();
				else
				_dropdown.options = translations;
			
			}
			}		
	}
}
