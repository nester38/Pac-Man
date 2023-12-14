using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;

public class PacManSounds
{
	public PacManSounds()
	{


    }
    public void PlayIntro()
    {
        SoundPlayer playIntro = new SoundPlayer(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
        playIntro.Play();
    }
  
    public void EatPoint()
    {
        SoundPlayer eatPoint = new SoundPlayer(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_chomp.wav");
        eatPoint.Play();
    }


    public void PowerUp()
    {
        SoundPlayer powerUp = new SoundPlayer(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_eatfruit.wav");
        powerUp.Play();
    }

    public void LoseLife()
    {
        SoundPlayer loseLife = new SoundPlayer(@"C:\Users\student\OneDrive - Sheffield Hallam University\pacman_death.wav");
        loseLife.Play();
    }

    public void EatGhost()
    {
        SoundPlayer eatGhost = new SoundPlayer();
        eatGhost.Play();
    }

    /*public void EatSpecialPoint()
    {
        SoundPlayer eatSpecialPoint = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_eatfruit.wav");
        eatSpecialPoint.Play();
    }
    */


}
