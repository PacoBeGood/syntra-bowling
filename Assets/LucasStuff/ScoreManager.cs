using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] List<Pin> pins;
    int score = 0;
    [SerializeField] TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);        
    }

    public void Reset()
    {
        Debug.Log("RESET");
        foreach (Pin p in pins)
        {
            if (p.CheckHit()) p.gameObject.SetActive(false);
        }
    }

    public void CheckReset()
    {
        if (score == 10) Reset();
    }
    public void AddScore(Pin p)
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
