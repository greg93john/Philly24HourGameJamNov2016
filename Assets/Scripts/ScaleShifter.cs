using UnityEngine;
using System.Collections;

public class ScaleShifter : MonoBehaviour {
    // public variables

    // private variables
    private int objectSelector, spawnCounter;
    private ObjectPooler objectPool;
    private Vector3 scaleChange;
    private GameObject givenObject;
    private GameObject[] objectListing;
    private bool spawningObjects;

    void Start () {
        InitializePrivateVariables();
    }

    public void SelectAnObjectWithDelay(float objectSelectDelay) {
            Debug.Log("Starting spawn of next wave, with delay of: " + objectSelectDelay);
            Invoke("SelectAnObject", objectSelectDelay);
            spawningObjects = false;   
    }

    public void SelectAnObject () {
        DetermineSpawnCounter();
        int previousSpawn = -1;

        for (int i = 0; i < spawnCounter; i++) {
            objectSelector = Random.Range(0, objectListing.Length);

            if(objectSelector == previousSpawn) {
                if(objectSelector == 0) { objectSelector++; } 
                else if (objectSelector == objectListing.Length - 1) { objectSelector--;} 
                else { objectSelector++; }
            }

            previousSpawn = objectSelector;

            givenObject = objectPool.GetPooledObject(objectSelector);

            if (givenObject == null) {
                i--;
            }

            SpawnSelectedObject();
        }
        Debug.Log("Finished spawning Objects. Setting trigger to allow next wave.");
        spawningObjects = true;
    }

    public void ShiftObjectScale (GameObject selectedObject) {
        int scaleSize = Random.Range(1, 5);
        if(scaleSize == 2) {
            scaleSize++;
        }
        scaleChange.x = (float)scaleSize;
        scaleChange.y = (float)scaleSize;

        selectedObject.transform.localScale = scaleChange;
    }

    void SpawnSelectedObject() {
        objectPool.SpawnObject(givenObject);
    }

    void DetermineSpawnCounter() {
        if(ScoreKeeper.GetScore() < 10) {
            spawnCounter = 1;
        } else if(ScoreKeeper.GetScore() >= 10 && ScoreKeeper.GetScore() < 20) {
            spawnCounter = 2;
        } else {
            spawnCounter = 3;
        }
    }

    void InitializePrivateVariables() {
        DetermineSpawnCounter();
        objectPool = GameObject.FindObjectOfType<ObjectPooler>().GetComponent<ObjectPooler>();
        objectListing = new GameObject[objectPool.poolList.Length];
        objectListing = objectPool.poolList;
        spawningObjects = true;
        Invoke("SelectAnObject", 5f);
    }
}
