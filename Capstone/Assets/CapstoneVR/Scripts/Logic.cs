using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Logic : MonoBehaviour
{
	
	public GameObject[] options;
	public GameObject[] questions;
	public AudioClip winingSound;
	public AudioClip losingSound;
	public GameObject losingCanvas;
	public GameObject[] points;
	public GameObject[] doors;
	public VideoPlayer videoPlayer;
	public GameObject quad;
	public GameObject escapeDoor;

	int[] answers = { 0, 2, 3 };
	public int RoomNumber;
	public bool lost = false;
	public int roomsSolved = 0;
	public GvrAudioSource src;
	int m_frameCounter = 0;
	float m_timeCounter = 0.0f;
	float m_lastFramerate = 0.0f;
	public float m_refreshTime = 0.5f;
	float deltaTime = 0.0f;

	void Start(){
		deltaTime = 0.0f;
	}
	void Update()
	{
//		if( m_timeCounter < m_refreshTime )
//		{
//			m_timeCounter += Time.deltaTime;
//			m_frameCounter++;
//		}
//		else
//		{
//			//This code will break if you set your m_refreshTime to 0, which makes no sense.
//			m_lastFramerate = (float)m_frameCounter/m_timeCounter;
//			m_frameCounter = 0;
//			m_timeCounter = 0.0f;
//		}
//		Debug.Log (m_lastFramerate);
		float fps = Mathf.FloorToInt(1.0f / deltaTime);

		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		Debug.Log (fps);
	}
	public void onOptionsClicked (int RoomNumber)
	{

		options [RoomNumber].SetActive (true);
		questions [RoomNumber].SetActive (false);
		this.RoomNumber = RoomNumber;
	}


	public void checkAnswer (int chosenAnswer)
	{

		if (answers [RoomNumber] == chosenAnswer) {
			
			src.clip = winingSound;
			roomsSolved += 1;
			if (RoomNumber == (questions.Length - 1)) {
				escapeDoor.GetComponent<Door> ().OnDoorClicked ();
			}

		} else {
			lost = true;
			src.clip = losingSound;
			src.Play ();
			StartCoroutine (showLosingScreen ());
			return;
		}
		src.Play ();
	}

	public void restartGame ()
	{
		SceneManager.LoadScene ("Map_Hosp1", LoadSceneMode.Single);
	}

	IEnumerator showLosingScreen ()
	{
		yield return new WaitForSeconds (src.clip.length);

		losingCanvas.transform.position = points [RoomNumber].transform.position;
		losingCanvas.transform.rotation = points [RoomNumber].transform.rotation;

		options [RoomNumber].SetActive (false);
		losingCanvas.SetActive (true);
	}

	public void onHintClicked ()
	{
		videoPlayer.Play ();
		quad.SetActive (true);
	}
}