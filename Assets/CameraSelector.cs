using UnityEngine;
using System.Collections;

public class CameraSelector : MonoBehaviour {

    public GameObject[] vrGameObjects;
    public GameObject[] debugGameObjects;

	void Start () {
        GameObject[] objects = UnityEngine.VR.VRDevice.isPresent ? vrGameObjects : debugGameObjects;
        foreach(var go in objects)
        {
            go.SetActive(true);
        }
	}
	
}
