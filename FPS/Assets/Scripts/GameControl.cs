using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public TargetShooter ShooterScipt;

    public static int score, targetsHit;

    private float accuracy, shotsFired;

    public Text GetReadyText, scoreText, targetsHitText, shotsFiredText, accuracyText;

    public GameObject resultsPanel;

    private void Start()
    {
        GetReadyText.gameObject.SetActive(false);
    }
    private IEnumerator GetReady()
    {
        for(int i = 3; i >= 1; i--)
        {
            GetReadyText.text = "Get Ready!\n" + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        GetReadyText.text = "Go!";
        yield return new WaitForSeconds(1f);

        StartCoroutine("SpawnTargets");
    }
    void Update()
    {
        
    }

    public void StartGetReadyCoroutine()
    {
        resultsPanel.SetActive(false);
        GetReadyText.gameObject.SetActive(true);
        StartCoroutine("GetReady");
    }
}
