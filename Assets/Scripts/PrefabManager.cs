// This script was completed with the assistance of the YouTube Tutorial:
// https://www.youtube.com/watch?v=-Ad_jfl4Wjk&list=PLb1h4A0yB978SQuAeBsxup--7ITPCashH&index=5&t=598s
// and https://csharpindepth.com/articles/singleton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour{

    public GameObject furniture;  // Contains the furniture prefab that the user has selected via the buttons in the scroll bar.
    private static PrefabManager instance;
    private static readonly object padlock = new object(); // simple thread-safety

    // A singleton is a class which only allows a single instance of itself
    // to be created, and usually gives simple access to that instance.
    // This essentially acts as a global variable and allows the Spawnable
    // Manager Script to spawn an object using the prefab stored in the
    // furniture attribute. This also allows the Furniture Button Manager
    // Script to update the furniture attribute with the furniture prefab
    // stored in the button that is clicked by the user when they are selecting
    // a furniture object to spawn on the AR Plane.
    public static PrefabManager Instance{
        get{
            lock (padlock){
                if (instance == null){
                    instance = FindObjectOfType<PrefabManager>();
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
