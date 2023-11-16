using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody playerRb;
    public Animator playerAnim;
    public AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;
    public int jumpCount = 2;
    public bool gameOver = false;
    public bool isDash = false;
    public bool isRun = false;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < 0)
        {
            playerAnim.SetFloat("Speed_f", 0.3f);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 1.0f);
            isRun = true;
        }



        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !gameOver && isRun)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount -= 1;

            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }

        //Dash
        if (Input.GetKey(KeyCode.D) && !gameOver && isRun)
        {
            isDash = true;
            playerAnim.SetFloat("Speed_f", 2.0f);
        }
        else if (isDash && !gameOver)
        {
            isDash = false;
            playerAnim.SetFloat("Speed_f", 1.0f);
        }

        if (!isDash && isRun && !gameOver)
        {
            score += Mathf.FloorToInt(Time.deltaTime * 10000) / 10;
            Debug.Log("Score : " + score);
        }
        else if (isDash && isRun && !gameOver)
        {
            score += Mathf.FloorToInt(Time.deltaTime * 10000) / 10 * 2;
            Debug.Log("*DASH !!!* Score : " + score);
        }

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2;

            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! Score : " + score);
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }
}
