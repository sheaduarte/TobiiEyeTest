using System.Collections;
using UnityEngine;
using EyeTest.Data;

namespace EyeTest
{
    public class EndTrial : State
    {

        public override IEnumerator Start()
        {
            // Butterfly to spawn
            SpawnController.Instance.DestroyAllObjects();

            // Advance trial counter
            DataManager.Instance.trialData.trial += 1;


            // Go to text state
            if (DataManager.Instance.trialData.trial < TaskManager.Instance.numTrials)
            {
                TaskManager.Instance.SetState(new ITI());
            }
            else
            {
                TaskManager.Instance.SetState(new EndBlock());
            }

            yield return null;

        }

    }
}

