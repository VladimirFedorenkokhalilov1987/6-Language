using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	public void Back()
	{
		SceneManager.LoadScene (AppConfig.MenuScene);
	}

}
