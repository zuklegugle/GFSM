using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Transition")]
public class Transition : ScriptableObject
{
  public State Source;
  public State Target;
  public bool OneWay;
}
