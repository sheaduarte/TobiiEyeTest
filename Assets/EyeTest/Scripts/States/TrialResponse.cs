using System.Collections;
using UnityEngine;
using EyeTest.Data;

namespace EyeTest
{
    public class TrialResponse : State
    {

        public override IEnumerator Start()
        {
            // Break between Spawn Controller and GUI
            yield return new WaitForSeconds(.2f);

            yield return TaskManager.Instance.StartCoroutine(ShowSliderPrompt());

            DataManager.Instance.trialData.timeResponse = TaskManager.Instance.getTimeSinceStart;

            // Go to text state
            TaskManager.Instance.SetState(new EndTrial());

        }

        public IEnumerator ShowSliderPrompt()
        {

            SliderHandler.Instance.Show();

            while (SliderHandler.Instance.sliderShowing)
            {
                yield return null;
            }

            DataManager.Instance.trialData.WriteDataRow();
        }

    }
}

