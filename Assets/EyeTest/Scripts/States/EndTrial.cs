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
            TaskManager.spawnController.DestroyAllObjects();

            // Advance trial counter
            TaskManager.trial += 1;

            yield return null;

            // Go to text state

            if(TaskManager.trial < TaskManager.numTrials)
            {
                TaskManager.SetState(new StartTrial(TaskManager));
            }
            else
            {
                TaskManager.SetState(new EndBlock(TaskManager));
            }

        }

    }
}

