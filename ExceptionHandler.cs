using Pac_Man;
using System;

public class ExceptionHandler
{
    public string filePath = Path.Combine(Application.StartupPath, "sound_errors.log");

    public ExceptionHandler()
	{

    }


    // Writingerror details to the file "sound_errors.log"
    public void WriteErrorToFile(string error)
    {
        // https://www.javatpoint.com/c-sharp-streamwriter 

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(error);
        }
    }

    public void WriteTestResultToFile(string result)
    {
        // https://www.javatpoint.com/c-sharp-streamwriter 

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(result);
        }
    }


}
