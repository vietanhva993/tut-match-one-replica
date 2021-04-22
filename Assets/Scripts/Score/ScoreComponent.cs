using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[GameState, Unique, Event(EventTarget.Any)]
public class ScoreComponent : IComponent
{
    public int value;
}
