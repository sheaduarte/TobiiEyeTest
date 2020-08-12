using System.Collections;
using UnityEngine;
using EyeTest.Data;

namespace EyeTest
{
    public class EndTask : State
    {

        public override IEnumerator Start()
        {
            DataManager.Instance.eyeData.StopCollecting();

            yield return null;

            Util.QuitRequest();
        }

    }
}

