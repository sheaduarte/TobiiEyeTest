using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace EyeTest
{
    public class TaskManager : StateMachine
    {

        private State _priorState;

        // Data related
        List<string> variableList = new List<string>() { "subject", "trial", "response" };
        string dataPath;
        string subjectID = "test";

        public int numTrials = 10;
        public int numBlocks = 0;
        public int block = 0;


        public SliderController sliderController;

        public TaskEvent logDataRow;

        public int trial = 0;


        public SpawnController spawnController;

        private DataController _dataController;

        private void OnEnable()
        {
            logDataRow.Register(LogData);

        }

        private void Start()
        {
            // Setup data writer
            dataPath = Path.Combine(Application.dataPath, "..", "..", "Data");
            _dataController = new DataController(variableList, dataPath, subjectID);
            _dataController.Activate();

        }

        private void OnDisable()
        {
            logDataRow.Deregister(LogData);
            _dataController.Deactivate();
        }


        void LogData()
        {
            float response = sliderController.GetSliderValue();

            _dataController.row["subject"] = subjectID;
            _dataController.row["trial"] = trial.ToString();
            _dataController.row["response"] = response.ToString();
            _dataController.Log();

        }


//        public void QuitRequest()
//        {
//            Debug.Log("Quit request");
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#else
//                                                Application.Quit();
//#endif
//        }


        //IEnumerator TrialSystem()
        //{
        //    // Experimenter menu pops up



        //    trial = 0;
        //    _isDataLogged = false;


        //    while (trial < numTrials)
        //    {
        //        // Butterfly to spawn
        //        spawnController.SpawnInNewPos();
        //        Debug.Log("Spawn butterfly");

        //        // Wait
        //        yield return new WaitForSeconds(2);

        //        yield return StartCoroutine(ShowSliderPrompt());

        //        // Destroy buttterflies
        //        spawnController.DestroyAllObjects();

        //        // Wait
        //        yield return new WaitForSeconds(2);


        //        trial += 1;

        //        yield return null;
        //    }


        //    // Wait a few seconds

        //    // Slider prompt pop up

        //    // Wait for subject response

        //    // Log data

        //}



    }
}
