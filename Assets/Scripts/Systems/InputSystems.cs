using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InputSystems : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystems(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var e = _contexts.input.CreateEntity();
            e.AddInput(new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y)));
        }
    }
}
