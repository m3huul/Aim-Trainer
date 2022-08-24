using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIelements : MonoBehaviour
{
    public SettingsScript settings;
    public MouseLook mouse;
    public Text GetReadyText, clickToStartText, timeText, scoreText, targetHitsText, shotsFiredText, accuracyText, scoreUIText;
    public Image centerDotCrosshairImage, leftCrosshair, rightCrosshair, upCrosshair, downCrosshair;
    public TargetShooter targetShooter;
    public GameObject gameControl;
    public GameObject ResultsPanel, pausedMenuPanel;
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
        scoreUIText.text = targetShooter.gameObject.GetComponent<TargetShooter>().score.ToString();
        if (startCounter)
        {
            targetTime -= Time.deltaTime;
            timeText.text = ((int)(targetTime)).ToString();

            if (targetTime <= 0.0f)
            {
                StopTimeCounter();
                gameControl.GetComponent<GameControl>().SetGameControlState(GameControl.GameControlState.Ending);
            }
    
        }
        if(Input.GetKeyDown(KeyCode.Escape) && gameControl.GetComponent<GameControl>().GetGameControlState()==GameControl.GameControlState.Gameplay)
        {
            
            if (gamePaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                pausedMenuPanel.SetActive(false);
                mouse.enabled = true;
                startCounter = true;
                gamePaused = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                pausedMenuPanel.SetActive(true);
                startCounter = false;
                mouse.enabled = false;
                gamePaused = true;
            }
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
        gameControl.GetComponent<GameControl>().StartGamePlay();
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

    public void StartGetReadyCoroutine()
    {
        StartCoroutine("GetReady");
    }

    //GET READY AND CLICK TO START COUROUTINE FUNCTIONS//
    
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
            else if(settings.crosshairtypeValue==1)
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

    //RESULTS PANEL OUTPUT FUNCTION//
    public void results()
    {
        ResultsPanel.SetActive(true);
        shotsFiredText.text = mouse.shotsFired.ToString();
        targetHitsText.text = targetShooter.TargetHit.ToString();
        if (targetShooter.TargetHit == 0)
        {
            accuracyText.text = "0";
        }
        else
        {
            accuracyText.text = ((int)(((float)targetShooter.TargetHit / (float)mouse.shotsFired) * 100)).ToString();
        }
        scoreText.text = targetShooter.gameObject.GetComponent<TargetShooter>().score.ToString();
    }
    
    public void OnClickSettingGoBack()
    {
        if (gamePaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            pausedMenuPanel.SetActive(false);
            mouse.enabled = true;
            startCounter = true;
            gamePaused = false;
        }
    }
}
