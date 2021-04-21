using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public class BoardComponent : IComponent
{

    public Vector2Int BoardSize;

}
