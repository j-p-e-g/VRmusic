using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour
{
	public AudioClip[] m_sounds;

	//[RequireComponent(AudioSource)]
	private AudioSource m_audio;
	private bool m_isHovered = false;

	// Use this for initialization
	void Start () {
		m_audio = GetComponent<AudioSource>();
    }

	// \start Debug VR hitting objects
	void OnMouseEnter()
	{
		Debug.Log("Start Mouseover for " + this.gameObject.name);
		m_isHovered = true;
	}

	void OnMouseExit()
	{
		Debug.Log("End Mouseover for " + this.gameObject.name);
		m_isHovered = false;
	}

	void Update ()
	{
		if (m_isHovered)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Debug.Log("Mouseclick");
				OnHitObject(0);
			}
		}
	}

	// \end Debug VR hitting objects

	void OnHitObject(int strength)
	{
		Debug.Log("OnHitObject " + this.gameObject.name);
		PlaySound(strength);
    }

	void PlaySound(int type)
	{
		Debug.Log("PlaySound");
		if (type < m_sounds.Length)
		{
			m_audio.clip = m_sounds[type];
			m_audio.Play();
		}
	}
}
