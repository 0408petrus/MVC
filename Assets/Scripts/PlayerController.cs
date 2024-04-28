using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    
    private bool isOnGround = true;

    private bool isRunning;
    private Animator playerAnimation;

    private AudioSource playerAudio;

    public float jumpForce = 10;

    public float gravityModifier;
    public bool gameOver = false;

    public static PlayerController Instance;

    public GameManager gameManager;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        //old
        // this.transform.Translate(0, 2*Time.deltaTime*20, 0);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        /*playerAnimation.SetFloat("Speed_f", 1.0f);
        playerAnimation.SetBool("Static_b", true);*/

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

        // if Speed_f from Animator is greater than 0, then play the Run_Static Animation
        /*if (playerAnimation.GetFloat("Speed_f") > 0.5 && playerAnimation.GetBool("Static_b")==true)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            gameManager.AddScore(2);
            Destroy(collision.gameObject);
        }
    }

}
