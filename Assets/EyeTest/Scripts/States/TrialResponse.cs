﻿using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class TrialResponse : State
    {


        public TrialResponse(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {

            yield return new WaitForSeconds(3f);
            yield return TaskManager.StartCoroutine(ShowSliderPrompt());

            // Go to text state
            TaskManager.SetState(new EndTrial(TaskManager));

        }

        public IEnumerator ShowSliderPrompt()
        {

            TaskManager.sliderController.enabled = true;

            while (TaskManager.sliderController.enabled)
            {
                yield return null;
            }
        }

    }
}

