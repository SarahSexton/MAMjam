using UnityEngine;
using System.Collections;

public class TagAlongTrigger : MonoBehaviour {

	public enum TagAlong{Child, Cat, Plant};

	public TagAlong mTagAlong;

	public Sprite mChild1;
	public Sprite mChild2;
	public Sprite mChild3;
	public Sprite mChildIcon1;
	public Sprite mChildIcon2;
	public Sprite mChildIcon3;

	public Sprite mCat1;
	public Sprite mCat2;
	public Sprite mCat3;

	public Sprite mPlant1;
	public Sprite mPlant2;

	private Sprite mReturn;
	// Use this for initialization
	void Awake () {
		
		SpriteRenderer mSRender = GetComponent<SpriteRenderer> ();
		switch(mTagAlong)
		{
		case TagAlong.Child:
			mSRender.sprite = GetRandomChild ();
			break;
		case TagAlong.Cat:
			mSRender.sprite = GetRandomCat ();
			break;
		case TagAlong.Plant:
			mSRender.sprite = GetRandomPlant ();
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			MainControls temp = other.GetComponent<MainControls>();
			temp.SetTagAlong (mReturn);
		}
	}

	Sprite GetRandomChild()
	{
		int c = Random.Range (0, 3);
		switch (c) 
		{
		case 0:
			mReturn = mChild1;
			return mChildIcon1;

		case 1:
			mReturn = mChild2;
			return mChildIcon2;

		case 2:
			mReturn = mChild3;
			return mChildIcon3;

		default:
			mReturn = mChild1;
			return mChildIcon1;
		}
	}

	Sprite GetRandomCat()
	{
		int c = Random.Range (0, 3);
		switch (c) 
		{
		case 0:
			mReturn = mCat1;
			return mCat1;

		case 1:
			mReturn = mCat2;
			return mCat2;

		case 2:
			mReturn = mCat3;
			return mCat3;

		default:
			return mCat1;

		}

	}

	Sprite GetRandomPlant()
	{
		int c = Random.Range (0, 2);
		switch (c) 
		{
		case 0:
			mReturn = mPlant1;
			return mPlant1;

		case 1:
			mReturn = mPlant2;
			return mPlant2;

		default:
			mReturn = mPlant1;
			return mPlant1;

		}
	}
}
