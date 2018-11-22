using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : ScriptableObject
{
  public List<State> States;
  public List<Transition> StateTransitions;

  public bool LogToConsole = false;

  public bool TransitionExists(int sourceIndex, int targetIndex)
  {
    if (sourceIndex < States.Count && targetIndex < States.Count)
    {
      foreach (Transition t in StateTransitions)
      {
        //Debug.LogFormat("Checking {0} with {1}", t.Source, t.Target);
        if (t.OneWay) //transition is oneway only
        {
          if ((States[sourceIndex] == t.Source && States[targetIndex] == t.Target))
          {
            if (LogToConsole) { Debug.Log("Transition between " + States[sourceIndex] + " and " + States[targetIndex] + " exists"); }
            return true;
          }
        }
        else // transition is twoway
        {
          if ((States[sourceIndex] == t.Source && States[targetIndex] == t.Target) ||
            (States[sourceIndex] == t.Target && States[targetIndex] == t.Source)
          )
          {
            if (LogToConsole) { Debug.Log("Transition between " + States[sourceIndex] + " and " + States[targetIndex] + " exists"); }
            return true;
          }
        }
      }
      Debug.LogWarning(this + "Transition doesnt exists");
      return false;
    }
    else
    {
      Debug.LogWarning(this + "Wrong state index");
      return false;
    }
  }

  /// <summary>
  /// Returns index of provided state object existing in this State Machine
  /// </summary>
  /// <returns>index in list or -1 if not found</returns>
  public int GetStateIndex(State state)
  {
    int index = States.IndexOf(state);
    if (index > -1)
    {
      return index;
    }
    else
    {
      return -1;
    }
  }
}
