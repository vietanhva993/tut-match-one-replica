using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreSystems : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts _contexts;
    
    public ScoreSystems(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.gameState.SetScore(0);
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed && entity.isPiece;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        int reactiveEntities = entities.Count;
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + reactiveEntities);
    }

    
}
