using System.Collections;

namespace EyeTest
{
    public class StartBlock : State
    {
       public StartBlock(TaskManager taskManager): base(taskManager)
       {

       }

        public override IEnumerator Start()
        {
            TaskManager.trial = 0;

            TaskManager.SetState(new StartTrial(TaskManager));

            yield return null;
        }
    }
}

