using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float mDistanceMagn;

	public float mXRotation;

	public float verticalOffset;

	void Awake () {
		mDistanceMagn = (transform.position - target.transform.position).magnitude;
		mXRotation = transform.rotation.eulerAngles.x;
		Debug.Log (mXRotation);
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = target.transform.position;
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y + verticalOffset, target.transform.position.z);
		//transform.position.x = target.transform.position.x;
		//transform.position.y = target.transform.position.y + 5;
		//transform.position.z = target.transform.position.z;
		transform.rotation = target.GetComponent<MainControls> ().GetMyRotation();
		transform.RotateAround (transform.position, transform.right, mXRotation);
		transform.position += transform.forward*-1 * mDistanceMagn;

	}



}
