using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagment : MonoBehaviour {

	public AudioSource pass;


	public void LevelManager(string level)
	{
		SceneManager.LoadScene (level);
		pass.Play ();
	}
}
