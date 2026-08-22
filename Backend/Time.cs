

namespace Backend;

public class Time
{
    //fields
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    // constructor

    public Time()
    {
        _hour = 0;
        _millisecond = 0;    
        _minute     = 0;   
        _second = 0;
    }

    public Time(int hour)
    {
        _hour = hour;
       
    }

    public Time(int hour, int minute)
    {
        _hour = hour;
        _minute = minute;
       
    }

    public Time(int hour, int minute, int second)
    {
        _hour = hour;
        _minute = minute;
        _second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        _hour = hour;
        _minute = minute;
        _second = second;
        _millisecond = millisecond;
    }


    // properties

    public int hour
    { 
        get => _hour; set => _hour = validatehour(value); 
    }
    public int minute 
    {
        get => _minute; set => _minute = validateMinute(value); 
    }
    public int second 
    { 
        get => _second; set => _second = validateSecond(value); 
    }
    public int millisecond
    {
        get => _millisecond; set => _millisecond =validateMillisecond(value)  ; 
    }

    //methods publics

    public override string ToString()
    {
        string ampm;

        if (_hour < 12)
            ampm = "AM";
        else
            ampm = "PM";

        int displayHour;
        if (_hour % 12 == 0)
        {
            displayHour = 12;
        }
        else
        {
            displayHour = _hour % 12;
        }

        return $"{displayHour:d2}:{_minute:d2}:{_second:d2}.{_millisecond:d3} {ampm}";
    }
    //methods privates

    private int validatehour (int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception("Las horas deben ser entre 0 y 23.");
        }
        return hour;
    }

    private int validateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception("Las horas deben ser entre 0 y 59.");
        }
        return minute;
    }

    private int validateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception("Las horas deben ser entre 0 y 59.");
        }
        return second;
    }

    private int validateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception("Las horas deben ser entre 0 y 999.");
        }
        return millisecond;
    }

    public int toMinutes()
    {
        return _hour * 60 + _minute;
    }   

    public int toSeconds()
    {
        return _hour * 3600 + _minute * 60 + _second;
    }
    public int toMilliseconds()
    {
        return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
    }

    
        public Time Add(Time other)
    {
        int totalMilliseconds = this.toMilliseconds() + other.toMilliseconds();

        int hour = (totalMilliseconds / 3600000) % 24;
        int minute = (totalMilliseconds / 60000) % 60;
        int second = (totalMilliseconds / 1000) % 60;
        int millisecond = totalMilliseconds % 1000;

        return new Time(hour, minute, second, millisecond);
    }

    public bool IsOtherDay(Time other)
    {
        int totalMilliseconds = this.toMilliseconds() + other.toMilliseconds();

        return totalMilliseconds >= 24 * 3600000;                    
    }
}   

