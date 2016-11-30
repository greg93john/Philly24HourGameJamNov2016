using UnityEngine;
using System.Collections;

public class BallCaveEnterScript : MonoBehaviour {
    private ScaleShifter shiftingMechanisim;

	// Use this for initialization
	void Start () {
        InitilizePrivateVariables();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnAnotherBolder(GameObject dodgedBoulder) {
        Debug.Log("Large Boulder Successfully Dodged Spawning new Boulder");
        dodgedBoulder.SetActive(false);
        shiftingMechanisim.SelectAnObjectWithDelay(2f);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        BallScript ballCheck = collider.gameObject.GetComponent<BallScript>();

        if (collider.gameObject.transform.localScale.x < 3f && ballCheck) {
            collider.gameObject.SetActive(false);
            shiftingMechanisim.SelectAnObjectWithDelay(2f);
        }
    }

    void InitilizePrivateVariables() {
        shiftingMechanisim = GameObject.FindObjectOfType<ScaleShifter>();
    }
}
