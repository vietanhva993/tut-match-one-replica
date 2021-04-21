using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController
{
    private Systems _systems;

    public GameController(Contexts contexts, IGameConfig config)
    {
        contexts.config.SetGameConfig(config);
        _systems = new GameSystems(contexts);
    }

    public void Initialize()
    {
        _systems.Initialize();
    }

    public void Execute()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
    
}
