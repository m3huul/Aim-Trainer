using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScenarioButton : MonoBehaviour
{
    public VideoPlayer Vid;
    private void Start()
    {
        //Vid = GetComponent<VideoPlayer>();
    }
    private void OnMouseOver()
    {
        Vid.Play();
    }
}
