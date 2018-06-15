using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float Speed;
    public float jumpForce;
    public float WallJumpForce;
    public float RayLength;
    public float WallRayLength;
    public float ClimbLimit;
    public float JumpTimer;

    public int DeathCounter = 0;

    public Vector2 SpawnPos;
    public Text txtDeaths;
    public Text txtClimbs;
    public LayerMask Ground;

    public bool IgnorePortal = false;
    public bool isClimbing;
    public bool CanJump;
    public bool isFacingRight;
    public bool Dead;

    private bool hitWallRight;
    private bool hitWallLeft;
    private bool Jump;
    private bool WallJump;
    private bool Respawn = false;

    private float ClimbCounter;
    private float iJumpTimer;

    private Rigidbody2D Rb;
    public float PrevX;

    public Transform DeathY;
    private Material ShaderMat;
    private float ShaderCutOff = 0;

    // Use this for initialization
    void Start() {
        SpawnPos = transform.position;
        Rb = gameObject.GetComponent<Rigidbody2D>();
        PostEffectScript PES = GameObject.Find("Main Camera").GetComponent<PostEffectScript>();
        ShaderMat = PES.Mat;
        ShaderMat.SetFloat("_CutOff", 0);
    }

    // Update is called once per frame
    void Update() {

        vDeath();
        Collision();

        if (Input.GetAxisRaw("Jump") > 0 && CanJump)
            Jump = true;

        if (Input.GetButtonDown("Jump") && isClimbing) {
            if (ClimbCounter < ClimbLimit) {
                if (PrevX == transform.localScale.x)
                    ClimbCounter++;
                else
                    ClimbCounter = 0;

                PrevX = transform.localScale.x;
                WallJump = true;
            }
        }

        txtClimbs.text = ClimbCounter.ToString();

        //Suicide button
        if (Input.GetKeyDown(KeyCode.R)) {
            gameObject.GetComponent<TrailRenderer>().Clear();
            transform.position = SpawnPos;
            DeathCounter++;
        }

        if (transform.localScale.x < 0)
            isFacingRight = false;
        else
            isFacingRight = true;
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");

        if (Jump) {
            Rb.AddForce(transform.up * jumpForce);
            Jump = false;
        }

        if (WallJump) {
            Rb.AddForce(transform.up * WallJumpForce);
            WallJump = false;
        }

        if (h > 0 && !hitWallRight) {
            transform.position += transform.right * Speed * Time.deltaTime;
            transform.localScale = new Vector2(1, 1);
        }

        if (h < 0 && !hitWallLeft) {
            transform.position -= transform.right * Speed * Time.deltaTime;
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void vDeath() {
        txtDeaths.text = DeathCounter.ToString();

        if (transform.position.y <= DeathY.position.y)
            Dead = true;

        if (Dead)
            Death();

        if (Input.anyKeyDown && Dead)
            Respawn = true;
    }

    void Collision() {
        //Collision
        RaycastHit2D GroundHit = Physics2D.Raycast(transform.position, -transform.up, RayLength, Ground);
        Debug.DrawRay(transform.position, -transform.up * RayLength);

        if (GroundHit.collider != null) {
            CanJump = true;
            ClimbCounter = 0;
            iJumpTimer = JumpTimer;
        }
        else {
            iJumpTimer -= Time.deltaTime;
            if (iJumpTimer < 0)
                CanJump = false;
        }

        RaycastHit2D WallHit;

        if (isFacingRight) {
            WallHit = Physics2D.Raycast(transform.position, transform.right, WallRayLength, Ground);
            Debug.DrawRay(transform.position, transform.right * WallRayLength);
        }
        else {
            WallHit = Physics2D.Raycast(transform.position, -transform.right, WallRayLength, Ground);
            Debug.DrawRay(transform.position, -transform.right * WallRayLength);
        }

        if (WallHit.collider != null)
            if (isFacingRight) {
                hitWallRight = true;
                hitWallLeft = false;
            }
            else {
                hitWallLeft = true;
                hitWallRight = false;
            }
        else {
            hitWallLeft = false;
            hitWallRight = false;
        }

        if (WallHit.collider != null && GroundHit.collider == null && WallHit.collider.tag != "Ice")
            isClimbing = true;
        else
            isClimbing = false;
    }

    void Death() {
        Time.timeScale = 0;

        if (ShaderCutOff < 0.9f) {
            ShaderCutOff += Time.fixedDeltaTime / 2.5f;
            ShaderMat.SetFloat("_CutOff", ShaderCutOff);
        }

        if (Respawn) {
            Time.timeScale = 1;
            Rb.velocity = Vector3.zero;
            Rb.angularVelocity = 0f;
            gameObject.GetComponent<TrailRenderer>().Clear();
            transform.position = SpawnPos;
            DeathCounter++;
            ShaderMat.SetFloat("_CutOff", 0);
            ShaderCutOff = 0;
            Camera Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            Cam.transform.position = transform.position;
            Respawn = false;
            Dead = false;
        }
    }
}
