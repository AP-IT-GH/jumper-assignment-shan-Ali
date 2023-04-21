using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacle : MonoBehaviour
{
    public float SpeedMultiplier = 2f;

    private void Update()
    {
        this.transform.Translate(Vector3.left * SpeedMultiplier * Time.deltaTime);
    }


    private void OnCollisionStay(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
