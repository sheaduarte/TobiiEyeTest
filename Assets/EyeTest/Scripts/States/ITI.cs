using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class ITI : State
    {
        public ITI(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {

            yield return new WaitForSeconds(3f);

            // Go to text state
            TaskManager.SetState(new StartTrial(TaskManager));
        }

    }
}

