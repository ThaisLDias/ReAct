using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagment : MonoBehaviour {

	public void LevelManager(string level)
	{
		SceneManager.LoadScene (level);
	}
}
