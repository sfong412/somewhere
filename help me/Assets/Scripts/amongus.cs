using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Wave
{
    public string waveName;
    public int NoOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;

    public float timeBtwWave;

    public bool quarterBeatTiming;
    public bool halfBeatTiming;
    public bool threeFourBeatTiming;
    public bool fullBeatTiming;

    
}
 
public class amongus : MonoBehaviour
{
    public static amongus Instance { get; set; }

    [Header("Assignables")]
    public float bpm = 120;
    public float secPerBeat;
    public float songPosition;
    private float songPositionInBeatsExact;
    private int songPositionInBeats;

    public float lastReportedBeat = 0f;

    public float dspSongTime;
    public float firstBeatOffset;
    public AudioSource musicSource;
    public AudioSource metronome_audioSrc;
    public float secPerRealBeat;

    public float songLength;

    public bool onBeat;

    public float songPosBeat;

    public float beatTime;

    private int timesQuarterBeat;

    //DELETE THESE COMMENTS

    /*public delegate void Beat();
    public static event Beat BeatEvent;*/

    public bool metronome;

    public bool autoPlay = true;

    void Start()
    {
        amongus.Instance = this;
        //Load the AudioSource attached to the Conductor GameObject
        musicSource.GetComponent<AudioSource>();
        //Metronome
        //metronome_audioSrc.GetComponent<AudioSource>();
        //Calculate the number of seconds in each beat
        secPerRealBeat = 60f / bpm;
        secPerBeat = 15f / bpm;
        //Record the time when the music starts
        dspSongTime = (float)musicSource.time;
        //Start the music
        //musicSource.time = 10f;

        if (autoPlay)
            musicSource.Play();

        songLength = musicSource.clip.length;
        Application.targetFrameRate = 60;
        
   
    }

    void Update()
    {
        lastReportedBeat = songPositionInBeats;
        if (musicSource.isPlaying)
        {
            secPerRealBeat = 60f / bpm;
            secPerBeat = 15f / bpm;

            //determine how many seconds since the song started
            //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            songPosition = (float)(musicSource.time - dspSongTime - firstBeatOffset);
            //determine how many beats since the song started
            songPositionInBeatsExact = songPosition / secPerBeat;
            songPositionInBeats = (int)songPositionInBeatsExact;
            ReportBeat();
            //GameTimeline();

            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log(songPosBeat);
            }

            songPosBeat = (float)songPositionInBeats / 4;

             switch (times)
        {
            case 2:
            HalfBeat(); 
            break;

            case 3: 
            ThreeFourBeat();
            break;

            case 4: 
            FullBeat();
            HalfBeat(); 
            break;

            case 5:
            times = 1;
            break;

        }
        }
    }

    void ReportBeat()
    {
        if (lastReportedBeat < songPositionInBeats)
        {
            onBeat = true;
            times += 1;
            beatTime += 0.25f;
            QuarterBeat();
            lastReportedBeat = songPositionInBeats;
        }
        else
        {
            onBeat = false;
        }
    }

    [SerializeField]private int times;
    
    public void QuarterBeat()
    {
       
       
        Debug.Log("quarter");
        metronome_audioSrc.Play();
        
    }

    public void HalfBeat()
    {
        

            Debug.Log("half");
        
    }

    public void ThreeFourBeat()
    {
        Debug.Log("threefour");
    }

    public void FullBeat()
    {
        //BeatEvent();
        Debug.Log("Full");
        if (metronome == true)
        {
            Debug.Log("Beat");
            
        }
    }


}