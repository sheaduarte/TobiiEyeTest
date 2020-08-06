using System.Collections;

namespace EyeTest
{
    public abstract class State
    {
        protected TaskManager TaskManager;

        public State(TaskManager taskManager)
        {
            TaskManager = taskManager;
        }

        public virtual IEnumerator Start()
        {

            yield break;
        }
    }
}
