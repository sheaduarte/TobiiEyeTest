using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class EndTask : State
    {
        public EndTask(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {

            yield return null;

            Util.QuitRequest();
        }

    }
}

