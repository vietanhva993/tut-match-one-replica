using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // Input
        Add(new InputSystems(contexts));
        Add(new ProcessInputSystems(contexts));

        // Game
        Add(new BoardSystems(contexts));
        Add(new ScoreSystems(contexts));
        Add(new FallSystems(contexts));
        Add(new FillSystems(contexts));
        
        // View
        Add(new AddViewSystems(contexts));

        // Event
        Add(new GameEventSystems(contexts));
        Add(new GameStateEventSystems(contexts));

        // CleanUp
        // Already Implemented in sub-systems 
    }
}
