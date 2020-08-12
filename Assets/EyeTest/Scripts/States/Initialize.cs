using System.Collections;
using EyeTest.Data;

namespace EyeTest
{
    public class Initialize : State
    {
        public override IEnumerator Start()
        {

            DataManager.Instance.trialData.EnableDataWriter();
            DataManager.Instance.eyeData.EnableDataWriter();


            yield return null;

            TaskManager.Instance.SetState(new StartBlock());
        }
    } 
}
