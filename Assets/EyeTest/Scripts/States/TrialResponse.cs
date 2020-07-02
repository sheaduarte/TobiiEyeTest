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

            yield return new WaitForSeconds(2f);
            yield return TaskManager.StartCoroutine(ShowSliderPrompt());

            // Go to text state
            TaskManager.SetState(new EndTrial(TaskManager));

        }

        public IEnumerator ShowSliderPrompt()
        {
            //Debug.Log("Show slider prompt");

            //while (!_isDataLogged)
            //{
            //    yield return null;
            //}

            //Debug.Log("Data is logged.");

            //yield return new WaitForSeconds(1f);
            //_isDataLogged = false;

            TaskManager.sliderController.enabled = true;
            yield return null;
        }

    }
}

