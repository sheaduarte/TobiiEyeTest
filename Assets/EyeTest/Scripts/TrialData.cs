using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace EyeTest.Data
{
    public class TrialData : MonoBehaviour
    {
        private DataWriter _dataWriter;
        public int trial = 0;
        List<string> _variableList = new List<string>() { "subject", "trial", "response" };

        private void OnDisable()
        {
            if(_dataWriter!=null)
                _dataWriter.Deactivate();
        }

        public void EnableDataWriter()
        {
            var fileName = string.Concat(DataManager.SubjectID, "_", "trial", "_", DataManager.TimeStamp, ".csv");
            var filePath = Path.Combine(DataManager.SubjectDataPath, fileName);

            _dataWriter = new DataWriter(filePath);
            _dataWriter.Activate(_variableList);

            Debug.Log("Trial data writer activated");
        }

        public void WriteDataRow()
        {

            var response = SliderHandler.Instance.GetSliderValue();

            _dataWriter.row["subject"] = DataManager.SubjectID;
            _dataWriter.row["trial"] = trial.ToString();
            _dataWriter.row["response"] = response.ToString();
            _dataWriter.Log();
        }
    }
}
