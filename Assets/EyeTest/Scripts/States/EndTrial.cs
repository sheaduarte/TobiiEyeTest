using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class EndTrial : State
    {
        public EndTrial(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {
            // Butterfly to spawn
            SpawnController.Instance.DestroyAllObjects();

            // Advance trial counter
            DataManager.Instance.trial += 1;


            // Go to text state

            if (DataManager.Instance.trial < TaskManager.numTrials)
            {
                TaskManager.SetState(new ITI(TaskManager));
            }
            else
            {
                TaskManager.SetState(new EndBlock(TaskManager));
            }

            yield return null;

        }

    }
}

