using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] List<Pin> pins;
    [SerializeField] Ball ball;
    int score = 0;
    [SerializeField] TMP_Text scoreText, roundText, finalScoreText;
    [SerializeField] int round = 1, maxRound = 5;
    [Space]
    [SerializeField] float resetDelay = 1.5f;
    [Space]
    [SerializeField] GameObject nextScreen;

    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);

        roundText.text = $"Ronde: {round}/{maxRound}";
    }

    public void ResetPins()
    {
        foreach (Pin p in pins)
        {
            p.GetRigidBody().isKinematic = true;
            p.ResetPin();
            p.GetRigidBody().isKinematic = false;
        }
    }

    public IEnumerator NextRound()
    {
        yield return new WaitForSeconds(resetDelay);
        ball.Reset();
        if (round == maxRound)
        {
            foreach (Pin p in pins) p.gameObject.SetActive(false);
            ball.GetGrab().enabled = false;
            finalScoreText.text = $"Score: {score}";
            nextScreen.SetActive(true);
            yield break;
        }
        ResetPins();
        round++;
        roundText.text = $"Ronde: {round}/{maxRound}";
    }
    public void AddScore(Pin p)
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    public int GetScore() { return score; }
}
