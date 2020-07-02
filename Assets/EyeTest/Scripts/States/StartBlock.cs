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
            yield break;
        }
    }
}

