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
        onDissapear.Invoke();
    }

    public override void Enter()
    {
        base.Enter();
        ScoreManager._instance.kills.AddCurrency(1);
        StartCoroutine(DisappearAfter());
        GetComponent<AIEnemy>().puppet.Kill();
        GetComponent<AISounds>().PlayDeath();
    }

    public override void Exit()
    {
        //GetComponent<AIEnemy>().puppet.Resurrect();
        base.Exit();
    }
}
