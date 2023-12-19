using System;

public class ExceptionHandler
{
    public string filePath = @"C:\Users\student\OneDrive - Sheffield Hallam University\sound_errors.log";
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
}
