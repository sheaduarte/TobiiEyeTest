using System.Collections;

namespace EyeTest
{
    public class Instruction1 : State
    {
       public Instruction1(TaskManager taskManager): base(taskManager)
       {

       }

        public override IEnumerator Start()
        {
            yield break;
        }
    }
}

