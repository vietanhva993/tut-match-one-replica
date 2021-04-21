using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Match One/Game Config")]
public class GameConfig : ScriptableObject, IGameConfig
{

    [SerializeField]
    private Vector2Int _boardSize;
    public Vector2Int BoardSize => _boardSize;

    [SerializeField]
    private float _blockerProbability;
    
    public float BlockerProbability => _blockerProbability;
}
