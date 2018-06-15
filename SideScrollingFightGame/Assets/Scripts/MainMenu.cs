using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public bool MenuTransition;
    public float TransitionStrength;
    public Button LevelSelect;
    public Button Quit;
    public LevelSelect LS;

    private Camera Cam;

    private float Timer = 1f;
    private float iTimer;

    // Use this for initialization
    void Start() {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        LevelSelect.onClick.AddListener(vLevelSelect);
        Quit.onClick.AddListener(vQuit);
    }

    // Update is called once per frame
    void Update() {
        if (MenuTransition) {
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, new Vector3(29.47f, 0, -10), TransitionStrength);
            iTimer -= Time.deltaTime;
            if (iTimer < 0)
                MenuTransition = false;
        }
    }

    void vLevelSelect() {
        iTimer = Timer;
        MenuTransition = true;
        LS.MenuTransition = false;
    }

    void vQuit() {
        Application.Quit();
    }
}
