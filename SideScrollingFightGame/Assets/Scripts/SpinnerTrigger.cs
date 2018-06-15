using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerTrigger : MonoBehaviour {

    public GameObject SpinnerCore;
    public Spinner Core;

	// Use this for initialization
	void Start () {
        Core = SpinnerCore.GetComponent<Spinner>();
	}

    void OnTriggerEnter2D(Collider2D Other) {
        Core.Spin = true;
    }
    
    void OnTriggerExit2D(Collider2D Other) {
        Core.Backwards = false;
        Core.Spin = false;
        Core.iTimer = Core.Timer;
        SpinnerCore.transform.position = Core.StartPos;
    }
}
