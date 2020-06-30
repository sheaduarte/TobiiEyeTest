using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Task : MonoBehaviour
{
    // For writing out our data
    StreamWriter writer;
    string subjectID = "test";

    // Store a row of data
    Dictionary<string, string> dataRow = new Dictionary<string, string>();

    // variable names
    List<string> variableList = new List<string>() {"subject", "trial", "response"};


    public int numTrials = 10;


    public SliderController sliderController;

    public TaskEvent logDataRow;

    public int trial = 0;


    public SpawnController spawnController;

    bool _isDataLogged;

    private void OnEnable()
    {
        logDataRow.Register(LogData);

    }

    private void OnDisable()
    {
        logDataRow.Deregister(LogData);


        writer.Close();
    }

    private void Start()
    {
        // populate the dictionary keys

        foreach(var i in variableList)
        {
            Debug.Log(i);
            dataRow.Add(i, "");
        }

        // Setup data folder
        string folder = Path.Combine(Application.dataPath, "..","..", "Data");

        Directory.CreateDirectory(folder);

        string timeStamp = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss");

        var filePath = Path.Combine(folder, subjectID + "_" + timeStamp +".csv");
        Debug.Log(filePath);

        writer = new StreamWriter(filePath);
        writer.AutoFlush = true;

        WriteHeader();

        // Example shows data writing 
        //StartCoroutine(TestWriteValues());

        StartCoroutine(TrialSystem());
    }

    void LogData()
    {


        float response = sliderController.GetSliderValue();

        dataRow["subject"] = subjectID;
        dataRow["trial"] = trial.ToString();
        dataRow["response"] = response.ToString();
        WriteValues(dataRow);
        _isDataLogged = true;
    }

    void WriteHeader()
    {
        string line = String.Join(",", variableList);
        writer.WriteLine(line);
    }

    IEnumerator TestWriteValues()
    {
        string subject = "001";
        int trial = 0;
        int response = 5;


        dataRow["subject"] = subject;
        dataRow["trial"] = trial.ToString();
        dataRow["response"] = response.ToString();
        WriteValues(dataRow);
        yield return new WaitForSeconds(1f);

        trial = 1;
        response = 8;

        dataRow["subject"] = subject;
        dataRow["trial"] = trial.ToString();
        dataRow["response"] = response.ToString();
        WriteValues(dataRow);
        yield return new WaitForSeconds(1f);

        trial = 2;
        response = 3;

        dataRow["subject"] = subject;
        dataRow["trial"] = trial.ToString();
        dataRow["response"] = response.ToString();
        WriteValues(dataRow);
        yield return new WaitForSeconds(1f);

        QuitRequest();
    }

    void WriteValues(Dictionary<string, string> row)
    {
        Debug.Log("Write Values");

        List<string> valueList = new List<string>();

        foreach (KeyValuePair<string, string> entry in row)
        {
            valueList.Add(entry.Value);
        }


        string line = String.Join(",", valueList);

        writer.WriteLine(line);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit request");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                                                Application.Quit();
#endif
    }


    IEnumerator TrialSystem()
    {
        // Experimenter menu pops up

    

        trial = 0;
        _isDataLogged = false;


        while (trial < numTrials)
        {
            // Butterfly to spawn
            SpawnButterfly();

            yield return new WaitForSeconds(2);

            yield return StartCoroutine(ShowSliderPrompt());

            trial += 1;

            yield return null;
        }


            // Wait a few seconds

            // Slider prompt pop up

            // Wait for subject response

            // Log data

    }


    void SpawnButterfly()
    {
        spawnController.SpawnInNewPos();
        Debug.Log("Spawn butterfly");
    }

    IEnumerator ShowSliderPrompt()
    {
        Debug.Log("Show slider prompt");

        while (!_isDataLogged)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        _isDataLogged = false;
    }

}
