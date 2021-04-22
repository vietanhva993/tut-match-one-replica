using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystems : ReactiveSystem<InputEntity>, ICleanupSystem 
{
    private Contexts _contexts;
    IGroup<InputEntity> _group;
    private List<InputEntity> _buffer = new List<InputEntity>();
    
    public ProcessInputSystems(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _group = contexts.input.GetGroup(InputMatcher.Input);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var pos = inputEntity.input.value;
        
        
        var piece =_contexts.game.GetPieceAtPosition(pos);
        if (piece != null && piece.isInteractive)
        {
            piece.isDestroyed = true;
        }

    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        } 
    }
}
