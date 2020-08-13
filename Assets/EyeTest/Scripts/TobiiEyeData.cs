using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using Sirenix.OdinInspector;
using System.IO;
using System;


namespace EyeTest.Data
{
    public class TobiiEyeData : MonoBehaviour
    {
        [SerializeField]
        private Transform head;
        private bool _isCollectEyeData = false;

        enum EyeData {
            TobiiTimeStamp,
            TobiiConvergenceDistance,
            TobiiConvergenceDistanceIsValid,
            TobiiIsLeftEyeBlinking,
            TobiiIsRightEyeBlinking,
            TobiiGazeRayOrigin,
            TobiiGazeRayDirection,
            TobiiGazeRayIsValid,
            HeadPosition,
            HeadRotation,
            GazeObject,
            GazeObjectPosition
        }

        private DataWriter _dataWriter;


        private void OnDisable()
        {
            if(_dataWriter!=null)
                _dataWriter.Deactivate();
        }

        public void EnableDataWriter()
        {
            var fileName = string.Concat(DataManager.SubjectID, "_", "eye_data", "_", DataManager.TimeStamp, ".csv");
            var filePath = Path.Combine(DataManager.SubjectDataPath, fileName);

            _dataWriter = new DataWriter(filePath);

            _dataWriter.Activate(Util.EnumToStrings<EyeData>());
            Debug.Log("Eye data writer activated");
        }

        public void StartCollecting()
        {
            _isCollectEyeData = true;
        }

        public void StopCollecting()
        {
            _isCollectEyeData = false;
        }

        void FixedUpdate()
        {
            if (_isCollectEyeData)
            {
                UpdateData();
            }
        }

        void UpdateData()
        {
            var data = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

            SetValue(EyeData.TobiiTimeStamp, data.Timestamp);
            SetValue(EyeData.TobiiConvergenceDistance, data.ConvergenceDistance);
            SetValue(EyeData.TobiiConvergenceDistanceIsValid, data.ConvergenceDistanceIsValid);
            SetValue(EyeData.TobiiIsLeftEyeBlinking, data.IsLeftEyeBlinking);
            SetValue(EyeData.TobiiIsRightEyeBlinking, data.IsRightEyeBlinking);
            SetValue(EyeData.TobiiGazeRayOrigin, data.GazeRay.Origin);
            SetValue(EyeData.TobiiGazeRayDirection, data.GazeRay.Direction);
            SetValue(EyeData.TobiiGazeRayIsValid, data.GazeRay.IsValid);
            SetValue(EyeData.HeadPosition, head.position);
            SetValue(EyeData.HeadRotation, head.eulerAngles);
            SetValue(EyeData.GazeObject,GazeObjectController.Instance.GetGazeObjectName());
            SetValue(EyeData.GazeObjectPosition, GazeObjectController.Instance.GetGazeObjectPosition());

            _dataWriter.Log();
        }

        private void SetValue(EyeData key, object value)
        {
            _dataWriter.SetValue(key, value);
        }
    }
    
}

