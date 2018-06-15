using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

    public float SpringDistance;
    public float Strength;
    public float JumpTime;
    public float JumpForce;

    private bool Up;
    private float StartStrength;
    private float iJumpTime;
    private bool Spring = false;
    private Vector3 StartPos;
    private Vector3 NewPos;
    private Rigidbody2D PlayerRB;

    // Use this for initialization
    void Start() {
        StartPos = transform.position;
        iJumpTime = JumpTime;
        StartStrength = Strength;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Spring) {
            iJumpTime -= Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, NewPos, Strength * Time.deltaTime);

            if (iJumpTime < 0) {
                if (!Up) {
                    if (PlayerRB != null)
                        PlayerRB.AddForce(transform.up * JumpForce);

                    NewPos = StartPos;
                    Strength = 25;
                    iJumpTime = 0.1f;
                    Up = true;
                }
                else {
                    Up = false;
                    Spring = false;
                    Strength = StartStrength;
                    iJumpTime = JumpTime;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Other) {
        PlayerRB = Other.attachedRigidbody;
        Debug.Log(PlayerRB);
        if (!Spring) {
            NewPos = transform.position - transform.up * SpringDistance;
            Spring = true;
        }
    }

    void OnTriggerExit2D(Collider2D Other) {
        PlayerRB = null;
        Debug.Log(PlayerRB);
    }
}
