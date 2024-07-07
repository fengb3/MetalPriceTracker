namespace Lib.Helper;

public static class TaskHelper
{
    public static async Task WhenAll(this IEnumerable<Task> tasks)
    {
        await Task.WhenAll(tasks);
    }
}