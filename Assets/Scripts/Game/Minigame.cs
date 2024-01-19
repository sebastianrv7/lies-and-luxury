using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Minigame : MonoBehaviour
{
    private bool isGameOver;

    private static UnityEvent onMinigameFinish;

    private void Start()
    {
        isGameOver = false;

        onMinigameFinish = new();
        onMinigameFinish.AddListener(OnMinigameFinished);
    }

    private void Update()
    {
        Move();
    }

    private void OnMinigameFinished() {
        
    }

    protected abstract void Move();

    
}
