using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class StartTrial : State
    {
        private bool _gazeObjectDetected;

       public StartTrial(TaskManager taskManager): base(taskManager)
       {

       }

        public override IEnumerator Start()
        {
            _gazeObjectDetected = false;
            GameObject newObject = SpawnController.Instance.SpawnInNewPos();
            ObjectGazeDetection objectGaze = null;

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

            objectGaze.onNewGazeDetected -= GazeObjectDetected;


            // Go to text state
            TaskManager.SetState(new TrialResponse(TaskManager));
        }

        private void GazeObjectDetected()
        {
            _gazeObjectDetected = true;
        }

    }
}

