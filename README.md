# Jumper-Assignment-Shan-Ali

## JumpAgent
This is a Unity game agent that can learn to jump over obstacles and collect points using reinforcement learning with Unity ML-Agents.

## Getting Started
To use this agent, you need to have Unity installed on your machine. You can download the Unity Hub from here and follow the instructions to install Unity.

Once you have Unity installed, you can follow these steps to set up the agent:

Clone or download the repository.
Open Unity Hub and click on the "Projects" tab.
Click the "Add" button and select the folder where you cloned/downloaded the repository.
Open the project by clicking on it in the Unity Hub.
Open the "Jumper Scene" in the "Scenes" folder.

## How it Works
The JumpAgent is a reinforcement learning agent that learns to jump over obstacles and collect points in the game. The agent uses the Unity ML-Agents toolkit, which provides a set of tools for building and training intelligent agents.

### The agent has the following components:

Transform ground;

Rigidbody rigidBody;

bool jumpEnabled;

![image](https://user-images.githubusercontent.com/60844044/235786322-90ff7e65-f0dd-4745-99b5-df9b2bd841a6.png)


void OnEpisodeBegin()
This method is called when a new episode begins. It resets the agent's position and rotation and enables jumping.

![image](https://user-images.githubusercontent.com/60844044/235786700-ec04a5d3-c627-4912-a042-1114bd9fea1e.png)


void CollectObservations(VectorSensor sensor)
This method is called to collect observations from the agent. It adds the agent's position, rotation, and the ground position to the sensor.

void OnActionReceived(ActionBuffers actionBuffers)
This method is called when the agent takes an action. If the action value is greater than 0 and jumping is enabled, the agent jumps.

![image](https://user-images.githubusercontent.com/60844044/235786770-fdc1d89a-5894-4c01-b223-5cbac7bfbaef.png)


void Heuristic(in ActionBuffers actionsOut)
This method is called when the agent is controlled by a human player. It sets the continuous action value based on the vertical input axis.

void OnCollisionStay(Collision collision)
This method is called when the agent is colliding with another object. It checks if the agent collided with an obstacle, a point, or fell off the ground. It adds rewards or ends the episode depending on the collision type.

![image](https://user-images.githubusercontent.com/60844044/235786958-08539242-ceef-4481-a28a-ece433ca2a74.png)
