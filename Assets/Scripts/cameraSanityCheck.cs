﻿using UnityEngine;
using System.Collections;

public class cameraSanityCheck : MonoBehaviour {

	public GameObject m_vrCamera;

	// Use this for initialization
	void Start () {
		// NOTE: This is obsolete in v5.4
		Debug.Log(UnityEngine.VR.VRSettings.loadedDevice);
	}
	
	// Update is called once per frame
	void Update () {
	        if (UnityEngine.VR.VRSettings.loadedDevice != UnityEngine.VR.VRDeviceType.None)
			// NOTE: The above is obsolete in v5.4
//			if (UnityEngine.VR.VRSettings.loadedDeviceName != "None")
			//if (m_vrCamera && m_vrCamera.activeSelf)
			{
				gameObject.SetActive(false);
		}
	}
}
