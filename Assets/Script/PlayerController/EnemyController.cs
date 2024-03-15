using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class EnemyController : CharacterController
{
    [Header("Attack")]
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected float sightRange = 10f;
    [SerializeField] protected float stopFollowRange = 15f;

    protected List<Vector3> wayPoints = null;
    protected int currentWaypointIndex = 0;
    protected CharacterController targetAttack => GameManager.Instance.player;

    protected bool arried = false;
    protected bool onFollowPlayer = true;
    protected bool _canAttack = true;

    private SoundManager soundManager;
    protected override void Awake() {
        base.Awake();
        soundManager = GetComponent<SoundManager>();
        wayPoints = GameManager.Instance.enemiesWaypoint.Find(w => w.targetEnemy.Equals(Name))?.points.Select(p => p.position).ToList();
        agent.OnArried = OnArried;
        characterAnimator.AttackVoice = VoiceAttack;
    }

    protected virtual void Update() {
        if (StopFollowEnemy())
            StartCoroutine(BackToWayPoint());
        if (DistanceToEnemy() <= sightRange && onFollowPlayer) {              
            if (DistanceToEnemy() >= attackRange) {
                Move();
            } else if (DistanceToEnemy() < attackRange)
                if (CanAttack())
                   StartCoroutine(DoAttack());
                else characterAnimator.SetMovement(MovementType.Idle);
            return;
        } 
        if (arried)
            return;
        MoveToWayPoint();
    }
    //Attack void
    public override void Attack() {
        characterAnimator.SetAttack(AttackType.Normally); 
    }
    protected bool CanAttack() {
        return targetAttack != null && characterAnimator.currentState == AnimationState.Movement
              && _canAttack;
    }
    public void VoiceAttack() {
        soundManager.PlaySound("Attack");
    }
    IEnumerator DoAttack() {
        Attack();
        _canAttack = false;
        yield return new WaitForSeconds(CharacterStats.Instance.EnemyAtkSpd);
        characterAnimator.SetMovement(MovementType.Idle);
        _canAttack = true;
    }
    // Move void
    protected override void Move() {
        characterAnimator.SetMovement(MovementType.Run);
        agent.SetDestination(targetAttack.transform.position, CharacterStats.Instance.EnemyRunSpd);

    }
    protected void MoveToWayPoint() {
        characterAnimator.SetMovement(MovementType.Walk);
        agent.SetDestination(wayPoints[currentWaypointIndex], CharacterStats.Instance.EnemyWalkSpd);
    }
    protected virtual void OnArried() {
        arried = true;
        characterAnimator.SetMovement(MovementType.Idle);
        this.DelayCall(2, () => {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Count)
                currentWaypointIndex = 0;
            arried = false;
        });
    }
    IEnumerator BackToWayPoint() {
        onFollowPlayer = false;
        yield return new WaitForSeconds(10);
        onFollowPlayer = true;
    }
    // bool - float
    protected float DistanceToEnemy() {
        return Vector3.Distance(transform.position, targetAttack.transform.position);
    }
    protected bool StopFollowEnemy() {
        return Vector3.Distance(transform.position, wayPoints[currentWaypointIndex]) >= stopFollowRange;
    }

    public override void TakeDamage() {
        
    }
}
