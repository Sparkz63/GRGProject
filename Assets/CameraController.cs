using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public 	float 		cameraVerticalSpeed = 1;
	public 	float 		cameraHorizontalSpeed = 1;
	public 	Vector3		upperLeftLimit;
	public 	Vector3		lowerRightLimit;
	
	public GameObject g;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 deltaPosition = new Vector3(cameraHorizontalSpeed * Input.GetAxis("Horizontal"), cameraVerticalSpeed * Input.GetAxis("Vertical"), 0f);
		transform.position = transform.position + deltaPosition;
		
		
	}
}
