using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour {

    public float CrushTime;
    public float MovementAmount;
    public float Strength;
    public float DelayTime;

    public bool Delay = true;
    public bool MovingDown = false;
    public bool Move = false;
    public float iCrushTime;
    public Vector2 Origin;
    public Vector2 NewPos;

    // Use this for initialization
    void Start() {
        iCrushTime = CrushTime;
        Origin = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if(Delay) {
            DelayTime -= Time.deltaTime;
            if (DelayTime < 0)
                Delay = false;
        }

        if (!Delay) {
            if (!Move) {
                iCrushTime -= Time.deltaTime;
                if (iCrushTime < 0) {
                    NewPos = transform.position + transform.up * MovementAmount;
                    iCrushTime = CrushTime / 2;
                    Move = true;
                }
            }

            if (Move) {
                iCrushTime -= Time.deltaTime;
                transform.position = Vector2.Lerp(transform.position, NewPos, Strength * Time.deltaTime);

                if (iCrushTime < 0) {
                    if (!MovingDown) {
                        NewPos = Origin;
                        iCrushTime = CrushTime;
                        MovingDown = true;
                    }
                    else {
                        iCrushTime = CrushTime;
                        MovingDown = false;
                        Move = false;
                    }
                }
            }
        }
    }
}
