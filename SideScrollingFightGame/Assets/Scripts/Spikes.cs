using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        PlayerControl player = collider.GetComponent<PlayerControl>();
        player.Dead = true;
    }
}
