using System.Collections;
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
            // Break between Spawn Controller and GUI
            yield return new WaitForSeconds(3f);

            yield return TaskManager.StartCoroutine(ShowSliderPrompt());

            // Go to text state
            TaskManager.SetState(new EndTrial(TaskManager));

        }

        public IEnumerator ShowSliderPrompt()
        {

            SliderController.Instance.enabled = true;

            while (SliderController.Instance.enabled)
            {
                yield return null;
            }

            DataManager.Instance.WriteDataRow();
        }

    }
}

