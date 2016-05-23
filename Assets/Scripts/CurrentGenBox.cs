using UnityEngine;
using System.Collections;

public class CurrentGenBox : MonoBehaviour {

	public enum Direction {North, East, West, South, NorthEast, NorthWest, SouthEast, SouthWest};

	public Direction mDir;

	public float mForceMagnitude;

	private Vector3 mDirVect;

	// Use this for initialization
	//Determines the direction vector upon startup based on chosen enumerator
	void Awake () {
		switch (mDir) {
		case Direction.North:
			mDirVect = transform.forward;
			break;
		case Direction.East:
			mDirVect = transform.right;
			break;
		case Direction.West:
			mDirVect = -transform.right;
			break;
		case Direction.South:
			mDirVect = -transform.forward;
			break;
		case Direction.NorthEast:
			mDirVect = transform.forward + transform.right;
			break;
		case Direction.NorthWest:
			mDirVect = transform.forward - transform.right;
			break;
		case Direction.SouthEast:
			mDirVect = -transform.forward + transform.right;
			break;
		case Direction.SouthWest:
			mDirVect = -transform.forward - transform.right;
			break;
		default:
			break;
		}
		mDirVect.Normalize();
	}
	
	// Update is called once per frame
	void Update () {

	//Used for live testing
	/*
switch (mDir) {
		case Direction.North:
			mDirVect = transform.forward;
			break;
		case Direction.East:
			mDirVect = transform.right;
			break;
		case Direction.West:
			mDirVect = -transform.right;
			break;
		case Direction.South:
			mDirVect = -transform.forward;
			break;
		case Direction.NorthEast:
			mDirVect = transform.forward + transform.right;
			break;
		case Direction.NorthWest:
			mDirVect = transform.forward - transform.right;
			break;
		case Direction.SouthEast:
			mDirVect = -transform.forward + transform.right;
			break;
		case Direction.SouthWest:
			mDirVect = -transform.forward - transform.right;
			break;
		default:
			break;
		}
		mDirVect.Normalize();
	*/
	}

	//adds a force in the direction determined
	//
	void OnTriggerStay(Collider other)
	{
		if(other.attachedRigidbody)
			other.attachedRigidbody.AddForce (mDirVect * mForceMagnitude);

	}
}
