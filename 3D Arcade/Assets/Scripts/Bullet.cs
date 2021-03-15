using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{



    public float bulletSpeed = 1f;
    //public int damageToTake;

    //public Animator anim;

    void Awake()
    {
        //anim = GetComponent<Animator>();

        //anim.SetBool("Hit", false);

        Destroy(this.gameObject, 3f);
    }


    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0 * Time.deltaTime, bulletSpeed);
        pos += transform.rotation * velocity;
        transform.position = pos;


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<EnemyFollow>().TakeDamage(damageToTake);

            //anim.SetBool("Hit", true);

            Destroy(this.gameObject, 3f);


        }

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Hit", true);

        Destroy(this.gameObject, 3f);
    }*/


}
