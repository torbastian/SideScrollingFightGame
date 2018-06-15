using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform PortalExit;
    private bool IgnoreExit;

    void OnTriggerEnter2D(Collider2D Other) {
        PlayerControl player = Other.GetComponent<PlayerControl>();
        if (!player.IgnorePortal) {
            Camera Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            IgnoreExit = true;
            player.IgnorePortal = true;
            Other.transform.position = PortalExit.position;
            Cam.transform.position = player.transform.position;
            TrailRenderer PlayerTR = Other.GetComponent<TrailRenderer>();
            PlayerTR.Clear();
        }
    }

    void OnTriggerExit2D(Collider2D Other) {
        if (!IgnoreExit) {
            PlayerControl player = Other.GetComponent<PlayerControl>();
            player.IgnorePortal = false;
        }
        else
            IgnoreExit = false;
    }
}
