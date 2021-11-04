using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Clock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] TextMeshProUGUI DaysText;

    public int Minutes = 0;
    public int Hours = 0;
    int Day = 1;
    private bool isCoroutineExecuting = false;
    public bool Nighttime = false;
    // Start is called before the first frame update
    void Start()
    {
        SetTimeText(); 
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeText();
       StartCoroutine(timer());
    }

    public void SetTimeText()
    {
        if (Minutes >= 60)
        {
            Minutes = 0;
            Hours++;
        }
        if (Hours >= 21 && Hours <= 7)
        {
            Nighttime = true;
        }
        else
        {
            Nighttime = false;
        }
        if (Hours == 24)
        {
            Hours = 0;
            Day++;
        }

        TimeText.text = (Hours.ToString() + ":" + Minutes.ToString());
        DaysText.text = ("Day:" + Day.ToString());
    }
    public void Sleep(bool status)
    {
        Nighttime = status;
    }
    IEnumerator timer()
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true; 
        yield return new WaitForSeconds(0.05f);
        Minutes++;
        isCoroutineExecuting = false;
    }
}
