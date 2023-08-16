using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    public float TimeDelay = 2f;

    private void Start()
    {
        Invoke("Spawn", TimeDelay);
    }

    void Spawn()
    {
        Instantiate(Object, transform.position, Quaternion.identity);
    }
}
