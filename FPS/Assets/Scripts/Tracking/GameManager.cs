using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TargetShooter ShooterScipt;
    public GameObject TargetSpawn, uiElements;
    public MouseLook mouse;

    public enum GameControlState
    {
        Starting,
        Gameplay,
        Ending,
    }
    GameControlState state;

    void Start()
    {
        mouse.enabled = false;
        state = GameControlState.Starting;
        UpdateGameControlState();
    }

    void UpdateGameControlState()
    {
        switch (state)
        {
            case GameControlState.Starting:
                uiElements.GetComponent<ui>().StartGetReadyCoroutine();
                break;

            case GameControlState.Gameplay:
                mouse.enabled = true;
                TargetSpawn.GetComponent<TargetSpawn>().SpawnTargets();
                uiElements.GetComponent<ui>().StartTimeCounter();
                break;
            case GameControlState.Ending:
                mouse.enabled = false;
                uiElements.GetComponent<ui>().results();
                Cursor.lockState = CursorLockMode.None;
                break;

        }
    }

    public void SetGameControlState(GameControlState Gstate)
    {
        state = Gstate;
        UpdateGameControlState();
    }

    public GameControlState GetGameControlState()
    {
        return state;
    }

    public void StartGamePlay()
    {
        state = GameControlState.Gameplay;
        UpdateGameControlState();
    }
}
