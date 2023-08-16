using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Time);
    }
}
