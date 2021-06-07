using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//Created by color!please studios


[RequireComponent(typeof(AudioSource))]

public class beatMap
{
    public int beatsBtwWave;
    public int eventType;

    public float noOfEvents;

    public float songPositionWave;

    public bool beatMode;
    public bool timeMode;

    



}


 
public class amongus : MonoBehaviour
{
    [SerializeField] beatMap[] Events;

    [SerializeField]private beatMap currentEvent;
    private int currentEventNumber;

    public bool canSpawn;

    public int nextBeatsBtwWave;
    public float nextTimeBtwWave;
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
    public bool metronome;

    public bool beatGo;

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
        currentEvent = Events[currentEventNumber];
        
   
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
            ExecuteEvent();

            
        }

        if (currentEvent.beatMode)
        {
             if (currentEvent.beatsBtwWave == 0 && !canSpawn)
        {
            canSpawn = true;
            currentEventNumber++;
            currentEvent = Events[currentEventNumber];
        }
        }

       

        if (currentEvent.timeMode)
        {
            if (songPosition > currentEvent.songPositionWave && !canSpawn)
            {
                canSpawn = true;
            currentEventNumber++;
            currentEvent = Events[currentEventNumber];
            }

           
        }

    }

    void ExecuteEvent()
    {
          if (canSpawn == true)
          {

              if (currentEvent.beatMode == true && beatGo == true)
              {
                  beatGo = false;
                    switch (currentEvent.eventType)
                 {
                  case 1: 
                  Debug.Log("impostor");
                  break;
                 }

              }
              
            
          }

          if (currentEvent.noOfEvents == 0)
          {
              canSpawn = false;
              
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
         if (!canSpawn && currentEvent.beatMode == true)
            {
                currentEvent.beatsBtwWave -= 1;
            }
            if (canSpawn && currentEvent.noOfEvents > 0 && currentEvent.beatMode == true)
            {
                beatGo = true;
                currentEvent.noOfEvents--;
            }
            
        
        if (times == 4)
        {
            times = 0;
        }
        
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