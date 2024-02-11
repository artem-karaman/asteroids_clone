using UnityEngine;

public class Logger : ILogger
{
    public void LogInfo(string message)
    {
        Debug.Log(message);
    }

    public void LogError(string message)
    {
        Debug.LogError(message);
    }
}
