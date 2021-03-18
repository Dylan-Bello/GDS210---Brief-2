using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZoneEvent : MonoBehaviour
{
    public UnityEvent unityEvent;


    private void OnTriggerEnter(Collider other)
    {
        unityEvent.Invoke();
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            unityEvent.Invoke();
        }
    }*/
}
