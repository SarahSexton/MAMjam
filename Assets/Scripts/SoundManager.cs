using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioClip mMainSoundLoop;

	public List<AudioClip> mWoodCreak;
	public List<AudioClip> mBirdSounds;

	private static List<AudioClip> _mWoodCreak;


	public AudioClip mRiverCalm;
	public AudioClip mRiverFast;
	public AudioClip mRiverRocky;



	// Use this for initialization
	void Awake () {

		GetComponent<AudioSource> ().loop = true;
		GetComponent<AudioSource> ().Play ();

		_mWoodCreak = new List<AudioClip> ();
		_mWoodCreak = mWoodCreak;

		StartCoroutine (RandomBirb ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void PlayWoodCreak(Vector3 pos)
	{
		if (_mWoodCreak.Count > 0)
			AudioSource.PlayClipAtPoint (_mWoodCreak [Random.Range (0, _mWoodCreak.Count)], pos);
	}

	void PlayBird()
	{
		Debug.Log ("BRAB");
		AudioSource.PlayClipAtPoint (mBirdSounds [Random.Range (0, mBirdSounds.Count)], transform.position);
	}

	IEnumerator RandomBirb()
	{
		yield return new WaitForSeconds(Random.Range(7, 20));
		PlayBird();
		yield return RandomBirb ();
	}
}
