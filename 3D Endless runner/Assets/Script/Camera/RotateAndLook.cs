using UnityEngine;
using System.Collections;

public class RotateAndLook : MonoBehaviour {
	
	//This script is for camera in menu scene to rotate around the target
	public Transform target;
	public float speed = 10;
	
	
	void Update () {
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
		transform.LookAt(target.position);
	}
}
