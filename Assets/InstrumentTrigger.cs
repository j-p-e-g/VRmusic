using UnityEngine;
using System.Collections;

public class InstrumentTrigger : MonoBehaviour {

    public AudioClip[] audioClips;

    AudioSource m_audioSource;

	// Use this for initialization
	void Start () {
        m_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            m_audioSource.PlayOneShot(audioClips[0]);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
