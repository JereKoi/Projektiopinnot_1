using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Entity
{
    public E5_IdleState idleState { get; private set; }
    public E5_MoveState moveState { get; private set; }
    public E5_PlayerDetectedState playerDetectedState { get; private set; }
    public E5_ChargeState chargeState { get; private set; }
    public E5_LookForPlayerState lookForPlayerState { get; private set; }
    public E5_MeleeAttackState meleeAttackState { get; private set; }
    public E5_StunState stunState { get; private set; }
    public E5_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private Transform meleeAttackPosition;

    public AudioClip takeDamageAudio;
    public AudioSource TakeDamageAudioSource;

    public override void Start()
    {
        base.Start();

        moveState = new E5_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E5_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E5_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E5_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E5_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E5_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E5_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E5_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        TakeDamageAudioSource.clip = takeDamageAudio;
        TakeDamageAudioSource.Play();

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
    }
}