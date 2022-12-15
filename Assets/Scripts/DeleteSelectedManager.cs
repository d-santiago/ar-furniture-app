using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class DeleteSelectedManager : MonoBehaviour{
    
    public Button deleteButton; // Refers to the current scroll bar buttton the script is attacted to.
    private GameObject spawnable; // Refers to the selected spawnable furniture game object.

    // Start is called before the first frame update
    void Start(){
        Button button = deleteButton.GetComponent<Button>();
		button.onClick.AddListener(DeleteSelectedSpawnable);
    }

    // Update is called once per frame
    void Update(){}

    void DeleteSelectedSpawnable(){
        spawnable = SelectManager.Instance.selected;

        // If there is a spawnable furniture game object, destroy it.
        // Set the selected attribute in the SelectManager singleton to null.
        // When an object is deleted, no object are selected until touched.
        if(spawnable != null){
            GameObject.Destroy(spawnable);
            SelectManager.Instance.selected = null;
        }
    }
}
