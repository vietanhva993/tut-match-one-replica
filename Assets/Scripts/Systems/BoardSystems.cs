using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class BoardSystems : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _pieces;

    public BoardSystems(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _pieces = new Group<GameEntity>(GameMatcher.AllOf(GameMatcher.Piece, GameMatcher.Position));
    }


    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        var boardSize = _contexts.config.gameConfig.value.BoardSize;
        var blockerProbability = _contexts.config.gameConfig.value.BlockerProbability;
        entity.AddBoard(boardSize);

        for (int y = 0; y < boardSize.y; y++)
        {
            for (int x = 0; x < boardSize.x; x++)
            {
                if (GameUtils.IsValidPercent(blockerProbability))
                {
                    _contexts.game.CreateBlocker(x, y);
                }
                else
                {
                    _contexts.game.CreateRandomPiece(x, y);
                }
            }
        }
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Board);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBoard;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var boardSize = entities.SingleEntity().board.BoardSize;
        foreach (var e in _pieces)
        {
            if (e.position.value.x >= boardSize.x || e.position.value.y >= boardSize.y)
                e.isDestroyed = true;
        }
        
    }
}
