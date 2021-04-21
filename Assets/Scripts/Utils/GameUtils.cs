using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public partial class Contexts
{
    public const string KEY_PIECE = "Piece";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializePieceEntityIndices()
    {
        game.AddEntityIndex(new PrimaryEntityIndex<GameEntity, Vector2Int>(
            KEY_PIECE,
            game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Piece, GameMatcher.Position)
                .NoneOf(GameMatcher.Destroyed)
            ),
            (entity, component) => (component as PositionComponent)?.value ?? entity.position.value));

    }
}


public static class GameUtils
{
    
    
    
    public static int GetRandom(int maxValue)
    {
        return Random.Range(0, maxValue + 1);
    }

   
    #region Game

    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.isPiece = true;
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddPosition(new Vector2Int(x, y));
        entity.AddAsset($"Piece{GameUtils.GetRandom(5)}");
        return entity;
    }

    public static GameEntity CreateBlocker(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.isPiece = true;
        entity.isMovable = false;
        entity.isInteractive = false;
        entity.AddPosition(new Vector2Int(x, y));
        entity.AddAsset("Blocker");
        return entity;
    }
    
    public static bool IsValidPercent(float percent)
    {
        return Random.Range(0, 100) < percent;
    }

    public static GameEntity GetPieceAtPosition(this GameContext context, Vector2Int pos)
    {
        var mapping = (PrimaryEntityIndex<GameEntity, Vector2Int>) context.GetEntityIndex("Piece"); //Contexts.KEY_PIECE
        return mapping.GetEntity(pos);
    }
    
    
    #endregion
    
    
}
