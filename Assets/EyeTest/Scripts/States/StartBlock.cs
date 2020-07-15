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
            DataManager.Instance.trial = 0;

            yield return null;

            TaskManager.SetState(new StartTrial(TaskManager));
        }
    }
}

