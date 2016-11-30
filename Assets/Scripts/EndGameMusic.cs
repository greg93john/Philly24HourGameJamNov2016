using UnityEngine;
using System.Collections;

public class EndGameMusic : MonoBehaviour {
    private MusicManager musicManager;

    void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        EndTheMusic();
    }

    public void EndTheMusic() {
        Debug.Log("Should Call to stop music");
        musicManager.OnLevelWasLoaded(4);
    }
}
