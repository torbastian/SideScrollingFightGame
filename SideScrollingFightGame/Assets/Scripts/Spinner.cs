using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    public GameObject Disc;
    public float Speed;
    public float RotationSpeed;
    public float Timer;

    public bool Backwards = false;
    public float iTimer;
    public bool Spin = false;
    public Vector3 StartPos;

    // Use this for initialization
    void Start() {
        iTimer = Timer;
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (Spin) {
            iTimer -= Time.deltaTime;

            if (!Backwards) {
                Disc.transform.Rotate(-transform.forward * RotationSpeed * Time.deltaTime);
                transform.position += transform.up * Speed * Time.deltaTime;
            }
            else {
                Disc.transform.Rotate(transform.forward * RotationSpeed * Time.deltaTime);
                transform.position -= transform.up * Speed * Time.deltaTime;
            }

            if (iTimer < 0) {
                if (!Backwards) {
                    Debug.Log("Backwards");
                    Backwards = true;
                    iTimer = Timer;
                }
                else {
                    Spin = false;
                    iTimer = Timer;
                    Backwards = false;
                }
            }
        }
    }
}
