using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour{

    public GameObject selected; // Contains the spawned object that is selected by the user via touch.
    private static SelectManager instance;
    private static readonly object padlock = new object(); // simple thread-safety

    // A singleton is a class which only allows a single instance of itself
    // to be created, and usually gives simple access to that instance.
    // This essentially acts as a global variable and allows the Spawnable
    // Manager Script to access the current selected furniture game object
    // stored in the selected attribute and enable the floater script attached
    // to the object so that it can float and indicate to the user that the object
    // is currently selected.
    public static SelectManager Instance{
        get{
            lock (padlock){
                if (instance == null){
                    instance = FindObjectOfType<SelectManager>();
                }
                return instance;
            }
        }
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}
}
