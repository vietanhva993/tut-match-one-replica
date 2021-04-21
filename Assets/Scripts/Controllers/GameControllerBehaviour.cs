using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehaviour : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    private GameController _controller;
    void Awake()
    {
        _controller = new GameController(Contexts.sharedInstance, _config);
    }

    void Start()
    {
        _controller.Initialize();
    }

    private void Update()
    { 
        _controller.Execute();
    }
}
