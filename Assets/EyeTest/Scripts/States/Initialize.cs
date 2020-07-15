using System.Collections;

namespace EyeTest
{
    public class Initialize : State
    {
        public Initialize(TaskManager taskManager) : base(taskManager)
        {

        }

        public override IEnumerator Start()
        {

            DataManager.Instance.EnableDataWriter();

            yield return null;

            TaskManager.SetState(new StartBlock(TaskManager));
        }
    } 
}
