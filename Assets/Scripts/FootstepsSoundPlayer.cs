using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSoundPlayer : MonoBehaviour
{
    public AudioClip saw;
           
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Floor"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
