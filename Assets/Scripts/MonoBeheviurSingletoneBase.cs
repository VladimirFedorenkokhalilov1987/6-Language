using UnityEngine;
using System.Collections;

public class MonoBeheviurSingletoneBase<T> : MonoBehaviour where T : Component {

	private static T _instance;

	public static T Instance
	{
		get{ 
			return _instance;
		}
	}

	protected virtual void Awake () {
		if (_instance == null) {
			_instance = this as T;
		} else {
			var res = GameObject.FindObjectsOfType<T> ();

			if (res == null)
				return;

			foreach (var item in res) {
				if (item == null || item == _instance)
					continue;
				Destroy (item.gameObject);
			}
		}
	}
}
