using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public SettingsScript settings;
    public MouseLook mouse;
    public Text GetReadyText, clickToStartText, timeText, scoreText, missTimeText, accuracyText, scoreUIText;
    public Image centerDotCrosshairImage, leftCrosshair, rightCrosshair, upCrosshair, downCrosshair;
    public TargetDetection targetDetect;
    public GameObject gameManager;
    public GameObject ResultsPanel, pausedMenuPanel, settingsPanel;
    public float targetTime = 60f;
    bool gamePaused = false;
    bool startCounter;
    

    private void Awake()
    {
        TurnCrosshairOnAndOFF(false);
    }
    void Start()
    {
        startCounter = false;
    }
    void Update()
    {
        scoreUIText.text = targetDetect.gameObject.GetComponent<TargetDetection>().score.ToString();
        if (startCounter)
        {
            targetTime -= Time.deltaTime;
            timeText.text = ((int)(targetTime)).ToString();

            if (targetTime <= 0.0f)
            {
                StopTimeCounter();
                gameManager.GetComponent<GameManager>().SetGameControlState(GameManager.GameControlState.Ending);
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.GetComponent<GameManager>().GetGameControlState() == GameManager.GameControlState.Gameplay &&
            settingsPanel.activeInHierarchy == false)
        {

            if (gamePaused)
            {
                targetDetect.Paused = false;
                TurnCrosshairOnAndOFF(true);
                Cursor.lockState = CursorLockMode.Locked;
                pausedMenuPanel.SetActive(false);
                mouse.enabled = true;
                startCounter = true;
                gamePaused = false;
            }
            else
            {
                targetDetect.Paused = true;
                TurnCrosshairOnAndOFF(false);
                Cursor.lockState = CursorLockMode.None;
                pausedMenuPanel.SetActive(true);
                startCounter = false;
                mouse.enabled = false;
                gamePaused = true;
            }
        }
        if (settingsPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.SetActive(false);
            pausedMenuPanel.SetActive(true);
        }
    }

    //TIME FUNCTIONS//
    public void StartTimeCounter()
    {
        timeText.gameObject.SetActive(true);
        scoreUIText.gameObject.SetActive(true);

        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
        timeText.gameObject.SetActive(false);
        scoreUIText.gameObject.SetActive(false);
    }

    //GET READY AND CLICK TO START COUROUTINE FUNCTIONS//
    public void StartGetReadyCoroutine()
    {
        StartCoroutine("GetReady");
    }
    private IEnumerator GetReady()
    {
        yield return ClickToStart();
        GetReadyText.gameObject.SetActive(true);
        for (int i = 3; i >= 1; i--)
        {
            GetReadyText.text = "Get Ready - " + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        GetReadyText.text = "Go!";
        yield return new WaitForSeconds(1f);
        GetReadyText.gameObject.SetActive(false);
        TurnCrosshairOnAndOFF(true);
        gameManager.GetComponent<GameManager>().StartGamePlay();
    }
    public IEnumerator ClickToStart()
    {
        clickToStartText.gameObject.SetActive(true);
        bool done = false;
        while (!done)
        {
            if (Input.anyKey)
            {
                done = true;
                Cursor.lockState = CursorLockMode.Locked;
                clickToStartText.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    public void results()
    {
        targetDetect.Paused = true;
        TurnCrosshairOnAndOFF(false);
        ResultsPanel.SetActive(true);
        scoreText.text = targetDetect.score.ToString();
        missTimeText.text = ((int)Mathf.Round(targetDetect.MissTimeCount)).ToString() + " Seconds";
        accuracyText.text = ((int)((Mathf.Round(targetDetect.HitTimeCount) / 60) * 100)).ToString() + "%";
        
    }


    public void TurnCrosshairOnAndOFF(bool v)
    {
        if (v)
        {
            if (settings.crosshairtypeValue == 0)
            {
                centerDotCrosshairImage.gameObject.SetActive(true);
                leftCrosshair.gameObject.SetActive(false);
                rightCrosshair.gameObject.SetActive(false);
                upCrosshair.gameObject.SetActive(false);
                downCrosshair.gameObject.SetActive(false);
            }
            else if (settings.crosshairtypeValue == 1)
            {
                centerDotCrosshairImage.gameObject.SetActive(false);
                leftCrosshair.gameObject.SetActive(true);
                rightCrosshair.gameObject.SetActive(true);
                upCrosshair.gameObject.SetActive(true);
                downCrosshair.gameObject.SetActive(true);
            }
        }
        else
        {
            centerDotCrosshairImage.gameObject.SetActive(false);
            leftCrosshair.gameObject.SetActive(false);
            rightCrosshair.gameObject.SetActive(false);
            upCrosshair.gameObject.SetActive(false);
            downCrosshair.gameObject.SetActive(false);
        }

    }
}
