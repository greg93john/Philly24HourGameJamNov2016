using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
    // public variables

    // privae variables
    private Text scoreDisplay;
    private GameObject player;
    private bool playing;
    static private int scoreAmount, highScore;


    // Use this for initialization
    void Start() {
        InitializeVariables();
    }

    // Update is called once per frame
    void Update() {

        playing = player;

        if (playing) {
            scoreDisplay.text = "Boulders: " + scoreAmount.ToString();
        } else { CheckHighScore(); }
    }

    public void AddToScore(int score) {
        scoreAmount += score;
    }

    public static int GetScore() {
        return scoreAmount;
    }

    public void CheckHighScore() {
        if(scoreAmount > highScore) {
            PlayerPrefsManager.SetHighScore(scoreAmount);
        }
    }

    private void InitializeVariables() {
        scoreDisplay = GetComponent<Text>();
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        scoreAmount = 0;
        highScore = PlayerPrefsManager.GetHighScore();
    }
}
