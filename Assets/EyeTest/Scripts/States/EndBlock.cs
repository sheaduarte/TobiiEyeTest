using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class EndBlock : State
    {
        public override IEnumerator Start()
        {
            TaskManager.Instance.block +=1;

            if(TaskManager.Instance.block <TaskManager.Instance.numBlocks)
            {
                TaskManager.Instance.SetState(new StartBlock());
            }
            else
            {
                TaskManager.Instance.SetState(new EndTask());
            }

            yield return null;
        }

    }
}

