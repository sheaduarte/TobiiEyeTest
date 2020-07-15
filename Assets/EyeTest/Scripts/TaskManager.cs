using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EyeTest
{
    public class TaskManager : StateMachine
    {

        public int numTrials = 10;
        public int numBlocks = 0;
        public int block = 0;

        private void Start()
        {

            SetState(new Initialize(this));
        }
    }
}
