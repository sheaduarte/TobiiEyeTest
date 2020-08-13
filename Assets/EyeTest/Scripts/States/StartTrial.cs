using System.Collections;
using EyeTest.Data;
using UnityEngine;

namespace EyeTest
{
    public class StartTrial : State
    {
        private bool _gazeObjectDetected;

        public override IEnumerator Start()
        {
            _gazeObjectDetected = false;
            GameObject newObject = SpawnController.Instance.SpawnInNewPos();
            ObjectGazeDetection objectGaze = null;

            DataManager.Instance.trialData.timeSpawn = TaskManager.Instance.getTimeSinceStart;

            while (objectGaze == null)
            {
                objectGaze = newObject.GetComponentInChildren(typeof(ObjectGazeDetection)) as ObjectGazeDetection;
                yield return null;
            }

            objectGaze.onNewGazeDetected +=GazeObjectDetected;

            while (!_gazeObjectDetected)
            {
                yield return null;
            }

            DataManager.Instance.trialData.timeEyeDetect = TaskManager.Instance.getTimeSinceStart;

            objectGaze.onNewGazeDetected -= GazeObjectDetected;


            // Go to text state
            TaskManager.Instance.SetState(new TrialResponse());
        }

        private void GazeObjectDetected()
        {
            _gazeObjectDetected = true;
        }

    }
}

