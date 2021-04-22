using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PieceView : View
{
    [SerializeField]
    private float destroyDuration;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public override void OnPosition(GameEntity entity, Vector2Int value)
    {
        transform.DOKill();
        bool isTopRow = value.y == Contexts.sharedInstance.game.board.BoardSize.y - 1;
        if (isTopRow)
            transform.localPosition = new Vector3(value.x, value.y, 0f);
        else
            transform.DOMove(new Vector3(value.x, value.y, 0f), 0.3f);
    }

    public override void OnDestroyed(GameEntity entity)
    {
        var color = _sprite.color;
        color.a = 0f;
        _sprite.material.DOColor(color, destroyDuration);
        gameObject.transform.DOScale(Vector3.one * 1.5f, destroyDuration).OnComplete(() => base.OnDestroyed(entity));
        
    }
}
