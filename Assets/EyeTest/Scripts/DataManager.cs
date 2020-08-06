using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace EyeTest
{
    public class DataManager : Singleton<DataManager>
    {
        public string subjectID;
        public int trial = 0;

        private DataWriter _dataWriter;
        private string _dataPath;

        List<string> _variableList = new List<string>() { "subject", "trial", "response" };

        private void OnDisable()
        {
            DisableDataWRiter();
        }

        public void EnableDataWriter()
        {
            // Setup data writer
            _dataPath = Path.Combine(Application.dataPath, "..", "..", "Data");
            _dataWriter = new DataWriter(_variableList, _dataPath, subjectID);
            _dataWriter.Activate();
        }

        public void DisableDataWRiter()
        {
            _dataWriter.Deactivate();
        }

        public void WriteDataRow()
        {

            float response = SliderController.Instance.GetSliderValue();

            _dataWriter.row["subject"] = subjectID;
            _dataWriter.row["trial"] = trial.ToString();
            _dataWriter.row["response"] = response.ToString();
            _dataWriter.Log();
        }

    }
}
