using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace EyeTest
{
    public class DataWriter
    {
        // For writing out our data
        StreamWriter _writer = null;

        public Dictionary<string, object> row = new Dictionary<string, object>();
        private List<string> _variableList;
        private string _filePath;

        public DataWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Activate(List<string> variableList)
        {
            _variableList = variableList;

            foreach (var i in _variableList)
            {
                row.Add(i, "");
            }

            _writer = new StreamWriter(_filePath);
            _writer.AutoFlush = true;

            WriteHeader();
        }

        private void WriteHeader()
        {
            _writer.WriteLine(string.Join(",", _variableList));
        }

        public void Log()
        {
            WriteValues(row);
        }

        public void SetValue<T>(T key, object value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            row[key.ToString()] = value;
        }

        void WriteValues(Dictionary<string, object> row)
        {
            var valueList = new List<string>();

            foreach (KeyValuePair<string, object> entry in row)
            {
                valueList.Add(ToCsvCell(entry.Value));
            }


            var line = String.Join(",", valueList);

            _writer.WriteLine(line);
        }


        public void Deactivate()
        {
            if(_writer != null)
                _writer.Close();
        }
        
        private static string ToCsvCell(object o)
        {
            if (o == null)
            {
                return "";
            }
            var s = o.ToString();
            if (s.Contains(","))
            {
                if (s.Contains("\""))
                {
                    s.Replace("\"", "\\\"");
                }
                return "\"" + s + "\"";
            }
            return s;
        }
    }

}
