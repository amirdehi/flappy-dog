using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject startPanel;
    public GameObject lostPanel;
    public TMP_Text inGameScoreText;
    public TMP_Text finalScoreText;
    public int score = 0;
    public static bool isGameRunning = false;

    private Vector3 startPosition;

    private void Start()
    {
        startPanel.SetActive(true);
        if (dog != null)
        {
            startPosition = dog.transform.position;
            dog.SetActive(false);
        }
        lostPanel.SetActive(false);
        score = 0;
        UpdateScoreUI();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        lostPanel.SetActive(false);

        dog.transform.position = startPosition;
        dog.SetActive(true);

        isGameRunning = true;
        score = 0;
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }
    void IncreaseScore()
    {
        if (isGameRunning)
        {
            score++;
            UpdateScoreUI();
        }
    }

    public void GameOver()
    {
        isGameRunning = false;
        dog.SetActive(false);
        lostPanel.SetActive(true);
        CancelInvoke("IncreaseScore");
        finalScoreText.text = "" + score;
    }

    public void ResetGame()
    {
        CancelInvoke("IncreaseScore");
        score = 0;
        UpdateScoreUI();
        StartGame();
    }

    public void WatchAdToContinue()
    {
        /*if (Advertisement.IsReady(adUnitId))
        {
            Advertisement.Show(adUnitId, new ShowOptions { resultCallback = HandleAdResult });
        }
        else
        {
            Debug.Log("Ad not available, restarting game.");
            ResetGame();
        }*/
    }

    private void HandleAdResult(/*ShowResult result*/)
    {
        /*if (result == ShowResult.Finished)
        {
            Debug.Log("Ad watched! Continuing game.");
            ContinueGame();
        }
        else
        {
            Debug.Log("Ad skipped. Restarting game.");
            ResetGame();
        }*/
    }

    private void ContinueGame()
    {
        isGameRunning = true;
        lostPanel.SetActive(false);
        dog.transform.position = startPosition;
        dog.SetActive(true);
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    private void UpdateScoreUI()
    {
        inGameScoreText.text = "" + score;
    }
}
