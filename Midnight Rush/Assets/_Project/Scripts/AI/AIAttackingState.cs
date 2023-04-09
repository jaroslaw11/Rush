using UnityEngine;
using Opsive.UltimateCharacterController.Traits;
using System.Collections;

public class AIAttackingState : TAIState
{
    [SerializeField] float rotationDamping = 1f;
    [SerializeField] AIAttackData attackData;
    Attribute characterHealth;
    [SerializeField] ParticleSystem attackFX;

    protected override void UpdateAnimation()
    {
        animator.SetBool("isWalk", false);
    }

    private void Start()
    {
        characterHealth = target.GetComponent<AttributeManager>().GetAttribute("Health");
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    // call from animation event
    void Attack()
    {
        target.GetComponent<CharacterHealth>().Damage(attackData.damage);
        attackFX.gameObject.SetActive(true);
        Debug.Log(this.name + " - attack player, health: " + characterHealth.Value);
    }

    void AttackLoop()
    {
        ResetAttack();
        animator.SetTrigger("Attacking");
    }

    void ResetAttack()
    {
        animator.ResetTrigger("Attacking");
        attackFX.gameObject.SetActive(false);
    }

    IEnumerator StartAttack()
    {
        while (true)
        {
            AttackLoop();
            yield return new WaitForSeconds(attackData.cooldown);         
        }     
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(StartAttack());
        GetComponent<AISounds>().PlayAttack();
    }

    public override void Exit()
    {
        animator.ResetTrigger("Attacking");
        StopAllCoroutines();
        base.Exit();      
    }
}
