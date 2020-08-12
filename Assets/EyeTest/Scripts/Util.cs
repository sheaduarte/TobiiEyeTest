using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace EyeTest
{
    public class Util : MonoBehaviour
    {
        public static void QuitRequest()
        {
            Debug.Log("Quit request");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                                                Application.Quit();
#endif
        }


        public static List<string> EnumToStrings<T>()
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>();
            return values.Select(i => i.ToString()).ToList();
        }

    }
}