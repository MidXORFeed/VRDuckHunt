using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable AI/AI State")]
public class AIState : ScriptableObject
{
    public AIAction[] aiActions;
    public AITransition[] aiTransitions;

    public void UpdateState(AIStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    public void DoActions(AIStateController controller)
    {

    }

    public void CheckTransitions(AIStateController controller)
    {

    }

}
