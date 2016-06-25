using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundScript : MonoBehaviour
{
	public AudioClip[] m_audioClips;

	private AudioSource m_audioSource;
	private bool m_isHovered = false;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource>();
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
	void OnTriggerEnter(Collider other)
	{
		OnHitObject(0);
	}

	void OnTriggerExit(Collider other)
	{
	}

	void OnHitObject(int strength)
	{
		Debug.Log("OnHitObject " + this.gameObject.name);
		PlaySound(strength);
    }

	void PlaySound(int type)
	{
		Debug.Log("PlaySound");
		if (type < m_audioClips.Length)
		{
			m_audioSource.clip = m_audioClips[type];
			m_audioSource.PlayOneShot(m_audioClips[type]);
		}
	}
}
