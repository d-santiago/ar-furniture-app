using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAllManager : MonoBehaviour{
    
    public Button clearButton; // Refers to the current scroll bar buttton the script is attacted to.
    private GameObject[] spawnedFurniture; // Contains all spawned furniture (i.e. all game objects tagged with "Spawnable")

    // Start is called before the first frame update
    void Start(){
        Button button = clearButton.GetComponent<Button>();
		button.onClick.AddListener(ClearAllSpawnables);
    }

    // Update is called once per frame
    void Update(){}

    void ClearAllSpawnables(){
        // Retrieve all spawned furniture game objects that are tagged with "Spawnable".
        spawnedFurniture = GameObject.FindGameObjectsWithTag("Spawnable");

        // If there are spawnable furniture objects, destroy each spawnable furniture object.
        if (spawnedFurniture.Length > 0){
            foreach(GameObject spawnable in spawnedFurniture){
                GameObject.Destroy(spawnable);
            }
        }
	}
}