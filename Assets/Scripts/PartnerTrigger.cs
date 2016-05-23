using UnityEngine;
using System.Collections;

public class PartnerTrigger : MonoBehaviour {

	public enum Relationship{Monogamy, Polyamory};
	public Relationship mRel;

	public Sprite mSinglePartner;
	public Sprite mSingleIcon;

	public Sprite mPartners;
	public Sprite mPolyIcon;

	private Sprite mReturn;
	void Awake () {

		SpriteRenderer mSRender = GetComponent<SpriteRenderer> ();

		switch(mRel)
		{
		case Relationship.Monogamy:
			mSRender.sprite = mSingleIcon;
			mReturn = mSinglePartner;
			break;
		case Relationship.Polyamory:
			mSRender.sprite = mPolyIcon;
			mReturn = mPartners;
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
			temp.SetPartner (mReturn);
		}
	}
}
