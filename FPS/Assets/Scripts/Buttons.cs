using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public UIelements UI;

    public InputField sensInputField;
    
    public Slider sensSlider;

    public UIelements ui;

    public Toggle fullScreenToggle;

    public Dropdown ResolutionDropdown;
    public Dropdown crosshairColorDropdown;
    public Dropdown crosshairTypeDropdown;

    public GameObject mainMenu;
    public GameObject settingsMenu;


    public SettingsScript settings;

    public Color crosshairColor;

    public Image centerDotCrosshairImage;
    public Image leftCrosshair;
    public Image rightCrosshair;
    public Image upCrosshair;
    public Image downCrosshair;

    public bool _fullscreenCheck;

    private int _crosshairColorValue;
    public int _val;

    private void Awake()
    {
        //if (settings.crosshairtypeValue == 0)
        //{
        //    centerDotCrosshairImage.gameObject.SetActive(true);
        //    leftCrosshair.gameObject.SetActive(false);
        //    rightCrosshair.gameObject.SetActive(false);
        //    upCrosshair.gameObject.SetActive(false);
        //    downCrosshair.gameObject.SetActive(false);
        //}
        //if (settings.crosshairtypeValue == 1)
        //{
        //    centerDotCrosshairImage.gameObject.SetActive(false);
        //    leftCrosshair.gameObject.SetActive(true);
        //    rightCrosshair.gameObject.SetActive(true);
        //    upCrosshair.gameObject.SetActive(true);
        //    downCrosshair.gameObject.SetActive(true);
        //}

        crosshairColor = settings.crosshairColor;
        _crosshairColorValue = settings.crosshairColorValue;

        //if (_crosshairColorValue == 0)
        //{
        //    settings.crosshairColor = new Color(1, 1, 1, crosshairColor.a);
        //}
        //if (_crosshairColorValue == 1)
        //{
        //    settings.crosshairColor = new Color(0, 0, 1, crosshairColor.a);
        //}
        //if (_crosshairColorValue == 2)
        //{
        //    settings.crosshairColor = new Color(0, 1, 0, crosshairColor.a);

        //}

        sensInputField.text = settings.MouseSens.ToString();
        
        Screen.SetResolution(1920, 1080, true);
    }
    private void Update()
    {
        crosshairTypeDropdown.value = settings.crosshairtypeValue;
        crosshairColorDropdown.value = settings.crosshairColorValue;

        centerDotCrosshairImage.color = settings.crosshairColor;
        leftCrosshair.color = settings.crosshairColor;
        rightCrosshair.color = settings.crosshairColor;
        upCrosshair.color = settings.crosshairColor;
        downCrosshair.color = settings.crosshairColor;
        crosshairColor = settings.crosshairColor;

        sensSlider.value = settings.MouseSens;
        
    }

    public void OnColorChange(int v)
    {
        settings.crosshairColorValue = v;
        if (v == 0)
        {
            settings.crosshairColor = Color.white;
        }
        if (v == 1)
        {
            settings.crosshairColor = Color.blue;
        }
        if (v == 2)
        {
            settings.crosshairColor = Color.green;
        }
    }

    public void OnCrosshairChange(int c)
    {
        settings.crosshairtypeValue = c;
        if(uiele)
        if (c == 0)
        {
            centerDotCrosshairImage.gameObject.SetActive(true);
            leftCrosshair.gameObject.SetActive(false);
            rightCrosshair.gameObject.SetActive(false);
            upCrosshair.gameObject.SetActive(false);
            downCrosshair.gameObject.SetActive(false);
        }
        if (c == 1)
        {
            centerDotCrosshairImage.gameObject.SetActive(false);
            leftCrosshair.gameObject.SetActive(true);
            rightCrosshair.gameObject.SetActive(true);
            upCrosshair.gameObject.SetActive(true);
            downCrosshair.gameObject.SetActive(true);
        }

    }




    public void onSensChange(string v)
    {
        settings.MouseSens = float.Parse(v);
    }

    public void OnSensSliderChange(float v)
    {
        v = Mathf.Round(v * 100) / 100;
        settings.MouseSens = v;
        sensInputField.text = v.ToString();
    }

    public void onClickSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene(1);
        mainMenu.SetActive(false);
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

 

    public void onClickGoBack()
    {
        if (settingsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void resolutionChange(int val)
    {
        val = ResolutionDropdown.value;
        _val = val;
        if (_fullscreenCheck)
        {
            if (_val == 0)
            {
                Screen.SetResolution(1920, 1080,true);
            }

            if (_val == 1)
            {
                Screen.SetResolution(2560, 1440, true);
            }

            if (_val == 2)
            {
                Screen.SetResolution(1280, 720, true);
            }
        }
        else
        {
            if (_val == 0)
            {
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
            }

            if (_val == 1)
            {
                Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
            }

            if (_val == 2)
            {
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
            }
        }
        
    }

    public void onToggleFullscreen(bool check)
    {
        check = fullScreenToggle.isOn;
        _fullscreenCheck = check;
        if (_fullscreenCheck)
        {
            if (_val == 0)
            {
                Screen.SetResolution(1920, 1080, true);
            }

            if (_val == 1)
            {
                Screen.SetResolution(2560, 1440, true);
            }

            if (_val == 2)
            {
                Screen.SetResolution(1280, 720, true);
            }    
        }
        else
        {
            if (_val == 0)
            {
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
            }

            if (_val == 1)
            {
                Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
            }

            if (_val == 2)
            {
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
            }
        }

    }


    public void onClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
