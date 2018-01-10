using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

	[SerializeField] private Button _startGameButton;

	void Start()
	{
		_startGameButton.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(1);
		});
		
	}
}
