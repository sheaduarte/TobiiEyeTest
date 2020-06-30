using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform[] spawnPosList;
    public float spawnTime;
    public float stimulusDuration;
    private bool keyPressed = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !keyPressed)
        {
            //invokerepeating("spawninnewpos", spawntime, spawntime);
            SpawnInNewPos();
            keyPressed = true;
            Debug.Log("pressed");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            keyPressed = false;
        }

    }
    void SpawnInNewPos()
    {
        int objectIndex = Random.Range(0, spawnPosList.Length);
        GameObject stim = Instantiate(spawnObject, spawnPosList[objectIndex].position, Quaternion.identity);
        GameObject.Destroy(stim, stimulusDuration);

    }
}

//OLD
//{
//    public GameObject spawnObject;
//    public Vector3[] spawnPosList;
//    private int spawnTotal;

//    // Start is called before the first frame update
//    private void Start()
//    {
//        spawnPosList = new Vector3[9];

//        spawnPosList[0] = new Vector3 (0, 2, -5);
//        spawnPosList[1] = new Vector3 (0, 2, -7);
//        spawnPosList[2] = new Vector3 (0, 2, -9);
//        spawnPosList[3] = new Vector3 (3, 2, -5);
//        spawnPosList[4] = new Vector3 (3, 2, -7);
//        spawnPosList[5] = new Vector3 (3, 2, -9);
//        spawnPosList[6] = new Vector3 (6, 2, -5);
//        spawnPosList[7] = new Vector3 (6, 2, -7);
//        spawnPosList[8] = new Vector3 (6, 2, -9);


//    }
//    // Update is called once per frame
//    void SpawnInNewPos()
//    {
//        foreach(Vector3 item in spawnPosList)
//        {
//            Instantiate(spawnObject, item, Quaternion.identity);
//        }
//    }

//    private void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Space))
//        {
//            SpawnInNewPos();
//        }
//    }
//}


/// create a list of 9 vector3 spawn positions 
/// spawn object (prefab) in one random position from list
/// on gaze, instantiate slider bar
/// on slider bar response, destroy object
/// on destroy object/response, spawn new object in random new location from list
/// repeat until all locations have been exhausted