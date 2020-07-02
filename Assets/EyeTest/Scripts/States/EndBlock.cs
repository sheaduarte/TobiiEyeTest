using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class EndBlock : State
    {
        public EndBlock(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {
            if(TaskManager.block < TaskManager.numBlocks)
            {
                TaskManager.SetState(new StartTrial(TaskManager));
            }
            else
            {
                TaskManager.SetState(new EndBlock(TaskManager));
            }

            yield return null;
        }

    }
}

