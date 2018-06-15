using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button Back;
    public MainMenu MM;

    public float TransitionStrength;
    public bool MenuTransition;

    private Camera Cam;
    private float Timer = 1f;
    private float iTimer;

	// Use this for initialization
	void Start () {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Back.onClick.AddListener(vBack);
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuTransition) {
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, new Vector3(0, 0, -10), TransitionStrength);
            iTimer -= Time.deltaTime;
            if (iTimer < 0)
                MenuTransition = false;
        }
	}

    void vBack() {
        MenuTransition = true;
        iTimer = Timer;
        MM.MenuTransition = false;
    }
}
