using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager INS;

    [SerializeField] GameObject[] tasks;
    [SerializeField] int indexTask;

    private void Awake()
    {
        INS = this;
    }
    void Start()
    {
        NextTask();
    }

    public void NextTask()
    {
        if (indexTask > tasks.Length) indexTask = 0;

        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].SetActive(false);
        }
           
        tasks[indexTask].SetActive(true);
        
        indexTask++;
    }
}
