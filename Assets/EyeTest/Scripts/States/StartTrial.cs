﻿using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class StartTrial : State
    {
       public StartTrial(TaskManager taskManager): base(taskManager)
       {

       }

        public override IEnumerator Start()
        {
            SpawnController.Instance.SpawnInNewPos();

            yield return null;

            // Go to text state
            TaskManager.SetState(new TrialResponse(TaskManager));
        }

    }
}

