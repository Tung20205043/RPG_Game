using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] protected string characterName;
    [Header("Component System")]
    [SerializeField] protected Agent agent = null;
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;

    public string Name => characterName;
    protected virtual void Awake() {
        agent.Initialized();
    }
    protected abstract void Move();
    public abstract void Attack();

    public abstract void TakeDamage();
    

}
