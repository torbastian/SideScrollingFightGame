using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour {

    public float FallTimer;
    public float Speed;
    public float RayLength;
    public LayerMask Ground;

    private float iFallTimer;
    private Vector3 StartPos;
    private ParticleSystem Particles;

	// Use this for initialization
	void Start () {
        Particles = gameObject.GetComponent<ParticleSystem>();
        iFallTimer = FallTimer;
        StartPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        iFallTimer -= Time.deltaTime;
        if (iFallTimer < 0) {
            transform.Translate(-Vector2.up * Speed * Time.fixedDeltaTime);
        }

        RaycastHit2D GroundHit = Physics2D.Raycast(transform.position, -transform.up, RayLength, Ground);
        Debug.DrawRay(transform.position, -transform.up * RayLength);

        if (GroundHit.collider != null) {
            iFallTimer = FallTimer;
            Particles.Play();
            transform.position = StartPos;
        }

	}
}
