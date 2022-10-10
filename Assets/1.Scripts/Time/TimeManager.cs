using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    [Header("DateTime Settings")]
    [Range(1, 28)]
    public int dateMonth;
    [Range(1, 4)]
    public int season;
    [Range(1, 99)]
    public int year;
    [Range(1, 24)]
    public int hour;
    [Range(0, 6)]
    public int minutes;
    private DateTime dateTime;

    [Header("Tick Settings")]
    public int TickMinutesIncreased = 10;
    public float TimeBetweenTicks = 1;
    private float currentTimeBetweenTicks = 0;
    public static Action<DateTime> OnDateTimeChanged;

    private void Awake()
    {
        dateTime = new DateTime(dateMonth,season-1,year,hour,minutes*10);
    }

    private void Start()
    {
        OnDateTimeChanged?.Invoke(dateTime);
    }
    private void Update()
    {

        currentTimeBetweenTicks += Time.deltaTime;

        if (currentTimeBetweenTicks >= TimeBetweenTicks)
        {
            currentTimeBetweenTicks = 0;
            Tick();
        }

    }

    public void Tick()
    {

        AdvanceTime();

    }

    public void AdvanceTime()
    {
        dateTime.AdvanceMinutes(TickMinutesIncreased);
        OnDateTimeChanged?.Invoke(dateTime);
    }
}

[System.Serializable]
public struct DateTime
{
    #region Fields
    private Days day;
    private int date, year, hour, minutes, totalNumberDays, totalNumberWeeks;
    private Season season;
    #endregion

    #region Properties
    public Days Day => day;
    public int Date => date;
    public int Hour => hour;
    public int Minutes => minutes;
    public int Year => year;
    public int TotalNumberOfDays => totalNumberDays;
    public int TotalNumberOfWeeks => totalNumberWeeks;

    public Season Season => season;
    public int CurrentWeek => totalNumberWeeks % 16 == 0 ? 16 : totalNumberWeeks % 16;
    #endregion

    public DateTime(int date, int season, int year, int hour, int minutes)
    {
        this.day = (Days)(date % 7);
        if (day == 0) day = (Days)7;

        this.date = date;
        this.season = (Season)season;
        this.year = year;

        this.hour = hour;
        this.minutes = minutes;

        totalNumberDays = date + (28 * (int)this.season) + (112 * (year - 1));

        totalNumberWeeks = 1 + totalNumberDays / 7;
    }

    #region Methods
    public void AdvanceMinutes(int AdvanceBySeconds)
    {
        if (minutes + AdvanceBySeconds >= 60)
        {
            minutes = (minutes + AdvanceBySeconds) % 60;
            AdvanceHour();
        }
        else
        {
            minutes += AdvanceBySeconds;
        }
    }

    public void AdvanceHour()
    {
        if ((hour + 1) == 24)
        {
            hour = 0;
            AdvanceDay();
        }
        else
        {
            hour++;
        }
    }

    public void AdvanceDay()
    {
        day++;

        if (day > (Days)7)
        {
            day = (Days)1;
            totalNumberWeeks++;
        }
        else { }

        date++;

        if (date % 29 == 0)
        {
            AdvanceSeason();
            date = 1;
        }
        else { }

        totalNumberDays++;
    }

    public void AdvanceSeason()
    {
        if (Season == Season.WINTER)
        {
            season = Season.SPRING;
            AdvanceYear();
        }
        else { season++; }
    }

    public void AdvanceYear()
    {
        date = 1;
        year++;
    }

    public bool IsNight()
    {
        return hour > 18 || hour < 6;
    }
    public bool IsMorning()
    {
        return hour >=6 && hour <= 12;
    }
    public bool IsAfternoon()
    {
        return hour > 12 && hour <18;
    }
    public bool IsWeekend()
    {
        return day > Days.FRI ? true : false;
    }
    public bool IsDay(Days dayToCheck)
    {
        return day == dayToCheck;
    }

    public override string ToString()
    {
        return $"Date: {DateToString()} Season: {season.ToString()} Time: {TimeToString()} " +
            $"\nTotal Days: {totalNumberDays} | Total Weeks: {totalNumberWeeks}";
    }

    public string DateToString()
    {
        return $"{Day} {Date} {Year.ToString("D2")}";
    }

    public string TimeToString()
    {
        int adjustedHour = 0;

        if(hour == 0)
        {
            adjustedHour = 12;
        } 
        else if(hour >= 13) {adjustedHour = hour - 12;}
        else{adjustedHour = hour;}

        string AmPm = hour < 12 ? "AM" : "PM";

        return $"{adjustedHour.ToString("D2")}:{minutes.ToString("D2")} {AmPm}";
    }

    #endregion
}

    [System.Serializable]
    public enum Days
    {
        NULL,
        MON,
        TUE,
        WED,
        THU,
        FRI,
        SAT,
        SUN
    }
    [System.Serializable]
    public enum Season
    {
        SPRING,
        SUMMER,
        AUTUMN,
        WINTER
    }
