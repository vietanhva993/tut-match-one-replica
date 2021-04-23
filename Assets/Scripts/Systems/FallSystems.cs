using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FallSystems : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public FallSystems(Contexts contexts) : base(contexts.game)
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
        var boardSize = _contexts.game.board.BoardSize;
        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                var position = new Vector2Int(x, y);
                var piece = _contexts.game.GetPieceAtPosition(position);
                if (piece != null && piece.isMovable)
                {
                    var newPos = new Vector2Int(position.x, MoveDown(piece, position));
                    piece.ReplacePosition(newPos);
                }
            }
        }
    }

    private int MoveDown(GameEntity e, Vector2Int pos)
    {
        pos.y -= 1;
        while (pos.y >= 0 && _contexts.game.GetPieceAtPosition(pos) == null)
        {
            pos.y -= 1;
        }

        return pos.y + 1;
    }
    
}
