using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
	public bool isCorrect;
	Color32 liteGreen = new Color32 (128, 255, 128, 128);

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void changeBackground ()
	{

		Image image = GetComponent<Image> ();

		image.color = new Color32 (255, 128, 128, 128);
		if (isCorrect) {
			
			image.color = liteGreen;
		}

	}
}
