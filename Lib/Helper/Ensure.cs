namespace Lib.Helper;

public static class Ensure
{
    public static void NotNull<T>(T? value, string name)
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }
    }
    
    public static void NotNull<T>(T value, string message, Action<T> callback)
    {
        if (value is null)
        {
            throw new ArgumentNullException(message);
        }
        
        callback(value);
    }
    
    public static void NotNullOrEmpty(string? value, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(name);
        }
    }
}