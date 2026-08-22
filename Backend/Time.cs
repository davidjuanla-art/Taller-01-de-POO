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
        _minute = 0;
        _second = 0;
    }

    public Time(int hour)
    {
        this.hour = hour;
    }

    public Time(int hour, int minute)
    {
        this.hour = hour;
        this.minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        this.hour = hour;
        this.minute = minute;
        this.second = second;
        this.millisecond = millisecond;
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
        get => _millisecond; set => _millisecond = validateMillisecond(value);
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

    private int validatehour(int hour)
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
            throw new Exception("Los minutos deben ser entre 0 y 59.");
        }
        return minute;
    }

    private int validateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception("Los segundos deben ser entre 0 y 59.");
        }
        return second;
    }

    private int validateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception("Los milisegundos deben ser entre 0 y 999.");
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


    //add

    public Time Add(Time other)
    {
        int milliseconds = this._millisecond + other._millisecond;

        int extraSecond = 0;

        if (milliseconds > 999)
        {
            milliseconds -= 1000;
            extraSecond = 1;
        }

        int second = this._second + other._second + extraSecond;

        int extraMinute = 0;

        if (second > 59)
        {
            second -= 60;
            extraMinute = 1;
        }

        int minute = this._minute + other._minute + extraMinute;

        int extraHour = 0;

        if (minute > 59)
        {
            minute -= 60;
            extraHour = 1;
        }

        int hour = this._hour + other._hour + extraHour;

        if (hour > 23)
        {
            hour -= 24;
        }

        return new Time(hour, minute, second, milliseconds);
    }

    public bool IsOtherDay(Time other)
    {
        int milliseconds = this._millisecond + other._millisecond;

        int extraSecond = 0;

        if (milliseconds > 999)
        {
            milliseconds -= 1000;
            extraSecond = 1;
        }

        int second = this._second + other._second + extraSecond;

        int extraMinute = 0;

        if (second > 59)
        {
            second -= 60;
            extraMinute = 1;
        }

        int minute = this._minute + other._minute + extraMinute;

        int extraHour = 0;

        if (minute > 59)
        {
            minute -= 60;
            extraHour = 1;
        }

        int hour = this._hour + other._hour + extraHour;

        return hour > 23;
    }
}
