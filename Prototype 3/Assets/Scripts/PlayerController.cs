using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explotionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    void Start()
    {
        playerRB=GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over|");
            gameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            dirtParticle.Stop();
            explotionParticle.Play();
            
        }
        
    }
}
