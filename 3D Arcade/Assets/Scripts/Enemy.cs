using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10;
    public float spinSpeed = 100f;
    public int xpValue = 1;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
        this.transform.position += this.transform.forward  * Time.deltaTime * this.moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //anim.SetBool("Hit", true);

        Destroy(this.gameObject);
        gameManager.UpdateScore(5);
    }

}
