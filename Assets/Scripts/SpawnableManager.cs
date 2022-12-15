// This script was completed with the assistance of the Unity Learn Tutorial:
// https://learn.unity.com/tutorial/placing-and-manipulating-objects-in-ar#
// and YouTube Tutorial:
// https://www.youtube.com/watch?v=A7woL0oZCnA&list=PLb1h4A0yB978SQuAeBsxup--7ITPCashH&index=6&t=438s
// and Unity Forum:
// https://answers.unity.com/questions/1032395/how-to-prevent-touch-going-through-ui.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class SpawnableManager : MonoBehaviour{
    
    [SerializeField] ARRaycastManager m_RaycastManager;
    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    private Camera arCam;

    private Touch touch;

    private GameObject spawnedObject;
    private GameObject previousSpawned;

    private FloatManager floater;
    private FloatManager previousFloater;

    // Start is called before the first frame update
    void Start(){
        // No objects are spawned initially.
        spawnedObject = null; 
        previousSpawned = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update(){
        // Store user's touch.
        touch = Input.GetTouch(0);

        RaycastHit hit;
        // Returns a ray going from camera through a screen point.
        Ray ray = arCam.ScreenPointToRay(touch.position);

        // If the screen is not being touched, no further actions are required.
        if (Input.touchCount == 0) return;

        // If the user is touching the screen, their finger is over a UI component,
        // do not attempt to spawn or select any objects. No further action is required.
        if (IsPointerOverUI(touch)) return;

        if (m_RaycastManager.Raycast(touch.position, m_Hits)){

            // Returns true the user just began touching the screen.
            if (touch.phase == TouchPhase.Began){

                // Returns true if the ray intersects with a collider, otherwise false.
                if (Physics.Raycast(ray, out hit)){
                    
                    // An object is either about to be spawned or selected, meaning
                    // that the spawnedObject variable will be updated. Store the
                    // currently spawned object in a previouslySpawned variable to
                    // prevent it from floaitng when it is no longer selected.
                    previousSpawned = spawnedObject;

                    // If the user's touch has collided with the AR Plane, spawn a
                    // new game object (furniture) where the user touched the screen.
                    if (hit.transform.gameObject.tag == "Plane"){
                        previousSpawned = spawnedObject;
                        SpawnPrefab(m_Hits[0].pose.position);
                    }

                    // If the user's touch has collided with another spawnable
                    // object, do not  spawn a new game object (furniture) because
                    // that woudl create overlap. In the context of this project,
                    // tapping a spawned object means that the user would like to
                    // select the object.
                    
                    // Set the selected object to the object that the user just
                    // touched. When an object is selected, it begins to float to
                    // indicate its selection to the user.
                    else if (hit.transform.gameObject.tag == "Spawnable"){
                        spawnedObject = hit.transform.gameObject;
                        SelectManager.Instance.selected = spawnedObject;
                        enableFloatation();
                    }
                }
            }
        }
    }     

    private bool IsPointerOverUI(Touch touch){
        // If the user is touching the screen, their finger is over a UI component,
        // do not attempt to spawn or select any objects. No further action is required.
        // Returns true of user is touching UI.
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void SpawnPrefab(Vector3 spawnPosition){
        // Instantiate a new spawned object on the AR Plane at the location
        // that the user requested through touch. Update the new spawned
        // object's tag to "Spawnable" so that if touched in the future,
        // the program can identify that the user wants to reselect the object.
        // Set the spawned object to be the selected object. An object that is
        // spawned is automatically selected, so floatation on the object is enabled.
        spawnedObject = Instantiate(PrefabManager.Instance.furniture, spawnPosition, Quaternion.identity);
        spawnedObject.tag = "Spawnable";
        SelectManager.Instance.selected = spawnedObject;
        enableFloatation();
    }

    private void enableFloatation(){
        // If there is a previously spawned object, retrieve the floating 
        // script attached to the object and disable it.
        if (previousSpawned != null){
            previousFloater = previousSpawned.GetComponent<FloatManager>();
            previousFloater.enabled = false;
        }
        // Retrieve the floating script attached to the current spawned
        // object and enable it.
        floater = spawnedObject.GetComponent<FloatManager>();
        floater.enabled = true;
    }    
}
