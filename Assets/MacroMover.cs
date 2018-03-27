using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroMover : MonoBehaviour {

	public GameObject topDownCam;
	public GameObject player;
	public GameObject la_Start;
	public GameObject la_End;
	public GameObject ny_Start;
	public GameObject ny_End;
	private GameObject startObj;
	private GameObject endObj;

	// Use this for initialization
	void Start () {
		SwitchToTopDown (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			StartCoroutine ("StartEncoding");
		}
		
	}

	public void SelectTarget(string targetCity)
	{
		
		switch (targetCity) {
		case "LA":
			startObj = la_Start;
			endObj = la_End;
			break;
		case "NY":
			startObj = ny_Start;
			endObj = ny_End;
			break;
		}
		StartCoroutine ("StartEncoding");
	}

	IEnumerator StartEncoding()
	{

		SwitchToTopDown (false);

		//drop from sky to a city
		yield return StartCoroutine (BeginLerping (player, startObj,endObj));

		//wait for 2 seconds
		yield return new WaitForSeconds(2f);

		//drive from city start to city end and spawn an object at a random location in between
		yield return StartCoroutine (BeginLerping (player, endObj,true));

		yield return new WaitForSeconds (2f);

		yield return StartCoroutine (BeginLerping (player, topDownCam, topDownCam));


		SwitchToTopDown (true);
		yield return null;

	}

	public void SwitchToTopDown(bool isTopDown)
	{
			
			topDownCam.SetActive(isTopDown);
			player.SetActive (!isTopDown);
	}

	IEnumerator AdjustView(GameObject origObj, GameObject targetObj)
	{
		Quaternion origRot = origObj.transform.rotation;
		Quaternion targetRot = targetObj.transform.rotation;

		float timer = 0f;
		while (timer < 3f) {
			timer += Time.deltaTime;
			origObj.transform.rotation = Quaternion.Slerp (origRot, targetRot, timer / 3f);
			yield return 0;
		}
		yield return null;
	}
	IEnumerator BeginLerping(GameObject playerObj, GameObject targetObj,bool shouldSpawn)
	{
		Vector3 playerStartPos = playerObj.transform.position;
		//		playerObj.transform.LookAt (targetObj.transform);-
		float timer = 0f;
		float factor = 0f;

		while (timer < 10f) {
			timer += Time.deltaTime;
			factor = timer / 10f;
			playerObj.transform.position = Vector3.Lerp (playerStartPos, targetObj.transform.position, factor);
			yield return 0;
		}
		yield return null;
	}
	IEnumerator BeginLerping(GameObject playerObj, GameObject targetObj,GameObject endObj)
	{
		Quaternion origRot = playerObj.transform.rotation;
		Quaternion targetRot = endObj.transform.rotation;
		Vector3 playerStartPos = playerObj.transform.position;
//		playerObj.transform.LookAt (targetObj.transform);
		float timer = 0f;
		float factor = 0f;
		while (timer < 10f) {
			timer += Time.deltaTime;
			factor = timer / 10f;
			playerObj.transform.position = Vector3.Lerp (playerStartPos, targetObj.transform.position, factor);
			playerObj.transform.rotation = Quaternion.Slerp (origRot, targetRot, factor);
			yield return 0;
		}
		yield return null;
	}
}
