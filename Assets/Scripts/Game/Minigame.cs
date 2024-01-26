using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public bool IsGameOver
    {
        get => isGameOver;
    }

    private bool isGameOver;

    private float secondsRemaining;

    private Minigame _minigame;

    private void Awake()
    {
        _minigame = gameObject.GetComponent<Minigame>();
    }

    private void OnEnable()
    {
        isGameOver = false;

        secondsRemaining = 60;

        PrePlay();
    }

    private void FixedUpdate()
    {
        while (secondsRemaining > 0 && !HasGameOverHappened() && !HasVictoryHappened())
        {
            Play();
        }

        isGameOver = secondsRemaining <= 0 | HasGameOverHappened();

        _minigame.enabled = false;
    }

    private void OnDisable()
    {
        PostPlay();
    }

    private void Play()
    {
        ShowInitialMessage();

        ShowStageMessage("Stage 1");

        while (secondsRemaining > 45)
        {
            Stage1();
        }

        ShowStageMessage("Stage 2");

        while (secondsRemaining > 30)
        {
            Stage2();
        }

        ShowStageMessage("Stage 3");

        while (secondsRemaining > 30)
        {
            Stage3();
        }

        ShowFinalMessage();
    }

    private void ShowInitialMessage() { }

    private void ShowStageMessage(string message) { }

    private void ShowFinalMessage() { }

    protected abstract void PrePlay(); // Something before minigame starts

    protected abstract void Stage1(); // Stage 1 of the game

    protected abstract void Stage2(); // Stage 2 of the game

    protected abstract void Stage3(); // Stage 3 of the game

    protected abstract bool HasVictoryHappened(); // Victory condition

    protected abstract bool HasGameOverHappened(); // Game over condition    

    protected abstract void PostPlay(); // Something after minigame ends

}
