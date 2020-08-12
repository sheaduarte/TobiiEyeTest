using System.Collections;
using EyeTest.Data;

namespace EyeTest
{
    public class StartBlock : State
    {
        public override IEnumerator Start()
        {
            DataManager.Instance.trialData.trial = 0;
            DataManager.Instance.eyeData.StartCollecting();

            yield return null;

            TaskManager.Instance.SetState(new StartTrial());
        }
    }
}

