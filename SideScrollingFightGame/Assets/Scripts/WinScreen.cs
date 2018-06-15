using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

    public int NextLevelIndex;

    public Text Level;
    public Text Deaths;
    private Canvas WinScreenUI;

    // Use this for initialization
    void Start() {
        Level.text = SceneManager.GetActiveScene().name;
        WinScreenUI = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update() {

        if (WinScreenUI.isActiveAndEnabled) {
            Deaths.text = GameObject.Find("Player").GetComponent<PlayerControl>().DeathCounter.ToString();
            if (Input.GetButtonDown("Jump"))
                SceneManager.LoadScene(NextLevelIndex, LoadSceneMode.Single);
        }
    }
}
