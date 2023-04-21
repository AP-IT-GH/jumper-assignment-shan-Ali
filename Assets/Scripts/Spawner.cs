using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawn;
    public float min = 1.0f;
    public float max = 3.5f;

    private void Start()
    {
        Invoke("Spawn", Random.Range(min, max));
    }

    private void Spawn()
    {
        GameObject ob = Instantiate(prefab);
        ob.transform.position = spawn;
        Invoke("Spawn", Random.Range(min, max));
    }
}
