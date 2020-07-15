using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace EyeTest
{
    public class DataWriter
    {
        // For writing out our data
        StreamWriter _writer;
        string _subjectID;

        // Store a row of data
        public Dictionary<string, string> row = new Dictionary<string, string>();

        private List<string> _variableList;
        private string _dataPath;

        public DataWriter(List<string> variableList, string path, string subjectID)
        {
            _variableList = variableList;
            _dataPath = path;
            _subjectID = subjectID;
        }

        public void Activate()
        {
            foreach (var i in _variableList)
            {
                row.Add(i, "");
            }

            Directory.CreateDirectory(_dataPath);

            string timeStamp = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss");

            var filePath = Path.Combine(_dataPath, _subjectID + "_" + timeStamp + ".csv");

            _writer = new StreamWriter(filePath);
            _writer.AutoFlush = true;

            WriteHeader();
        }

        void WriteHeader()
        {
            string line = String.Join(",", _variableList);
            _writer.WriteLine(line);
        }

        public void Log()
        {
            WriteValues(row);
        }

        void WriteValues(Dictionary<string, string> row)
        {
            List<string> valueList = new List<string>();

            foreach (KeyValuePair<string, string> entry in row)
            {
                valueList.Add(entry.Value);
            }


            string line = String.Join(",", valueList);

            _writer.WriteLine(line);
        }


        public void Deactivate()
        {
            _writer.Close();
        }
    }

}
