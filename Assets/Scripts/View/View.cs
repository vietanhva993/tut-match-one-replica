using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener
{
    

    public void Link(IEntity entity)
    {
        gameObject.Link(entity);
        var e = (GameEntity) entity;
        e.AddDestroyedListener(this);
        e.AddPositionListener(this);
        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y, 0f);
    }
    
    public virtual void OnPosition(GameEntity entity, Vector2Int value)
    {
        transform.localPosition = new Vector3(value.x, value.y, 0f);
    }

    public virtual void OnDestroyed(GameEntity entity)
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }

    
}
