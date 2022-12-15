// This script was completed with the assistance of the Youtube Tutorial:
// https://www.youtube.com/watch?v=-Ad_jfl4Wjk&list=PLb1h4A0yB978SQuAeBsxup--7ITPCashH&index=6&t=778s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureButtonManager : MonoBehaviour{

    public Button furnitureButton; // Refers to the current scroll bar buttton the script is attacted to.
    public GameObject furniture; // Refers to the furniture prefab attached to the button .

    // Start is called before the first frame update
    void Start(){
        Button button = furnitureButton.GetComponent<Button>();
        button.onClick.AddListener(SelectFurniture);
    }

    // Update is called once per frame
    void Update(){}

    public void SelectFurniture(){
        // When the button is clicked, the furniture attribute in the PrefabManager
        // singleton will be updated with with the furniture prefab stored in this
        // button that is clicked by the user when selecting a furniture object to
        // spawn on the AR Plane. This furniture attribute will later be accesed
        // in the SpawnableManager script when a user taps the AR plane to spawn
        // the furniture of their choice.
        PrefabManager.Instance.furniture = furniture;
    }
}
