using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class Agent : MonoBehaviour
{
    [Header("Configuration")]
    public float angularSpeed = 10f;
    [Header("Debuger")]
    public bool showPath = true;


    private NavMeshAgent _agent = null;
    public NavMeshAgent AgentBody => this.TryGetMonoComponent(ref _agent);

    private NavMeshPath path = null;
    public Action OnArried = null;

    public void Initialized() {
        path = new NavMeshPath();
       
    }
    public Vector3 GetVelocity() { 
        return AgentBody.velocity;
    }
    public void MoveToDirection(Vector3 direction, float moveSpeed) {
        RotateToDirection(direction);
        AgentBody.Move(transform.forward * moveSpeed * Time.deltaTime);
    }
    public void RotateToDirection(Vector3 direction) {
        Quaternion targetQuaternion = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, angularSpeed * Time.deltaTime);
    }
    public void SetDestination(Vector3 destination, float speed) {
        AgentBody.isStopped = false;
        AgentBody.speed = speed;
        AgentBody.SetDestination(destination);
        if (Vector3.Distance(transform.position, destination) <= AgentBody.radius) {
            OnArried?.Invoke();
        }
    }
    
}
