using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
    public E3_MoveState moveState { get; private set; }
    public E3_IdleState idleState { get; private set; }
    public E3_PlayerDetectedState playerDetectedState { get; private set; }
    public E3_MeleeAttackState meleeAttackState { get; private set; }
    public E3_LookForPlayerState lookForPlayerState { get; private set; }
    public E3_StunState stunState { get; private set; }
    public E3_DeadState deadState { get; private set; }
    public E3_DodgeState dodgeState { get; private set; }
    public E3_RangeAttackState rangeAttackState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_RangeAttackState rangeAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangeAttackPosition;

    public AudioClip takeDamageAudio;
    public AudioSource TakeDamageAudioSource;

    public override void Start()
    {
        base.Start();

        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new E3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E3_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E3_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new E3_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangeAttackState = new E3_RangeAttackState(this, stateMachine, "rangeAttack", rangeAttackPosition, rangeAttackStateData, this);

        stateMachine.Initialize(moveState);
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
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(rangeAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
