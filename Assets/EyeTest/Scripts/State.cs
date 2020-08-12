using System.Collections;

namespace EyeTest
{
    public abstract class State
    {
        public virtual IEnumerator Start()
        {

            yield break;
        }
    }
}
