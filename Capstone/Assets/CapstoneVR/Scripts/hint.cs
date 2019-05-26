using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{

	public void onHintClicked ()
	{
		Animation anim = this.GetComponent<Animation> ();
		anim.Play ();
	}

}