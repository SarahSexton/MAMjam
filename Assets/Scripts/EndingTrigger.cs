using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndingTrigger : MonoBehaviour {

	public GameObject myEndingPanel;
	public Sprite myEpilogueImage; 

	private GameObject m_Panel;
	// Use this for initialization
	void Awake()
	{
		m_Panel = myEndingPanel;
		GetComponent<MeshRenderer> ().enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		Time.timeScale = 0;
		m_Panel.GetComponent<Image> ().sprite = myEpilogueImage;
		Color m_color = m_Panel.GetComponent<Image> ().color;
		m_color.a = 1;
		m_Panel.GetComponent<Image> ().color = m_color;

	}
}
