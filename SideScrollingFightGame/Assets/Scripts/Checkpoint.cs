using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public bool Activated;
    public bool Finish = false;

    private SpriteRenderer SR;

    public Sprite ActivatedCheckpoint;

    // Use this for initialization
    void Start() {
        SR = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!Activated) {
            PlayerControl player = collider.GetComponent<PlayerControl>();
            player.SpawnPos = new Vector2(transform.position.x, transform.position.y - 1f);

            SR.sprite = ActivatedCheckpoint;
            Activated = true;

            if (Finish) {
                GameObject.Find("WinScreen").GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
