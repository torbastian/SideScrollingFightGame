using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Player;

    public float Strength;

    private Vector3 Offset;

	// Use this for initialization
	void Start () {
        Offset = new Vector3(0, 0, transform.position.z);
        Vector3 NewPos = Player.transform.position;
        NewPos.z = Offset.z;
        transform.position = NewPos;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        Vector3 NewPos = Player.position + Offset;
        Vector3 SmoothPos = Vector3.Lerp(transform.position, NewPos, Strength * Time.deltaTime);
        SmoothPos.y = Player.position.y;
        transform.position = SmoothPos;
    }
}
