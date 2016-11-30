using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private PlayerController player;
    private BallCaveEnterScript caveScript;


	// Use this for initialization
	void Start () {
        InitializePrivateVariables();
	}

    void OnTriggerEnter2D( Collider2D collider) {
        BallScript ball = collider.gameObject.GetComponent<BallScript>();

        if (ball && collider.gameObject.transform.localScale.x < 3) {
            player.PlayerHasLost();
            Destroy(collider.gameObject);
        } else if (ball && collider.gameObject.transform.localScale.x >= 3) {
            caveScript.SpawnAnotherBolder(collider.gameObject);
        }

    }

    void InitializePrivateVariables () {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject.GetComponent<PlayerController>();
        caveScript = GameObject.FindObjectOfType<BallCaveEnterScript>().GetComponent<BallCaveEnterScript>();
    }
}
