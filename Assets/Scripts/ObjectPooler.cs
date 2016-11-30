using UnityEngine;
using System.Collections;

public class ObjectPooler : MonoBehaviour {

    // public variables

    [Tooltip("cannot use interger less than 5")]
    public int pooledAmount;

    [Tooltip("size of array must be AT LEAST 1")]
    public GameObject[] pooledObjects;

    [Tooltip("Don't bother editing this. Made public for another script to access list.")]
    public GameObject[] poolList;

    public Transform[] objectSpawner;

    // private variables
    private ScoreKeeper theScore;

    void Awake() {
        GameObject BallsParent = GameObject.Find("Ball List");
        if (!BallsParent) {
            BallsParent = new GameObject("Ball List");
        }

        poolList = new GameObject[pooledAmount];
        int x = 0;

        for(int i = 0; i < pooledAmount; i++) {
            if(x >= pooledObjects.Length) {
                x = 0;
            }
            poolList[i] = (GameObject)Instantiate(pooledObjects[x]);
            poolList[i].transform.parent = BallsParent.transform;
            poolList[i].SetActive(false);
            x++;
        }
    }

    void Start() {
        theScore = GameObject.FindObjectOfType<ScoreKeeper>().GetComponent<ScoreKeeper>();
    }

    public GameObject GetPooledObject (int choice) {
        if (!poolList[choice].activeInHierarchy) {
            return poolList[choice];
        } else { return null; }
    }

    public void SpawnObject (GameObject spawningObject) {
        Debug.Log("Spawning Boulder and adding to score");
        theScore.AddToScore(1);
        BallScript thisBallScript = spawningObject.GetComponent<BallScript>();
        ScaleShifter scaleShift = GameObject.FindObjectOfType<ScaleShifter>().GetComponent<ScaleShifter>();

        scaleShift.ShiftObjectScale(spawningObject);

        int i = Random.Range(0, objectSpawner.Length);
        spawningObject.transform.position = objectSpawner[i].transform.position;
        spawningObject.SetActive(true);

        thisBallScript.LaunchBall(-1f);
    }
}