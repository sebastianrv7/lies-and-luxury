using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Minigame : MonoBehaviour
{
    private static UnityEvent onMinigameFinish;

    private void Start()
    {
        onMinigameFinish = new();
        onMinigameFinish.AddListener(OnMinigameFinished);
    }

    private void Update()
    {
    }

    private void OnMinigameFinished() {
        
    }

}
