using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public static TaskManager INS;

    [SerializeField] GameObject[] tasks;
    int indexTask;
    [SerializeField] Transform taskPanel;
    [SerializeField] Baby baby;
    [SerializeField] Boss boos;
    [SerializeField] Slider sliderProgress;
    bool win;

    private void Awake()
    {
        INS = this;
    }
    public void StartGame()
    {
        StarTask();
        baby.GameStart();
        boos.GameStart();
        AudioManager.ins.PlayGame();
    }

    public void StarTask()
    {
        Task();
        Player.INS.RandomSuspiro();
    }

    public void Task()
    {
        if (indexTask >= tasks.Length) indexTask = 0;
        GameObject task = Instantiate(tasks[indexTask], taskPanel);
        task.transform.SetAsFirstSibling();
        task.SetActive(true);
        indexTask++;
    }

    private void Update()
    {
        if (sliderProgress.value >= 1) { if (!win) { 
                Menu.INS.FadeInOut(); 
                win = true;
                Menu.INS.AnimFinal.SetActive(true);
            } 
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void TaskCompleted()
    {
        float asd = sliderProgress.value;
        asd += 0.1f;
        LeanTween.value(gameObject, sliderProgress.value, asd , 1f).setOnUpdate((float value) => { sliderProgress.value = value; }).setOnComplete(_=> sliderProgress.value = asd);
        StarTask();
    }
}
