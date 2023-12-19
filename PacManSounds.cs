using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

public class PacManSounds
{
    ExceptionHandler exceptionHandler = new ExceptionHandler();


    public PacManSounds()
    {
    }

    // Function which will be called to play sounds, takes a filepath as an argument
    private void PlayGameSound(string filePath)
    {
        if (File.Exists(filePath))  // if it exists create soundplayer and play the sound
        {

            //https://www.w3schools.com/cs/cs_exceptions.php   
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(filePath);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                exceptionHandler.WriteErrorToFile($"Error playing sound: {ex.Message}");  //  // if exception is due to sound not being able to play. 
            }
        }
        else
        {
            exceptionHandler.WriteErrorToFile($"Sound file not found: {exceptionHandler.filePath}");   // if exception is due to sound not being found. 
        }
    }




    // Mmeber Functions to play different game sounds
    public void PlayIntro()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
    }

    public void EatPoint()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_chomp.wav");
    }

    public void PowerUp()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_intermission.wav");
    }

    public void LoseLife()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_death.wav");
    }

    public void EatGhost()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_eatfruit.wav");
    }

    public void NewHighScore()
    {
        PlayGameSound(@"C:\Users\student\OneDrive - Sheffield Hallam University\new_highscore.wav");
    }
}
