using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //
    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
        scoreText.text = $"Score: \n{score}";
    }
}
