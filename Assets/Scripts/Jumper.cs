using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ob;
    private void OnCollisionEnter(Collision collision)
    {
        JumpAgent jumpAgent = ob.GetComponent<JumpAgent>();
        jumpAgent.disableJump();
    }
}
