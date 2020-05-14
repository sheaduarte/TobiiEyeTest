using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/// create a list of 9 vector3 spawn positions 
/// spawn object (prefab) in one random position from list
/// on gaze, instantiate slider bar
/// on slider bar response, destroy object
/// on destroy object/response, spawn new object in random new location from list
/// repeat until all locations have been exhausted