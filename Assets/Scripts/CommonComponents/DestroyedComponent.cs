using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent
{
    
}
