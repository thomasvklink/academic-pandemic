using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Clock Time;
    public Slider Happiness;
    public Slider Stress;
    public GameObject AtDesk;
    private bool isCoroutineExecuting = false;
    public bool Desk = false;
    // Start is called before the first frame update
    void Start()
    {
        Time = GameObject.Find("TimeText").GetComponent<Clock>();
        Happiness.minValue = 0;
        Happiness.maxValue = 100;
        Happiness.wholeNumbers = true;
        Happiness.value = 50;
        Stress.minValue = 0;
        Stress.maxValue = 100;
        Stress.wholeNumbers = true;
        Stress.value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.Minutes >= 59)
        {
            StartCoroutine(timer());
        }
        Debug.Log(Stress.value);
    }
    public void ComputerCheck(bool status)
    {
        Desk = status;
    }
    IEnumerator timer()
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(0.2f);
        Happiness.value--;
       if(Desk == true) {
            Stress.value += 5;
        }
        isCoroutineExecuting = false;
    }
}
