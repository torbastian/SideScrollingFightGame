using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    public Button MainMenu;
    public Button Quit;

    private bool Up = false;
    private Vector3 StartPos;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Screen.width * 0.5f, Screen.height * -1.2f, 0f);
        StartPos = transform.position;
        MainMenu.onClick.AddListener(vMainMenu);
        Quit.onClick.AddListener(vQuit);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!Up) {
                transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
                Up = true;
            }
            else {
                transform.position = StartPos;
                Up = false;
            }
        }
	}

    void vMainMenu() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void vQuit() {
        Application.Quit();
    }
}
