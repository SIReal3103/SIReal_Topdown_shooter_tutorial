using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public TextMeshProUGUI score;
    public CanvasGroup canvasGroup;
    bool isShow = false;

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
        isShow = true;
        int scoreI = FindObjectOfType<Killed>().currentKilled * 10;
        score.text = "You get: " + scoreI.ToString() + " Score";
        Time.timeScale = 0;
    }

    public void Hide()
    {
        Time.timeScale = 1;
        isShow = false;
        canvasGroup.alpha = 0;
    }

    private void Update()
    {
        if (isShow && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
