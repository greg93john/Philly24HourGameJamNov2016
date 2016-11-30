using UnityEngine;
using System.Collections;

public class RestartMenuMusic : MonoBehaviour {
    private MusicManager musicManager;

    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
    }

    public void StartMenuMusic() {
        musicManager.OnLevelWasLoaded(0);
    }

}
