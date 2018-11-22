using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
  public Component Owner;
  public StateMachine FSM;
  public State CurrentState;
  public State PreviousState;

  public bool LogToConsole;

  // Start is called before the first frame update
  void Start()
  {
    if (FSM) // if machine exists
    {
      if (CurrentState) // if there is current state or default start state
      {
        if (Owner) // if owner script exists
        {
          CurrentState.OnEnter<StateMachineManager>(this); // enter this state
        }
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (CurrentState) // if current state exists
    {
      if (Owner) // if owner script exists
      {
        CurrentState.OnRun<StateMachineManager>(this);
      }
      else
      {
        Debug.LogWarningFormat("State Manager {0} has no owner script", this);
      }
    }
    else
    {
      Debug.LogWarningFormat("State Manager {0} has no state to update", this);
    }
  }

  // Update is called once per physics update
  void FixedUpdate()
  {
    if (CurrentState) // if current state exists
    {
      if (Owner) // if owner script exists
      {
        CurrentState.OnFixedRun<StateMachineManager>(this);
      }
      else
      {
        Debug.LogWarningFormat("State Manager {0} has no owner script", this);
      }
    }
    else
    {
      Debug.LogWarningFormat("State Manager {0} has no state to update", this);
    }
  }

  // ---------------- functions ----------------------

  public void SwitchState(int index)
  {
    if (FSM.TransitionExists(FSM.GetStateIndex(CurrentState), index))
    {
      State s = CurrentState;

      CurrentState.OnExit<StateMachineManager>(this);
      FSM.States[index].OnEnter<StateMachineManager>(this);
      CurrentState = FSM.States[index];
      PreviousState = s;
      if (LogToConsole) { Debug.LogFormat("State on {0} was switched to {1}", this, CurrentState); }
    }
  }
}
