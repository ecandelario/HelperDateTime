// See https://aka.ms/new-console-template for more information

using HelperDate;

Console.WriteLine("======== Prueba funcionalidades de fechas ===========");
Console.WriteLine($"{DateTime.UtcNow} - {DateTime.Now} - {DateTime.Today}");
Console.WriteLine(value: $"{ HelperDateTime.GetTimePart(DateTime.Now) }");

