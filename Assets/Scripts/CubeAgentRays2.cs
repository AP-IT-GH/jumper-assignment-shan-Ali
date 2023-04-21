using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.UIElements;

public class CubeAgentRays2 : Agent
{

    public Transform Target;
    public Transform SafeGround;
    bool done = false;
    public override void OnEpisodeBegin()
    {
        done = false;
        // reset de positie en orientatie als de agent gevallen is
        if (this.transform.localPosition.y < 0)
        {

            this.transform.localPosition = new Vector3(0, 0.5f, 0); this.transform.localRotation = Quaternion.identity;
        }

        // verplaats de target naar een nieuwe willekeurige locatie 
        Target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
        
        

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target en Agent posities
        // sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

    }


    public float speedMultiplier = 0.1f;
    public float rotationMultiplier = 5;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.z = actionBuffers.ContinuousActions[0];
        transform.Translate(controlSignal * speedMultiplier);
        transform.Rotate(0.0f, rotationMultiplier * actionBuffers.ContinuousActions[1], 0.0f);

        // Beloningen
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);
        float distanceToGround = Vector3.Distance(this.transform.localPosition, SafeGround.localPosition);

        // target bereikt
        if (distanceToTarget < 1.42f && done==false)
        {
            done = true;
            SetReward(0.5f);           
            EndEpisode();

        }else if (distanceToTarget < 1.42f && done)
        {
            done = true;
            SetReward(-0.5f);
            EndEpisode();
        }else if(distanceToGround < 1f && done){

            SetReward(1f);
            EndEpisode();
        }
        // Van het platform gevallen?
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }/**/
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
    }





}






