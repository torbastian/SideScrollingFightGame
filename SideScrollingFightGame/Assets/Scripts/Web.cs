using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour {

    public float WebStrength;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay2D(Collider2D Other) {
        Rigidbody2D Player = Other.GetComponent<Rigidbody2D>();
        Player.velocity = Player.velocity * WebStrength;
    }
}
