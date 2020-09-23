using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() =>
        throw new Exception("You need to implement this function.");

    public static int? HandleErrorByReturningNullableType(string input) =>
        int.TryParse(input, out int result) ? result : (int?)null;

    public static int? HandleErrorByReturningNullableType1(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }

        return null;
    }

    public static bool TryHandleErrorWithOutParam(string input, out int result)
    {
        result = 0;

        try
        {
            result = int.Parse(input);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool TryHandleErrorWithOutParam1(string input, out int result) =>
        int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception();
        }
        finally
        {
            disposableObject.Dispose();
        }
    }

    public static int DisposableResourcesAreDisposedWhenExceptionIsThrown(string input, IDisposable disposableObject)
    {
        try
        {
            return int.Parse(input);
        }
        catch (FormatException ex)
        {
            disposableObject.Dispose();
            throw ex;
        }
        catch
        {
            disposableObject.Dispose();
            throw;
        }
    }

    public static int DisposableResourcesAreDisposedWhenExceptionIsThrown2(string input, IDisposable disposableObject)
    {
        try
        {
            return int.Parse(input);
        }
        finally
        {
            disposableObject.Dispose();
        }
    }


    public static int DisposableResourcesAreDisposedWhenExceptionIsThrown3(string input, IDisposable disposableObject)
    {
        using(disposableObject)
        {
            return int.Parse(input);
        }
    }
}
