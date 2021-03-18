using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;
    public int damageToTake;
    public GameObject shooter;

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

        Debug.Log("Bullet Spawned");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<Enemy>().lastHitPlayer = shooter;
            //other.gameObject.GetComponent<Enemy>().TakeDamage(damageToTake);
           // other.gameObject.GetComponent<Enemy>().lastHitPlayer = shooter;

            //anim.SetBool("Hit", true);

            Destroy(this.gameObject);


        }

    }

    


}
