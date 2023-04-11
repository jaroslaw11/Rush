using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AIDeathState : TAIState
{
    [SerializeField] float disappearDuration;
    public UnityAction onDissapear;

    protected override void UpdateAnimation()
    {
        animator.SetTrigger("Death");
    }

    IEnumerator DisappearAfter()
    {
        yield return new WaitForSeconds(disappearDuration);
        GetComponent<AIEnemy>().puppet.mappingWeight = 0;
        onDissapear.Invoke();
    }

    public override void Enter()
    {
        base.Enter();
        ScoreManager._instance.kills.AddCurrency(1);
        StartCoroutine(DisappearAfter());
        GetComponent<AIEnemy>().puppet.mappingWeight = 1;
        GetComponent<AIEnemy>().puppet.Kill();
        GetComponent<AISounds>().PlayDeath();
        
    }

    public override void Exit()
    {
        //GetComponent<AIEnemy>().puppet.Resurrect();
        
        base.Exit();
    }
}
