using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace EyeTest.Data
{
    public class TrialData : MonoBehaviour
    {
        private DataWriter _dataWriter;
        public int trial = 0;

        public TimeSpan timeResponse;
        public TimeSpan timeSpawn;
        public TimeSpan timeEyeDetect;

        enum Variables{
            GlobalTime,
            Trial,
            Response,
            TimeSpawn,
            TimeEyeDetect,
            TimeResponse
        }

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
            _dataWriter.Activate(Util.EnumToStrings<Variables>());

            Debug.Log("Trial data writer activated");
        }

        public void WriteDataRow()
        {
            SetValue(Variables.GlobalTime, TaskManager.Instance.getTimeSinceStart.TotalMilliseconds);
            SetValue(Variables.Trial, trial);
            SetValue(Variables.Response, SliderHandler.Instance.GetSliderValue());
            SetValue(Variables.TimeSpawn, timeSpawn.TotalMilliseconds);
            SetValue(Variables.TimeEyeDetect, timeEyeDetect.TotalMilliseconds);
            SetValue(Variables.TimeResponse, timeResponse.TotalMilliseconds);

            _dataWriter.Log();
        }


        private void SetValue(Variables key, object value)
        {
            _dataWriter.SetValue(key, value);
        }
    }
}
