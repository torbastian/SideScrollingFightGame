using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private bool Stop;
    public bool MovingRight;
    public float Timer;
    public float StopTimer;
    public float Speed;

    private float iTimer;
    private Rigidbody2D PlayerRB;

    // Use this for initialization
    void Start() {
        iTimer = Timer;
    }

    // Update is called once per frame
    void FixedUpdate() {

        iTimer -= Time.deltaTime;

        if (iTimer < 0 && !Stop) {
            if (MovingRight)
                MovingRight = false;
            else
                MovingRight = true;

            Stop = true;
            iTimer = StopTimer;
        }

        if (Stop && iTimer < 0) {
            Stop = false;
            iTimer = Timer;
        }

        if (MovingRight && !Stop) {
            transform.position += transform.right * Speed * Time.deltaTime;
            if (PlayerRB != null)
                PlayerRB.transform.position += transform.right * Speed * Time.deltaTime;
        }
        else if (!MovingRight && !Stop) {
            transform.position -= transform.right * Speed * Time.deltaTime;
            if (PlayerRB != null)
                PlayerRB.transform.position -= transform.right * Speed * Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D Other) {
        PlayerRB = Other.attachedRigidbody;
    }

    void OnTriggerExit2D(Collider2D Other) {
        PlayerRB = null;
    }
}
