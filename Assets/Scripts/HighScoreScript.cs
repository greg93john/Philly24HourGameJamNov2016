using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour {
    private Text highScore;
    private int highestRecordedScore;

	// Use this for initialization
	void Start () {
        highScore = GetComponent<Text>();
        highestRecordedScore = PlayerPrefsManager.GetHighScore();

        ShowHighScore();
	}
	

    void ShowHighScore() {
        highScore.text = "High Score: " + highestRecordedScore.ToString();
    }

}
