using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public bool IsGameOver {
        get => isGameOver;
    }

    private bool isGameOver;

    private Minigame _minigame;

    private void Awake(){
        _minigame = gameObject.GetComponent<Minigame>();
    }

    private void OnEnable()
    {
        isGameOver = false;

        PrePlay();
    }

    private void FixedUpdate()
    {
        while (GetRemainingTime() > 0 && !HasGameOverHappened() && !HasVictoryHappened()){
            Play();
        }

        isGameOver = GetRemainingTime() <= 0 | HasGameOverHappened();

        _minigame.enabled = false;
    }

    private void OnDisable(){
        PostPlay();
    }

    protected abstract void PrePlay(); // Something before minigame starts

    protected abstract float GetRemainingTime(); // Time remaining

    protected abstract bool HasVictoryHappened(); // Victory condition

    protected abstract bool HasGameOverHappened(); // Game over condition
    
    protected abstract void Play(); // Game code

    protected abstract void PostPlay(); // Something after minigame ends

}
