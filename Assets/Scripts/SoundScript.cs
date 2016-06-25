using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundScript : MonoBehaviour
{
	public AudioClip[] m_audioClips;

	private AudioSource m_audioSource;
	private bool m_isHovered = false;
	private float m_velocityMultiplier = 1.2f;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource>();
	}

	// \start Debug VR hitting objects
	void OnMouseEnter()
	{
		//Debug.Log("Start Mouseover for " + this.gameObject.name);
		m_isHovered = true;
	}

	void OnMouseExit()
	{
		//Debug.Log("End Mouseover for " + this.gameObject.name);
		m_isHovered = false;
	}

	void Update ()
	{
		if (m_isHovered)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				//Debug.Log("Mouseclick");
				OnHitObject(0);
			}
		}
	}

	// \end Debug VR hitting objects
	void OnTriggerEnter(Collider other)
	{
		Transform parent = other.transform.parent;
		if (parent)
		{
			SteamVR_TrackedObject controller = parent.gameObject.GetComponent<SteamVR_TrackedObject>();
			if( controller )
			{
				Vector3 velocity = SteamVR_Controller.Input( (int)controller.index ).velocity;
				Debug.Log( "hit velocity: " + velocity.x + ", " + velocity.y + ", " + velocity.z );
				int strength = (int)( velocity.magnitude * m_velocityMultiplier);
				Debug.Log( "sound strength: " + strength );
				OnHitObject( strength >= m_audioClips.Length ? m_audioClips.Length - 1 : strength );
			}
		}
		else
		{
			OnHitObject(0);
		}
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
		if (type < m_audioClips.Length)
		{
			AudioSource.PlayClipAtPoint(m_audioClips[type], this.transform.position);
			//m_audioSource.PlayOneShot(m_audioClips[type]);
		}
	}
}
