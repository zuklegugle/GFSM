using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
  public abstract void OnEnter<T>(T statemachine);
  public abstract void OnRun<T>(T statemachine);
  public abstract void OnFixedRun<T>(T statemachine);
  public abstract void OnExit<T>(T statemachine);
}
