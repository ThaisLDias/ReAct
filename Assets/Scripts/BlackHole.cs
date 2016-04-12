using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public float meta;
	private bool metaCol;



	void Start () {
		metaCol = false;

	}

	void Update() 
	{
		if (metaCol == true) {
			meta += 0.1f;
		}

		if (meta >= 100) {
			Debug.Log("Ganhou miseravi");
		}

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
       /* switch (col.name)
        {
            case "workButton":
			meta += 0.1f;
                break;*/
           /* case "sleepButton":
                break;*/
           /* case "studyButton":
			meta += 0.1f;
                break;*
            /*case "funButton":
                break;*/
       // }

		if (col.gameObject.tag == "StudyButton" || col.gameObject.tag == "WorkButton") {
			metaCol = true;
		}

		
	
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "StudyButton" || col.gameObject.tag == "WorkButton") {
			metaCol = false;
		}
	}


	}

