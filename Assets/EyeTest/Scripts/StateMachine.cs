using UnityEngine;

namespace EyeTest
{

    public abstract class StateMachine : Singleton<StateMachine>
    {
        protected State State;

        public void SetState(State state)
        {
            Debug.Log(state);

            State = state;
            StartCoroutine(State.Start());
        }
    }
}
