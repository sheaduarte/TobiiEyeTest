using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace EyeTest.Data
{
    public class DataManager : Singleton<DataManager>
    {
        public static string SubjectID, DataPath, SubjectDataPath, TimeStamp;

        public TrialData trialData;
        public TobiiEyeData eyeData;

        public static IEnumerator Setup(string subjectID)
        {
            SubjectID = subjectID;
            DataPath = Path.Combine(Application.dataPath, "..", "..", "Data");
            SubjectDataPath = Path.Combine(DataPath, SubjectID);
            Directory.CreateDirectory(DataPath);
            Directory.CreateDirectory(SubjectDataPath);
            TimeStamp = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss");

            yield return null;
        }

    }
}
