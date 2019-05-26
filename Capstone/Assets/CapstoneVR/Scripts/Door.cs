using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	bool locked = true;
	public AudioClip bgClip;
	public GameObject door;
	public GameObject gameLogic;
	public int doorNumber;
	public GameObject noEntry;
	public GvrAudioSource src;


	public void OnDoorClicked ()
	{
		Animation anim = door.GetComponent<Animation> ();
		Logic logic = gameLogic.GetComponent<Logic> ();

		if (logic.roomsSolved < 2 && doorNumber == 3) {
			noEntry.SetActive (true);
			return;
		}
		if (locked && !logic.lost) {
			
			GetComponent<BoxCollider> ().enabled = false;
			locked = false;

			src.Play ();
			anim.Play ();
			StartCoroutine(ExecuteAfterTime(2));
		}


	}

	IEnumerator ExecuteAfterTime (float time)
	{
		yield return new WaitForSeconds (time);

		src.clip = bgClip;
		src.Play ();


	}
    
}