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

    public bool beatRest;

    public bool timeRest;

    



}


 
public class RhythmGameMapper : MonoBehaviour
{
    [SerializeField] beatMap[] Events;

    [SerializeField]private beatMap currentEvent;
    [SerializeField]private int currentEventNumber;

    public bool canSpawn;

    public int nextBeatsBtwWave;
    public float nextTimeBtwWave;
    public static RhythmGameMapper Instance { get; set; }

    [Header("Assignables")]
    public float bpmDividedByFour;
    public float secPerBeat;
    public float songPosition;
    public float songDuration;
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

    public bool timeGo;

    public bool willPress;

    public bool autoPlay = true;

    public AudioClip hai;
     public AudioClip Nothai;

     public GameObject test1;
     public GameObject test2;
     public GameObject test3;

    void Start()
    {
        RhythmGameMapper.Instance = this;
        //Load the AudioSource attached to the Conductor GameObject
        musicSource.GetComponent<AudioSource>();
        //Metronome
        //metronome_audioSrc.GetComponent<AudioSource>();
        //Calculate the number of seconds in each beat
        secPerRealBeat = 60f / bpmDividedByFour;
        secPerBeat = 15f / bpmDividedByFour;
        //Record the time when the music starts
        dspSongTime = (float)musicSource.time;
        //Start the music
        //musicSource.time = 10f;

        if (autoPlay)
            musicSource.Play();

        songLength = musicSource.clip.length;
        Application.targetFrameRate = 120;
        currentEvent = Events[currentEventNumber];
        
   
    }

    void Update()
    {
        lastReportedBeat = songPositionInBeats;
        if (musicSource.isPlaying)
        {
            secPerRealBeat = 60f / bpmDividedByFour;
            secPerBeat = 15f / bpmDividedByFour;

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

        if (currentEvent.beatRest)
        {
             if (currentEvent.beatsBtwWave == 0 && !canSpawn)
        {
            canSpawn = true;
            currentEventNumber++;
            currentEvent = Events[currentEventNumber];
            timeGo = true;
        }
        }

       

        if (currentEvent.timeRest)
        {
            if (currentEvent.songPositionWave < songPosition)
            {
            canSpawn = true;
            currentEventNumber++;
            currentEvent = Events[currentEventNumber];
            beatGo = true;
            }

           
        }

         if (Input.GetKeyDown(KeyCode.Space))
         {
             if (!willPress)
             {
                 test2.SetActive(true);
             }
             else if (willPress)
             {
                 metronome_audioSrc.PlayOneShot(Nothai, 1f);
                 test3.SetActive(true);
                 willPress = false;
             }
             test1.SetActive(true);
         }



    }

    void ExecuteEvent()
    {
          if (canSpawn == true)
          {

              if (currentEvent.beatMode == true && beatGo == true)
              {
                  beatGo = false;
                  EventType();
                  
                    

              }

              if (currentEvent.timeMode == true && beatGo == true)
              {
                  
                 timeGo = false;
                 EventType();
                 
              }
              
            
          }

          if (currentEvent.noOfEvents == 0)
          {
              canSpawn = false;
              
          }
    }

    void EventType()
    {
        switch (currentEvent.eventType)
                 {
                  case 1: 
                  Debug.Log("impostor");
                  metronome_audioSrc.PlayOneShot(hai, 1f);
                  break;
                  case 2:
                   StartCoroutine(slackTimer());
                   break;
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
       
         if (!canSpawn && currentEvent.beatMode == true)
            {
                currentEvent.beatsBtwWave -= 1;
            }
            if (canSpawn && currentEvent.noOfEvents > 0)
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

    IEnumerator slackTimer()
    {
        willPress = true;
        yield return new WaitForSeconds(1f);
        willPress = false;
    }


}