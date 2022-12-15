// This code was provided by Donovan Keith and can be found at:
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
// Slight modifications have been made to this code.

// Floater v0.0.2
// by Donovan Keith
// [MIT License](https://opensource.org/licenses/MIT)

using UnityEngine;
using System.Collections;
 
// Makes objects float up & down.
public class FloatManager : MonoBehaviour {

    // User Inputs
    public float amplitude = 0.01f; // Decides the distance an object moves up and down.
    public float frequency = 1f; // Decides quickly the object moves up and down.
 
    // Position Storage Variables.
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();
 
    // Use this for initialization
    void Start(){
        // Store the starting position & rotation of the object.
        posOffset = transform.position;
    }
     
    // Update is called once per frame.
    void Update(){
        // If the user is touching the screen to potentially scale, rotate,
        // or translate the object, reset posOffset initialized in start().
        if (Input.touchCount != 0){
            posOffset = transform.position;
            return;
        }

        // Float up/down with a Sin().
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}