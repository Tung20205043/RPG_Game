using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    public AnimationState currentState;
    protected MovementType currentMovementType;
    protected AttackType currentAttackType;

    public Action AttackVoice = null;

    private Animator anim = null;
    protected string currentTrigger = "";
    public Animator Anim {
        get {
            if (anim == null)
                anim = GetComponent<Animator>();
            return anim;
            
        }
    }
    public void Initialized() {
    }

    private Tween movementTween = null;
    public void SetMovement(MovementType type) {
        float value = (int)type;
        float lastValue = Anim.GetFloat("MovementType");
        if (movementTween != null)
            movementTween.Kill();
        movementTween = DOTween.To(() => lastValue, x => lastValue = x, value, 0.01f).OnUpdate(() => {
            Anim.SetFloat("MovementType", lastValue, 0.1f, Time.deltaTime);
        });
        SetTrigger("Movement");
        currentState = AnimationState.Movement;
    }

    public void SetAttack(AttackType type) {
        currentState = AnimationState.Attack;
        SetFloat("AttackType", (int)type);
        SetTrigger("Attack");
        AttackVoice?.Invoke();
        
        //StartCoroutine(BackToIdle());
    }
    public void SetJump() {
        if (currentState == AnimationState.Jump)
            return;

        SetTrigger("Jump");

        currentState = AnimationState.Jump;
    }
    public void SetTrigger(string param) {
        if (param.Equals(currentTrigger))
            return;

        if (!String.IsNullOrEmpty(currentTrigger))
            Anim.ResetTrigger(currentTrigger);

        Anim.SetTrigger(param);
        currentTrigger = param;
    }
    public void SetBool(string param, bool value) {
        Anim.SetBool(param, value);
    }

    public void SetFloat(string param, float value) {
        Anim.SetFloat(param, value);
    }
}
