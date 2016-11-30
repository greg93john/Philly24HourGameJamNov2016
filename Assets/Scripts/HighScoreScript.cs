using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour {
    private Text highScore;
    private int highestRecordedScore;
    private int yourScore;

	// Use this for initialization
	void Start () {
        highScore = GetComponent<Text>();
        highestRecordedScore = PlayerPrefsManager.GetHighScore();
        yourScore = ScoreKeeper.GetScore();

        DetermineHighScore();
	}
	
    void DetermineHighScore() {
        if (yourScore > highestRecordedScore) {
            highestRecordedScore = yourScore;
            PlayerPrefsManager.SetHighScore(highestRecordedScore);
        }

        ShowHighScore();
    }

    void ShowHighScore() {
        highScore.text = "High Score: " + highestRecordedScore.ToString();
    }

}
