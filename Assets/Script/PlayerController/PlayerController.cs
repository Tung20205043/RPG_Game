
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : CharacterController {
    [SerializeField] protected Joystick joyStick = null;
    private SoundManager soundManager;

    protected override void Awake() {
        base.Awake();
        soundManager = GetComponent<SoundManager>();
        characterAnimator.AttackVoice = VoiceAttack;
    }
    public void Update() {
        if (joyStick.Direction == Vector2.zero) {
            if (characterAnimator.currentState == AnimationState.Attack) return;
            characterAnimator.SetMovement(MovementType.Idle);          
            return;
        }
        Move();
    }
    protected override void Move() {
        characterAnimator.SetMovement(MovementType.Run);
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);
        agent.MoveToDirection(targetDirection, CharacterStats.Instance.PlayerMoveSpd);

    }
    protected void Jump() {
        characterAnimator.SetJump();
        
    }
    public override void Attack() {
        if (characterAnimator.currentState == AnimationState.Attack) return;
        characterAnimator.SetAttack(AttackType.Normally);
        StartCoroutine(BackToIdle());
    }
    
    public void VoiceAttack() {
        soundManager.PlaySound("Attack");
    }
    IEnumerator BackToIdle() {
        yield return new WaitForSeconds(CharacterStats.Instance.PlayerAtkSpd);
        characterAnimator.SetMovement(MovementType.Idle);
    }

    public override void TakeDamage() {

    }
}
