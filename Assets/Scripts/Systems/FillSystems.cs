using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FillSystems : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public FillSystems(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
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
        var e = entities.SingleEntity();
        var board = _contexts.game.board.BoardSize;
        var targetPos = new Vector2Int(e.position.value.x, board.y -1); 
        // Instantiate
        var newEntity = _contexts.game.CreateRandomPiece(e.position.value.x, board.y);
        newEntity.ReplacePosition(targetPos);
    }
}
