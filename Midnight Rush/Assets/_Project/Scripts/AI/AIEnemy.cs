using UnityEngine;
using RootMotion.Dynamics;

[RequireComponent(typeof(TAIStateManager))]
[RequireComponent(typeof(AIHealth))]

public class AIEnemy : MonoBehaviour, IPoolable
{
    [SerializeField] Transform chaseTarget;
    TAIStateManager stateManager;
    AIHealth healthComponent;
    public PuppetMaster puppet;

    private void Awake()
    {
        if (chaseTarget == null)
        {
            //Debug.LogError("No chaseTarget provided to: " + gameObject.name);
            chaseTarget = GameManager._instance.player.transform;
        }

        stateManager = GetComponent<TAIStateManager>();
        stateManager.InitStates();
        stateManager.SetTarget(chaseTarget);
        healthComponent = GetComponent<AIHealth>();
        healthComponent.onDamage.AddListener(CheckForHealth);

        if (puppet == null)
        {
            Debug.LogError("No puppet provided to: " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 31 && stateManager.CurrentState != stateManager.GetState<AIDeathState>())
        {
            stateManager.ApplyState<AIAttackingState>();
            Debug.Log(name + " is attacking player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 31 && stateManager.CurrentState != stateManager.GetState<AIDeathState>())
        {
            stateManager.ApplyState<AIChasingState>();
            Debug.Log(name + " is dead");
        }
    }

    void CheckForHealth(int _newHealth)
    {
        if (_newHealth <= 0 && stateManager.CurrentState != stateManager.GetState<AIDeathState>())
        {
            AIDeathState state = (AIDeathState)stateManager.ApplyState<AIDeathState>();
            state.onDissapear += () => { AIManager._instance.ImDead(this); };
        }
    }

    public void OnTake()
    {
        stateManager.ApplyState<AIChasingState>();
        healthComponent.InitHealth();
        puppet.enabled = true;
        
        if (!puppet.isAlive) puppet.Resurrect();
        if (!puppet.isActive) puppet.SwitchToActiveMode();
        GetComponent<AISounds>().PlayReborn();
        
    }

    public void OnReturn()
    {
        Debug.Log("return to pool: " + gameObject.name);
        puppet.SwitchToDisabledMode();
        puppet.enabled = false;
    }
}
