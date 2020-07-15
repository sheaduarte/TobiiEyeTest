using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EyeTest
{
    public class SpawnController : Singleton<SpawnController>
    {
        public GameObject spawnObject;
        public Vector3[] spawnPosList;
        private int spawnTotal;
        private List<GameObject> objectList;

        // Start is called before the first frame update
        private void Start()
        {
            spawnPosList = new Vector3[9];

            spawnPosList[0] = new Vector3(0, 2, -5);
            spawnPosList[1] = new Vector3(0, 2, -7);
            spawnPosList[2] = new Vector3(0, 2, -9);
            spawnPosList[3] = new Vector3(3, 2, -5);
            spawnPosList[4] = new Vector3(3, 2, -7);
            spawnPosList[5] = new Vector3(3, 2, -9);
            spawnPosList[6] = new Vector3(6, 2, -5);
            spawnPosList[7] = new Vector3(6, 2, -7);
            spawnPosList[8] = new Vector3(6, 2, -9);
        }

        public void SpawnInNewPos()
        {
            objectList = new List<GameObject>();
            GameObject newGameObject = Instantiate(spawnObject, spawnPosList[Random.Range(0, spawnPosList.Length)], Quaternion.identity);
            objectList.Add(newGameObject);
        }


        public void DestroyAllObjects()
        {
            foreach (var item in objectList)
            {
                Destroy(item);
            }
        }
    }

}