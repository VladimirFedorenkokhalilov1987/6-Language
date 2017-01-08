using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour {
	[SerializeField]
	private Button _wordButton;

	[SerializeField]
	private Button _engTestButton;

	[SerializeField]
	private Button _rusButton;

	[SerializeField]
	private Button _viewCollection;

	[SerializeField]
	private Text _wordsQuantity;

	// Use this for initialization
	void Start () {
		if (_wordButton)
			_wordButton.onClick.AddListener (LoadWordScene);

		if (_engTestButton)
			_engTestButton.onClick.AddListener (LoadEngTestScene);

		if (_rusButton)
			_rusButton.onClick.AddListener (LoadRusTestScene);

		if (_viewCollection)
			_viewCollection.onClick.AddListener (LoadViewCollectionScene);

		if (_wordsQuantity) {
			if (AppDataManager.Instance != null) {
				_wordsQuantity.text = AppDataManager.Instance.LibrarySize.ToString ();
			}
		}
	}


	private void LoadWordScene()
	{
		SceneManager.LoadScene (AppConfig.WordScene);
	}

	private void LoadEngTestScene()
	{
		SceneManager.LoadScene (AppConfig.EngScene);
	}

	private void LoadViewCollectionScene()
	{
		SceneManager.LoadScene (AppConfig.ViewCollection);
		print ("hj");
	}


	private void LoadRusTestScene()
	{
		SceneManager.LoadScene (AppConfig.RusScene);
	}
	// Update is called once per frame
	void OnDestroy () {
		if (_wordButton)
		_wordButton.onClick.RemoveListener (LoadWordScene);

		if (_engTestButton)
			_engTestButton.onClick.RemoveListener (LoadEngTestScene);

		if (_viewCollection)
			_rusButton.onClick.RemoveListener (LoadViewCollectionScene);

		if (_rusButton)
			_rusButton.onClick.RemoveListener (LoadRusTestScene);
	}
}
