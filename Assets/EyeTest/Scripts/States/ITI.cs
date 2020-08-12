using System.Collections;
using UnityEngine;

namespace EyeTest
{
    public class ITI : State
    {
        public override IEnumerator Start()
        {

            yield return new WaitForSeconds(3f);

            // Go to text state
            TaskManager.Instance.SetState(new StartTrial());
        }

    }
}

