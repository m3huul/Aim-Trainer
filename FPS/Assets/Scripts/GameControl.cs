using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public TargetShooter ShooterScipt;

    public GameObject TargetSpawner, UiElements;

    public MouseLook mouse;

    private void Awake()
    {
        
    }
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
    void Update()
    {

    }

    void UpdateGameControlState()
    {
        switch (state)
        {
            case GameControlState.Starting:
                UiElements.GetComponent<UIelements>().StartGetReadyCoroutine();
                break;

            case GameControlState.Gameplay:              
                mouse.enabled = true;
                TargetSpawner.GetComponent<TargetSpawner>().SpawnTargets();
                
                UiElements.GetComponent<UIelements>().StartTimeCounter();
                break;
            case GameControlState.Ending:
                mouse.enabled = false;
                UiElements.GetComponent<UIelements>().results();
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

    public void ChangeToOpening()
    {
        SetGameControlState(GameControlState.Starting);
    }
}
