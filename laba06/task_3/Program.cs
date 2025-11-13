using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message) : base (message) { }
}

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException(string message) : base(message) { }
}

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message) : base(message) { }
}

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message) : base(message) { }
}

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException(string message) : base(message) { }
}

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException(string message) : base(message) { }
}

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
            artistName = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
            seconds = value;
        }
    }
}

public class Playlist
{
    private List<Song> songs = new List<Song>();

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    public string GetPlaylistLenght()
    {
        int totalSecond = 0;
        for (int i = 0; i < songs.Count; i++)
        {
            int songLengthInSeconds = songs[i].Minutes * 60 + songs[i].Seconds;
            totalSecond += songLengthInSeconds;
        }
        int hours = totalSecond / 3600;
        int minutes = (totalSecond % 3600) / 60;
        int seconds = totalSecond % 60;

        return $"{hours}h {minutes}m {seconds}s";
    }

    public int Count
    {
        get { return songs.Count; }
    }
}

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Playlist playlist = new Playlist();
        List<string> messages = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(';');

            try
            {
                if (parts.Length != 3)
                {
                    throw new InvalidSongException("Invalid song.");
                }

                string artistNAme = parts[0];
                string songName = parts[1];
                string[] timeParts = parts[2].Split(':');

                if (timeParts.Length != 2)
                {
                    throw new InvalidSongLengthException("Invalid song length.");
                }

                int minutes = int.Parse(timeParts[0]);
                int seconds = int.Parse(timeParts[1]);

                Song song = new Song(artistNAme, songName, minutes, seconds);
                playlist.AddSong(song);
                messages.Add("Song added");

            }
            catch (Exception er)
            {
                messages.Add(er.Message);
            }
        }

        Console.WriteLine();
        foreach (string msg in messages)
        {
            Console.WriteLine(msg);
        }

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist lenght: {playlist.GetPlaylistLenght()}");
    }
}