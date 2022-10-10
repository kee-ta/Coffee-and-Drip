using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ClockManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Date, Time, Season, Week;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        TimeManager.OnDateTimeChanged += UpdateDateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnDateTimeChanged -= UpdateDateTime;
    }
    private void UpdateDateTime(DateTime dateTime)
    {
        Date.text = dateTime.DateToString();
        Time.text = dateTime.TimeToString();
        Season.text = dateTime.Season.ToString();
        Week.text = $"WK:{dateTime.CurrentWeek}";
    }
}
