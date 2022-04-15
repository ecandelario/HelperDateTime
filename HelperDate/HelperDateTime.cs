namespace HelperDate;

/// <summary>
/// Date functions
/// </summary>
public static class HelperDateTime
{
    #region Date methods

    #region Date Query

    /// <summary>
    /// Devuelve la fecha del sistema.
    /// </summary>
    public static DateTime SystemDate()
    {
        return DateTime.Today;
    }

    /// <summary>
    /// Devuelve verdadero si y solo si el año es un año bisiesto; falso en otro caso.
    /// </summary>		
    public static bool IsLeapYear(int? year)
    {
        return year == null ? throw new Exception("El año no puede ser nulo (IsLeapYear).")
                            : DateTime.IsLeapYear(year.GetValueOrDefault());
    }

    /// <summary>
    /// Returns the days of difference between date1 and date2
    /// </summary>		
    public static int DaysDifferenceFromDate(DateTime? date1, DateTime? date2)
    {
        if (date1 != null && date2 != null)
        {
            if (date1.GetValueOrDefault() > date2.GetValueOrDefault())
                return 0;

            return date2.GetValueOrDefault().Subtract(date1.GetValueOrDefault()).Days;
        }

        throw new Exception("Las fechas no pueden ser nulas (DaysDifferenceFromDate).");
    }

    /// <summary>
    /// Devuelve el número de días en un mes especificado del año especificado.
    /// Por ejemplo, si mes es igual a 2 para febrero, el valor de retorno es 28 o 29 dependiendo.
    /// dependiendo de si el año es un año bisiesto.
    /// </summary>				
    public static int DaysInMonth(int? year, int? month)
    {
        if (year == null || month == null)
            throw new Exception("El año ó el mes no puden ser nulas (DaysInMonth).");

        return DateTime.DaysInMonth(year.GetValueOrDefault(), month.GetValueOrDefault());
    }

    /// <summary>
    /// Devuelve el día de una fecha
    /// </summary>			
    public static int GetDay(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        return date.GetValueOrDefault().Day;
    }

    /// <summary>
    /// Devuelve el mes de una fecha
    /// </summary>				
    public static int GetMonth(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        return date.GetValueOrDefault().Month;
    }

    /// <summary>
    /// Cuenta el número de apariciones del día de la semana entre dos fechas.
    /// </summary>
    public static int GetNumDayOfWeekBetweenDates(int? dayofweek, DateTime? inidate, DateTime? enddate)
    {
        if (dayofweek == null || inidate == null || enddate == null)
            throw new Exception("El día de la semana,la fecha inicio, la fecha final no puden ser nulas.");

        if (inidate.GetValueOrDefault() > enddate.GetValueOrDefault())
            return 0;

        int numTotal = DaysDifferenceFromDate(inidate.GetValueOrDefault(), enddate.GetValueOrDefault());
        int numDays = numTotal / 7;
        int diffDays = numTotal % 7;
        int iniDay = GetDayOfWeek(inidate.GetValueOrDefault());
        int endDay = GetDayOfWeek(enddate.GetValueOrDefault());

        if (endDay < iniDay)
        {
            endDay += 7;
        }

        if (dayofweek < iniDay)
        {
            dayofweek += 7;
        }

        int iniRest = endDay - diffDays;
        if ((dayofweek >= iniRest) && (dayofweek <= endDay))
        {
            numDays++;
        }
        return numDays;
    }

    /// <summary>
    /// Devuelve el año de una fecha.
    /// </summary>			
    public static int GetYear(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        return date.GetValueOrDefault().Year;
    }

    /// <summary>
    /// Devuelve el día de la semana contenido en date. Los valores posibles son del 1 al 7.
    /// </summary>		
    public static int GetDayOfWeek(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        int lDayOfWeek = ((int)date.GetValueOrDefault().DayOfWeek) + 1;
        return lDayOfWeek;
    }

    /// <summary>
    /// Devuelve el día del año contenido en date. Los valores posibles son del 1 al 365
    /// (si el año no es bisiesto) o del 1 al 366.
    /// </summary>				
    public static int GetDayOfYear(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        return date.GetValueOrDefault().DayOfYear;
    }

    /// <summary>
    /// Devuelve una fecha correspondiente al día siguiente del argumento date
    /// </summary>				
    public static DateTime Tomorrow(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no puede ser nula.");

        return date.GetValueOrDefault().AddDays(1);
    }

    /// <summary>
    /// Devuelve una fecha correspondiente al día anterior del argumento date
    /// </summary>				
    public static DateTime Yesterday(DateTime? date)
    {
        return (date ?? throw new Exception($"La fecha {nameof(date)} no puede ser nula.")).AddDays(-1);
    }

    /// <summary>
    /// Devuelve una fecha a la que se ha agregado un intervalo de tiempo específico.
    /// </summary>				
    public static DateTime DateAdd(string interval, int? number, DateTime? date)
    {
        if (interval == null || number == null || date == null)
            throw new Exception("El intervalo, el número de tiempo y la fecha, no puede ser nulos.");

        return interval switch
        {
            "yyyy" => date.GetValueOrDefault().AddYears(number.GetValueOrDefault()),
            "m" => date.GetValueOrDefault().AddMonths(number.GetValueOrDefault()),
            "d" => date.GetValueOrDefault().AddDays(number.GetValueOrDefault()),
            _ => date.GetValueOrDefault(),
        };
    }
    #endregion

    #region Date conversion

    /// <resumen>
    /// Devuelve una representación de cadena del argumento date.
    /// Convierte una fecha en una cadena de la forma: m/d/yy
    /// Ejemplo:3/2/05
    /// </resumen>
    public static string ToShortDateFormat(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no debe ser nula (ToShortDateFormat).");

        return date.GetValueOrDefault().ToString("d/M/yy");
    }

    /// <resumen>
    /// Devoluciones y representación de cadena del argumento date.
    /// Convierte una fecha en una cadena de la forma: mon dd, yyyy
    /// Ejemplo: feb. 03, 2005
    /// </resumen>
    public static string ToMediumDateFormat(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no debe ser nula (ToMediumDateFormat).");

        return date.GetValueOrDefault().ToString("MMM dd, yyyy");
    }

    /// <resumen>
    /// Devuelve una representación de cadena del argumento date.
    /// Convierte una fecha en una cadena de la forma: mmmm dd, yyyy
    /// Ejemplo: febrero 03, 2005
    /// </resumen>		
    public static string ToLongDateFormat(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no debe ser nula (ToLongDateFormat).");

        return date.GetValueOrDefault().ToString("MMMM dd, yyyy");
    }

    /// <resumen>
    /// Devoluciones y representación de cadena del argumento date
    /// Convierte una fecha en una cadena de la forma: dow, mon dd, yyyy
    /// Donde:
    /// dow es el día de la semana (domingo, lunes, martes, miércoles, jueves, viernes, sábado).
    /// mon es el mes (ene, feb, mar, abr, may, jun, jul, ago, sep, oct, nov, dic),
    /// dd es el día del mes (01 a 31) como dos dígitos decimales,
    /// yyyy es el año, con cuatro dígitos decimales
    /// Ejemplo:jueves, febrero 03, 2005
    /// </resumen>
    public static string ToFullDateFormat(DateTime? date)
    {
        if (date == null)
            throw new Exception($"La fecha {nameof(date)} no debe ser nula (ToFullDateFormat).");

        return date.GetValueOrDefault().ToString("dddd, MMMM dd, yyyy");
    }

    /// <resumen>
    /// Convierta la cadena stringDate en una representación de fecha. 
    /// stringDate debe ser una cadena de formato corto
    /// Convierte una fecha en una cadena de la forma: mmmm dd, yyyy
    /// Ejemplo: 3/02/2005 12:00:00 a. m.
    /// </resumen>
    public static DateTime StringToDate(string stringDate)
    {
        if (string.IsNullOrEmpty(stringDate))
            throw new Exception($"La fecha {nameof(stringDate)} no debe ser nula (StringToDate).");

        return DateTime.Parse(stringDate);
    }

    /// <resumen>
    /// Convierta los argumentos año, mes y día en una representación de fecha.
    /// year :Debe ser un valor positivo
    /// month :Debe estar en el rango 1..12
    /// day :Debe estar en el rango 1..31
    /// Ejemplo: 2/10/2019 12:00:00 a. m.
    /// </resumen>
    public static DateTime FormatToDate(int? year, int? month, int? day)
    {
        if (year == null || month == null || day == null)
            throw new Exception($"El año, mes ó día no puede ser nulos (FormatToDate).");

        //valida si el numero de dias esta dentro del rango de dias del mes
        var daysInMonth = DateTime.DaysInMonth(year.Value, month.Value);
        if (daysInMonth < day.Value)
            day = daysInMonth;
        //fin del cambio.

        return new DateTime(year.Value, month.Value, day.Value, 0, 0, 0);
    }
    #endregion

    #region Date comparison

    /// <resumen>
    /// Comprueba si initialDate es posterior a la fecha especificada finalDate.
    /// Devuelve: verdadero si y solo si initialDate es estrictamente posterior a la fecha representada por finalDate.
    /// </resumen>
    public static bool DateAfter(DateTime? initialDate, DateTime? finalDate)
    {
        if (initialDate == null || finalDate == null)
            throw new Exception($"La fecha {nameof(initialDate)} ó la fecha {nameof(finalDate)} no pueden ser nulas (DateAfter).");

        return initialDate > finalDate;
    }

    /// <resumen>
    /// Comprueba si initialDate es anterior a la fecha especificada finalDate.
    /// Devuelve: verdadero si y solo si initialDate es estrictamente anterior a la fecha representada por finalDate.
    /// </resumen>	
    public static bool DateBefore(DateTime? initialDate, DateTime? finalDate)
    {
        if (initialDate == null || finalDate == null)
            throw new Exception($"La fecha {nameof(initialDate)} ó la fecha {nameof(finalDate)} no pueden ser nulas (DateBefore).");

        return initialDate < finalDate;
    }

    /// <resumen>
    /// Compara si dos fechas son iguales.
    /// El resultado es verdadero si y solo si el argumento initialDate representa la misma fecha que finalDate.
    /// </resumen>			
    public static bool DateEquals(DateTime? initialDate, DateTime? finalDate)
    {
        if (initialDate == null || finalDate == null)
            throw new Exception($"La fecha {nameof(initialDate)} ó la fecha {nameof(finalDate)} no pueden ser nulas (DateEquals).");

        return initialDate.Value.Date.Equals(finalDate.Value.Date);
    }
    #endregion

    #endregion

    #region DateTime methods

    #region DateTime Query

    /// <summary>
    /// Devuelve la fecha y hora del sistema.
    /// </summary>	
    public static DateTime SystemDateTime()
    {
        return DateTime.Now;
    }

    /// <summary>
    /// Esta función extrae la información relacionada con la parte horaria de datetime (hora, minuto, segundo), 
    /// descartando la información relacionada con la fecha (año, mes, día)
    /// </summary>				
    public static TimeSpan GetTimePart(DateTime? dateTime)
    {
        if (dateTime == null)
            throw new Exception("La fecha no puede ser nula (dateTime).");

        return dateTime.GetValueOrDefault().AddHours(-12).TimeOfDay;
    }

    /// <summary>
    /// Devuelve una fecha y hora a la que se ha agregado un intervalo de tiempo específico.
    /// Intervalo: el intervalo de tiempo que desea agregar.
    /// </summary>				
    public static DateTime DateTimeAdd(string interval, int? number, DateTime? dateTime)
    {
        if (interval == null || number == null || dateTime == null)
            throw new Exception("El intervalo, número de tiempo ó fecha no puedene ser nula (DateTimeAdd).");

        return interval switch
        {
            "yyyy" => dateTime.GetValueOrDefault().AddYears(number.GetValueOrDefault()),
            "m" => dateTime.GetValueOrDefault().AddMonths(number.GetValueOrDefault()),
            "d" => dateTime.GetValueOrDefault().AddDays(number.GetValueOrDefault()),
            "h" => dateTime.GetValueOrDefault().AddHours(number.GetValueOrDefault()),
            "n" => dateTime.GetValueOrDefault().AddMinutes(number.GetValueOrDefault()),
            "s" => dateTime.GetValueOrDefault().AddSeconds(number.GetValueOrDefault()),
            _ => dateTime.GetValueOrDefault(),
        };
    }

    #endregion Query

    #region DateTime Conversions

    /// <summary>
    /// Convierta la fecha y la hora de los argumentos en una representación de fecha y hora.
    /// </summary>	
    public static DateTime ToDateTime(DateTime? date, DateTime? dateTime)
    {
        if (date == null || dateTime == null)
            throw new Exception("Las fechas no pueden ser nulas (ToDateTime).");

        DateTime lDate = date.GetValueOrDefault();
        DateTime lTime = dateTime.GetValueOrDefault();

        return new DateTime(lDate.Year, lDate.Month, lDate.Day, lTime.Hour, lTime.Minute, lTime.Second);
    }

    /// <summary>
    /// Converts aDate to a string of the form: dow mon dd hh:mm:ss zzz yyyy
    /// </summary>
    public static string DateTimeToString(DateTime? dateTime)
    {
        if (dateTime == null)
            throw new Exception("La fecha no puede ser nula (DateTimeToString).");

        return dateTime.GetValueOrDefault().ToString("MMMM dd, yyyy HH:mm:ss");
    }

    /// <summary>
    /// Convierta la cadena cadena Fecha en una representación de fecha y hora
    /// </summary>
    public static DateTime StringToDateTime(string stringDate)
    {
        if (string.IsNullOrEmpty(stringDate))
            throw new Exception("La fecha no puede ser nula (StringToDateTime).");

        return System.DateTime.Parse(stringDate);
    }

    /// <summary>
    /// Convierta los argumentos (año, mes, día, hora, minuto y segundo) en una representación de fecha y hora.
    /// </summary>
    /// <param name="year">Debe ser un valor positivo</param>
    /// <param name="month">Debe estar en el rango 1..12</param>
    /// <param name="day">Debe estar en el rango 1..31</param>
    /// <param name="hora">Debe estar en el rango 0..23</param>
    /// <param name="minuto">Debe estar en el rango 0..59</param>
    /// <param name="segundo">Debe estar en el rango 0..59</param>
    public static DateTime FormatToDateTime(int? year, int? month, int? day, int? hour, int? minute, int? second)
    {
        if (year == null || month == null || day == null || hour == null || minute == null || second == null)
            throw new Exception();

        return new DateTime(year.GetValueOrDefault(), month.GetValueOrDefault(), day.GetValueOrDefault(), hour.GetValueOrDefault(), minute.GetValueOrDefault(), second.GetValueOrDefault());
    }

    #endregion Conversions

    #region DateTime Comparison

    /// <summary>
    /// Comprueba si initialDateTime es posterior a la fecha y hora especificada finalDateTime
    /// </summary>
    /// <returns>verdadero si y solo si initialDateTime es estrictamente posterior a la fecha y hora representada por finalDateTime</returns>
    public static bool DatetimeAfter(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        if (initialDateTime == null || finalDateTime == null)
            throw new Exception("Las fechas no puede ser nula (DatetimeAfter).");

        return initialDateTime > finalDateTime;
    }

    /// <summary>
    /// Comprueba si initialDateTime es anterior a la fecha y hora especificada finalDateTime
    /// </summary>
    /// <returns>verdadero si y solo si initialDateTime es estrictamente anterior a la fecha y hora representada por finalDateTime</returns>
    public static bool DatetimeBefore(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        if (initialDateTime == null || finalDateTime == null)
            throw new Exception("Las fechas no puede ser nula (DatetimeBefore).");

        return initialDateTime < finalDateTime;
    }

    /// <summary>
    /// Compara dos fechas y horas para la igualdad
    /// </summary>
    /// <returns>verdadero si y solo si el argumento initialDateTime representa la misma fecha y hora que finalDateTime</returns>
    public static bool DatetimeEquals(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        if (initialDateTime == null || finalDateTime == null)
            throw new Exception("Las fechas no puede ser nula (DatetimeEquals).");

        return initialDateTime.Equals(finalDateTime);
    }

    #endregion Comparison

    #endregion

}
