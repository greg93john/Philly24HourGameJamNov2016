using UnityEngine;
using System.Collections;

public class StartMenuMusicTrigger : MonoBehaviour {
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        StartMenuMusic();
	}

    public void StartMenuMusic() {
        musicManager.OnLevelWasLoaded(0);
    }
}
