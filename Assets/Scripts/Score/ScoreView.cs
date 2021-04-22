using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IAnyScoreListener
{
    [SerializeField]
    private Text txtScore;
    
    // Start is called before the first frame update
    void Start()
    {
        var listener = Contexts.sharedInstance.gameState.CreateEntity();
        listener.AddAnyScoreListener(this);
    }

    

    public void OnAnyScore(GameStateEntity entity, int value)
    {
        txtScore.text = $"Score: {value}";
    }
}
