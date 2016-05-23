using UnityEngine;
using System.Collections;

public class TurnTrigger : MonoBehaviour {

	public enum Direction{Left, Right};
	public Direction mDirection;


	private Quaternion otherRotation;
	private Quaternion newRotation;
	private bool triggered;

	// Use this for initialization
	void Awake () {
		
		Color temp = GetComponent<MeshRenderer> ().material.color;
		temp.a = temp.a * 0.25f;
		GetComponent<MeshRenderer> ().material.color = temp;

		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (triggered || !other.CompareTag("Player"))
			return;
		
		otherRotation = other.GetComponent<MainControls> ().GetMyRotation();

		switch (mDirection) {
		case Direction.Left:
			newRotation = otherRotation * Quaternion.Euler (0, -90, 0);
			break;
		case Direction.Right:
			newRotation = otherRotation * Quaternion.Euler (0, 90, 0);
			break;
		default:
			newRotation = otherRotation;
			break;
		}

		other.GetComponent<MainControls> ().SetMyRotation (newRotation);

		triggered = true;

	}
		
}
