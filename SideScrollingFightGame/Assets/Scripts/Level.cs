using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    public Button Play;
    public int LevelToLoadIndex;

	// Use this for initialization
	void Start () {
        Play.onClick.AddListener(vPlay);
	}
	
    void vPlay() {
        SceneManager.LoadScene(LevelToLoadIndex, LoadSceneMode.Single);
    }
}
