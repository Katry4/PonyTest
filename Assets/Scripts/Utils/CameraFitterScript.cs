using UnityEngine;
using System.Collections;

public class CameraFitterScript : MonoBehaviour {

    public SpriteRenderer field;

    const float targetAspect = 1920f / 1080f;
	// Use this for initialization
	void Start () {

        //all we need - is to whole field to be on the screen
        if (Camera.main.aspect < targetAspect)
        {
           Camera.main.orthographicSize = field.bounds.size.x * Screen.height / Screen.width * 0.5f;
        }
	}
}
