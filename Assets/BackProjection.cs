using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackProjection : MonoBehaviour {
	public GameObject cube;
	public float zPos=0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 mousePos = new Vector2 (Input.mousePosition.x / Screen.width, 1f-(Input.mousePosition.y / Screen.height));
		//Debug.Log (mousePos.ToString ());
		Vector3 projVec= Camera.main.ViewportToWorldPoint(new Vector3(0.4225324f,0.7808381f,zPos));
		Debug.Log (projVec.ToString ());
		cube.transform.position = projVec;
	}
//	void OnDrawGizmosSelected()
//	{
//		Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.4225324f,0.7808381f,  Camera.main.nearClipPlane));
//		Debug.Log (p.ToString ());
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawSphere(p, 0.1F);
//	}
}
