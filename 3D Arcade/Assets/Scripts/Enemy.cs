using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //public HealthBar healthBar;

    public float moveSpeed = 10;
    public float spinSpeed = 100f;
    public int xpValue = 1;

    public GameObject[] player;
    public GameObject lastHitPlayer;

    public GameManager gameManager;
    public AudioClip deathClip;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

      //  player = GameObject.FindGameObjectWithTag("Player");//GetComponent<SAE.PlayerMovement>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
        this.transform.position += this.transform.forward  * Time.deltaTime * this.moveSpeed;

        if (currentHealth <= 0)
        {

            //SoundManager.instance.PlaySoundFX(deathClip);
            // player.GetComponent<SAE.PlayerMovement>().GainXP(xpValue);
            /*foreach(GameObject player in players)
             {

                 Debug.Log("Do A Flip");

                 if (player == lastHitPlayer)
                 {
                     player.GetComponent<SAE.PlayerMovement>().GainXP(xpValue);
                     Debug.Log("Working");
                 }
                  else
                 {
                     Debug.Log("Invalid Gameobject");
                 }
             }*/
            SoundManager.instance.PlaySoundFX(deathClip);
            Destroy(this.gameObject);

            gameManager.UpdateScore(5);

        }

        else
        {
            Destroy(this.gameObject, 6f);
        }
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        //anim.SetBool("Hit", true);

        Destroy(this.gameObject);
    }*/

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
        //healthBar.SetHealth(currentHealth);

        
    }
    
}
