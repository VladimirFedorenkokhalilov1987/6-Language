using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {

	[SerializeField]
	private Text _notificationText;

	[SerializeField]
	private Color _startColor;

	[SerializeField]
	private Color _endColor;

	[SerializeField]
	private float _speed;

	void Start () {
		if (_notificationText)
			_notificationText.enabled = false;


	}

	public void StartFade (string message) {
		if (!_notificationText)
			return;

		_notificationText.text = message;

		StopAllCoroutines ();
		StartCoroutine (StartEffect ());
	}
	
	private IEnumerator StartEffect()
	{
		_notificationText.enabled = true;
		_notificationText.color = _startColor;

		while (_notificationText.color!=_endColor) {
			_notificationText.color = Color.Lerp (_notificationText.color, _endColor, Time.deltaTime * _speed);
			yield return null;
		}
	}
}
