using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystems : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Transform _parent;

    public AddViewSystems(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _parent = new GameObject("BoardViews").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            IView view = InstatiateView(entity);
            entity.AddView(view);
        }
    }

    private IView InstatiateView(GameEntity e)
    {
        GameObject go = Resources.Load<GameObject>(e.asset.AssetName);
        var view = Object.Instantiate(go, _parent).GetComponent<IView>();
        view.Link(e);
        return view;
    }
}
