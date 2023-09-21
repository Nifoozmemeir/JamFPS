using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBrain : MonoBehaviour
{
    [SerializeField] private State currentState;

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    public void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}