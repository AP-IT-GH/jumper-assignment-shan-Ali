using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class JumpAgent : Agent
{
    public Transform ground;
    private Rigidbody rigidBody;
    public bool jumpEnabled = true;

    public override void OnEpisodeBegin()
    {
        jumpEnabled = true;

        if (transform.localPosition.y < 0)
        {
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = Quaternion.identity;
        }

        transform.localPosition = new Vector3(0, 0.5f, 0);
        rigidBody.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(rigidBody.transform.rotation);
        sensor.AddObservation(ground.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (actionBuffers.ContinuousActions[0] > 0)
        {
            if (jumpEnabled)
            {
                rigidBody.AddForce(Vector3.up * 340, ForceMode.Acceleration);
                disableJump();
            }
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            AddReward(-0.5f);
            EndEpisode();
        }
        else if (collision.gameObject.CompareTag("point"))
        {
            AddReward(0.5f);
            collision.gameObject.transform.position = new Vector3(Random.Range(4.0f, 8.0f), collision.gameObject.transform.position.y, -10.86f);
        }
        else if (transform.localPosition.y < ground.position.y)
        {
            EndEpisode();
        }
        else if (transform.up.y < -0.9f)
        {
            EndEpisode();
        }
    }

    public void disableJump()
    {
        jumpEnabled = false;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
}
