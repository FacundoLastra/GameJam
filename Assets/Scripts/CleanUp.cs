using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public float TimeToLive = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
