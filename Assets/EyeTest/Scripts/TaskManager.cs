using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EyeTest.Data;

namespace EyeTest
{
    public class TaskManager : Singleton<TaskManager>
    {
        
        public string subjectID;

        public int numTrials,numBlocks,block;

        public State State;

        private void Start()
        {
            StartCoroutine(StartCo());
        }

        private IEnumerator StartCo()
        {
            yield return StartCoroutine(DataManager.Setup(subjectID));
            SetState(new Initialize());
        }

        public void SetState(State state)
        {
            Debug.Log(state);

            State = state;
            StartCoroutine(State.Start());
        }
    }
}
