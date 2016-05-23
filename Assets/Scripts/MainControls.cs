using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainControls : MonoBehaviour {

	public float mForceMagnitude;
	public float mTurnDegree;
	public float mAnimationSpeedDivider;
	public float mTurnSpeed;

	public SpriteRenderer mPartner;
	public SpriteRenderer mTagAlong;

	public List<AudioClip> mLeftRowAudio;
	public List<AudioClip> mRightRowAudio;

	private Vector3 mDirection;
	private Quaternion mRotation;
	private Quaternion mRotateTo;
	private Animator mAnimator;

	// Use this for initialization
	void Awake () {
		mDirection = new Vector3 (0, 0, 0);
		mRotation = transform.rotation;
		mRotateTo = transform.rotation;
		mAnimator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RotateSelf ();
		transform.rotation = mRotation;
		mDirection.Set (0, 0, 0);

		if (GetComponent<Rigidbody> ().velocity.magnitude < 2f) {
			GetComponentInChildren<ParticleSystem> ().Stop ();

		} else {
			GetComponentInChildren<ParticleSystem> ().Play ();

		}
		Color c = transform.FindChild ("Ripples").GetComponent<SpriteRenderer> ().material.color;
		c.a = (GetComponent<Rigidbody> ().velocity.magnitude / 2f);
		transform.FindChild ("Ripples").GetComponent<SpriteRenderer> ().material.color = c;

		if (Input.GetKey (KeyCode.LeftArrow) && GetComponent<Rigidbody>().velocity.sqrMagnitude > 0.0001f) {
			mDirection += -transform.right * 0.33f;
			transform.rotation = Quaternion.Euler (mRotation.eulerAngles.x, mRotation.eulerAngles.y - mTurnDegree, mRotation.eulerAngles.z);
		}
		if (Input.GetKey (KeyCode.RightArrow) && GetComponent<Rigidbody>().velocity.sqrMagnitude > 0.0001f) {
			mDirection += transform.right * 0.33f;
			transform.rotation = Quaternion.Euler (mRotation.eulerAngles.x, mRotation.eulerAngles.y + mTurnDegree, mRotation.eulerAngles.z);
		}

		mDirection += transform.forward;
		mDirection.Normalize ();

		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			//these rotations look really gross
			this.GetComponent<Rigidbody> ().AddForce (mDirection * mForceMagnitude);

			if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || mAnimator.IsInTransition (0)) {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					//GetComponent<AudioSource> ().clip = GetLeftRowSound ();
					//GetComponent<AudioSource> ().Play ();
					AkSoundEngine.PostEvent ("Play_PaddleR", gameObject);
					mAnimator.SetTrigger ("LeftRow");
				} 
				else if (Input.GetKey (KeyCode.RightArrow)) {
					//GetComponent<AudioSource> ().clip = GetRightRowSound ();
					//GetComponent<AudioSource> ().Play ();
					AkSoundEngine.PostEvent ("Play_PaddleL", gameObject);
					mAnimator.SetTrigger ("RightRow");
				} 
				else {
					AkSoundEngine.PostEvent ("Play_PaddleF", gameObject);
					mAnimator.SetTrigger ("FrontRow");
					StartCoroutine (PlayRowForwardSound());
				}
			}

		}
			


		if (Input.GetKey (KeyCode.Z) && Input.GetKey (KeyCode.X) && Input.GetKey (KeyCode.Space)) {
			
			transform.FindChild ("dumpster").GetComponent<MeshRenderer> ().enabled = true;
			transform.FindChild ("Canoe").GetComponent<MeshRenderer> ().enabled = false;
		}
	
	}

	private AudioClip GetLeftRowSound()
	{
		return mLeftRowAudio[Random.Range(0,mLeftRowAudio.Count)];
	}

	private AudioClip GetRightRowSound()
	{
		return mLeftRowAudio[Random.Range(0,mRightRowAudio.Count)];
	}

	private IEnumerator PlayRowForwardSound()
	{
		AudioSource.PlayClipAtPoint (GetLeftRowSound (), transform.position);
		yield return new WaitForSeconds (0.4f);
		AudioSource.PlayClipAtPoint (GetRightRowSound (), transform.position);
	}
	public void RotateSelf()
	{
		mRotation = Quaternion.Slerp(mRotation, mRotateTo, mTurnSpeed * Time.time);
	}

	public void SetTagAlong(Sprite otherSprite)
	{
		mTagAlong.sprite = otherSprite;
	}

	public void SetPartner(Sprite otherSprite)
	{
		mPartner.sprite = otherSprite;
	}

	public void SetMyRotation(Quaternion other)
	{
		mRotateTo = other;
	}

	public Quaternion GetMyRotation()
	{
		return mRotation;
	}
}
