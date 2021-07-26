using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField] private beatMap currentEvent;
    [SerializeField] private int currentEventNumber;

    public bool canSpawn;

    public int nextBeatsBtwWave;
    public float nextTimeBtwWave;

    public int callBackNumber;
    public static RhythmGameMapper Instance { get; set; }

    [Header("Assignables")]

    public float beatsPerSecond;

    public float beatsPerMeasure;

    //public float bpmDividedByFour;
    public float secPerBeat;

    public float secPerMeasure;
    public float songPosition;
    public float songDuration;
    private float songPositionInBeatsExact;
    public float songPositionInBeats;

    public float songPositionInMeasures;

    public int completedBeats = 0;

    public int completedMeasures = 0;

    public float loopPositionInBeats;

    public float beatThresholdLate;
    public float beatThresholdEarly;

    float[] targetBeats = new float[3];

    private float lastReportedBeat = 0f;

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

    public bool canPress;

    public bool newWaveGenerate;

    public bool autoPlay = true;

    public int randomBirdnumber;

    public int nextEventRandom;

    public AudioClip sound3;
    public AudioClip sound5;

    public AudioClip sound1;
    public AudioClip sound2;

    public GameObject clickedText;
    public GameObject failedText;
    public GameObject successText;
    public ScoreManager scoreManager;

    public Animator player;

    public bool birbTurn;

    public GameObject redBirb;

    public GameObject parrot;

    public GameObject blueJay;

    public GameObject blackBird;
    public Transform redBirbSpawn;

    void Start()
    {
        RhythmGameMapper.Instance = this;
        //Load the AudioSource attached to the Conductor GameObject
        musicSource.GetComponent<AudioSource>();
        //Metronome
        //metronome_audioSrc.GetComponent<AudioSource>();
        //Calculate the number of seconds in each beat
        secPerRealBeat = 60f / (beatsPerSecond);
        secPerBeat = 60f / (beatsPerSecond);
        //Record the time when the music starts
        dspSongTime = (float)musicSource.time;
        //Start the music
        //musicSource.time = 10f;

        if (autoPlay)
            StartCoroutine(StartMusic());
        // musicSource.Play();

        songLength = musicSource.clip.length;
        Application.targetFrameRate = 120;
        currentEvent = Events[currentEventNumber];
    }

    void Awake()
    {
        canPress = true;
        newWaveGenerate = true;
        nextEventRandom += 3;
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(2f);
        musicSource.Play();
    }

    void Update()
    {
        if (musicSource.isPlaying == false)
        {
            return;
        }

        lastReportedBeat = songPositionInBeats;
        if (musicSource.isPlaying)
        {
            secPerRealBeat = (60f / (beatsPerSecond));
            secPerBeat = (60f / (beatsPerSecond));
            secPerMeasure = secPerRealBeat * beatsPerMeasure;

            //determine how many seconds since the song started
            //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            songPosition = (float)(musicSource.time - dspSongTime - firstBeatOffset);
            //determine how many beats since the song started
            songPositionInBeatsExact = songPosition / secPerBeat;
            songPositionInBeats = (float)songPositionInBeatsExact;
            songPositionInMeasures = (float)(songPosition / secPerMeasure);
            ReportBeat();
            //GameTimeline();

            if (songPositionInBeats >= (completedBeats + 1))
            {
                completedBeats++;
            }

            if (songPositionInBeats >= (completedMeasures + 1) * beatsPerMeasure)
            {
                completedMeasures++;
            }

            loopPositionInBeats = songPositionInBeats - completedMeasures * beatsPerMeasure;

            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log(secPerRealBeat);
            }

            songPosBeat = (int)songPositionInBeats / beatsPerMeasure;
            ExecuteEvent();

            InThreshold();
        }

        if (currentEvent.beatRest)
        {
            if (currentEvent.beatsBtwWave == 0 && !canSpawn)
            {
                canSpawn = true;
                currentEventNumber++;
                newWaveGenerate = true;
                randomBirdnumber = Random.Range(0, 4);
                currentEvent = Events[currentEventNumber];
                timeGo = true;

            }
        }

        player.SetBool("willPress", willPress);



        if (currentEvent.timeRest)
        {
            if (currentEvent.songPositionWave < songPosition)
            {
                canSpawn = true;
                currentEventNumber++;
                newWaveGenerate = true;
                randomBirdnumber = Random.Range(0, 4);
                currentEvent = Events[currentEventNumber];
                beatGo = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPress)
            {
                if (!willPress)
                {
                    failedText.SetActive(true);
                }
                else if (willPress)
                {
                    successText.SetActive(true);
                    willPress = false;
                    scoreManager.AddScore();
                    switch (callBackNumber)
                    {
                        case 0:
                            metronome_audioSrc.PlayOneShot(sound5, 1f);
                            break;
                        case 1:
                            metronome_audioSrc.PlayOneShot(sound1, 1f);
                            break;
                    }
                    player.SetBool("isPressed", true);


                }
                clickedText.SetActive(true);


            }

        }

        if (currentEventNumber == nextEventRandom && newWaveGenerate == true)
        {
            Debug.Log("sus");
            currentEvent.noOfEvents = 0;
            switch (randomBirdnumber)
            {
                case 0:
                    if (!metronome_audioSrc.isPlaying)
                    {
                        Instantiate(redBirb, redBirbSpawn.position, Quaternion.identity);
                        birbTurn = true;
                        Debug.Log("1");
                        callBackNumber = 0;
                        Events[currentEventNumber + 1].beatsBtwWave = 1;
                        Events[currentEventNumber + 1].eventType = 2;
                        Events[currentEventNumber + 1].noOfEvents = 1;
                        Events[currentEventNumber + 1].beatMode = true;
                        Events[currentEventNumber + 1].timeMode = false;
                        Events[currentEventNumber + 1].beatRest = true;
                        Events[currentEventNumber + 1].timeRest = false;
                        Events[currentEventNumber + 2].beatsBtwWave = 1;
                        Events[currentEventNumber + 2].eventType = 1;
                        Events[currentEventNumber + 2].noOfEvents = 1;
                        Events[currentEventNumber + 2].beatMode = true;
                        Events[currentEventNumber + 2].timeMode = false;
                        Events[currentEventNumber + 2].beatRest = true;
                        Events[currentEventNumber + 2].timeRest = false;
                        Events[currentEventNumber + 3].beatsBtwWave = 1;
                        Events[currentEventNumber + 3].eventType = 0;
                        Events[currentEventNumber + 3].noOfEvents = 1;
                        Events[currentEventNumber + 3].beatMode = true;
                        Events[currentEventNumber + 3].timeMode = false;
                        Events[currentEventNumber + 3].beatRest = true;
                        Events[currentEventNumber + 3].timeRest = false;
                    }
                    break;



                case 1:
                    if (!metronome_audioSrc.isPlaying)
                    {
                          Instantiate(parrot, redBirbSpawn.position, Quaternion.identity);
                         birbTurn = true;
                        Debug.Log("2");
                        callBackNumber = 1;
                        Events[currentEventNumber + 1].beatsBtwWave = 2;
                        Events[currentEventNumber + 1].eventType = 3;
                        Events[currentEventNumber + 1].noOfEvents = 1;
                        Events[currentEventNumber + 1].beatMode = true;
                        Events[currentEventNumber + 1].timeMode = false;
                        Events[currentEventNumber + 1].beatRest = true;
                        Events[currentEventNumber + 1].timeRest = false;
                        Events[currentEventNumber + 2].beatsBtwWave = 1;
                        Events[currentEventNumber + 2].eventType = 4;
                        Events[currentEventNumber + 2].noOfEvents = 1;
                        Events[currentEventNumber + 2].beatMode = true;
                        Events[currentEventNumber + 2].timeMode = false;
                        Events[currentEventNumber + 2].beatRest = true;
                        Events[currentEventNumber + 2].timeRest = false;
                        Events[currentEventNumber + 3].beatsBtwWave = 1;
                        Events[currentEventNumber + 3].eventType = 0;
                        Events[currentEventNumber + 3].noOfEvents = 1;
                        Events[currentEventNumber + 3].beatMode = true;
                        Events[currentEventNumber + 3].timeMode = false;
                        Events[currentEventNumber + 3].beatRest = true;
                        Events[currentEventNumber + 3].timeRest = false;
                    }
                    break;

                case 2:
                    if (!metronome_audioSrc.isPlaying)
                    {
                        Instantiate(blueJay, redBirbSpawn.position, Quaternion.identity);
                         birbTurn = true;
                        Debug.Log("3");
                        callBackNumber = 0;
                        Events[currentEventNumber + 1].beatsBtwWave = 1;
                        Events[currentEventNumber + 1].eventType = 2;
                        Events[currentEventNumber + 1].noOfEvents = 1;
                        Events[currentEventNumber + 1].beatMode = true;
                        Events[currentEventNumber + 1].timeMode = false;
                        Events[currentEventNumber + 1].beatRest = true;
                        Events[currentEventNumber + 1].timeRest = false;
                        Events[currentEventNumber + 2].beatsBtwWave = 1;
                        Events[currentEventNumber + 2].eventType = 1;
                        Events[currentEventNumber + 2].noOfEvents = 1;
                        Events[currentEventNumber + 2].beatMode = true;
                        Events[currentEventNumber + 2].timeMode = false;
                        Events[currentEventNumber + 2].beatRest = true;
                        Events[currentEventNumber + 2].timeRest = false;
                        Events[currentEventNumber + 3].beatsBtwWave = 1;
                        Events[currentEventNumber + 3].eventType = 0;
                        Events[currentEventNumber + 3].noOfEvents = 1;
                        Events[currentEventNumber + 3].beatMode = true;
                        Events[currentEventNumber + 3].timeMode = false;
                        Events[currentEventNumber + 3].beatRest = true;
                        Events[currentEventNumber + 3].timeRest = false;
                    }
                    break;

                case 3:
                if (!metronome_audioSrc.isPlaying)
                    {
                          Instantiate(blackBird, redBirbSpawn.position, Quaternion.identity);
                         birbTurn = true;
                        Debug.Log("4");
                        callBackNumber = 1;
                        Events[currentEventNumber + 1].beatsBtwWave = 2;
                        Events[currentEventNumber + 1].eventType = 3;
                        Events[currentEventNumber + 1].noOfEvents = 1;
                        Events[currentEventNumber + 1].beatMode = true;
                        Events[currentEventNumber + 1].timeMode = false;
                        Events[currentEventNumber + 1].beatRest = true;
                        Events[currentEventNumber + 1].timeRest = false;
                        Events[currentEventNumber + 2].beatsBtwWave = 1;
                        Events[currentEventNumber + 2].eventType = 4;
                        Events[currentEventNumber + 2].noOfEvents = 1;
                        Events[currentEventNumber + 2].beatMode = true;
                        Events[currentEventNumber + 2].timeMode = false;
                        Events[currentEventNumber + 2].beatRest = true;
                        Events[currentEventNumber + 2].timeRest = false;
                        Events[currentEventNumber + 3].beatsBtwWave = 1;
                        Events[currentEventNumber + 3].eventType = 0;
                        Events[currentEventNumber + 3].noOfEvents = 1;
                        Events[currentEventNumber + 3].beatMode = true;
                        Events[currentEventNumber + 3].timeMode = false;
                        Events[currentEventNumber + 3].beatRest = true;
                        Events[currentEventNumber + 3].timeRest = false;
                    }
                    break;


            }
            newWaveGenerate = false;
            nextEventRandom += 3;
        }

        if (currentEventNumber >= Events.Length - 3)
        {
            for (int i = 0; i < Events.Length; i++)
            {
                Events[i].beatsBtwWave = 1;
                Events[i].eventType = 0;
                Events[i].noOfEvents = 1;
                Events[i].beatMode = true;
                Events[i].timeMode = false;
                Events[i].beatRest = true;
                Events[i].timeRest = false;
            }
            currentEventNumber = 0;
            nextEventRandom = 0;
            currentEvent = Events[0];
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (!metronome_audioSrc.isPlaying)
        {
            player.SetBool("isPressed", false);
            StartCoroutine(takePictureAnimator());
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
            case 0:

                break;
            case 1:
                //4th note as needed input
                targetBeats[0] = 3f;
                targetBeats[1] = 5f;
                targetBeats[2] = 5f;
                StartCoroutine(slackTimer());
                break;

            case 2:
                //StartCoroutine(slackTimer());
                metronome_audioSrc.PlayOneShot(sound3, 1f);
                break;
            case 3:
                //2nd, 3rd and 4th note only as input
                targetBeats[0] = 1f;
                targetBeats[1] = 2f;
                targetBeats[2] = 3f;
                StartCoroutine(slackTimer());
                break;
            case 4:
                metronome_audioSrc.PlayOneShot(sound2, 1f);
                break;
        }

    }

    void ReportBeat()
    {
        if (lastReportedBeat < (int)songPositionInBeats)
        {
            onBeat = true;
            beatsInLoop += 1;
            beatTime += 0.25f;
            QuarterBeat();
            lastReportedBeat = songPositionInBeats;
            StartCoroutine(fadeText());
        }
        else
        {
            onBeat = false;
        }
    }

    [SerializeField] private int beatsInLoop;

    public void QuarterBeat()
    {
        if (metronome == true)
        {
            //plays metronome click at every quarter note
            metronome_audioSrc.PlayOneShot(metronome_audioSrc.clip, 1f);
        }




        if (!canSpawn && currentEvent.beatMode == true)
        {
            currentEvent.beatsBtwWave -= 1;
        }
        if (canSpawn && currentEvent.noOfEvents > 0)
        {
            beatGo = true;
            currentEvent.noOfEvents--;
        }


        if (beatsInLoop == 4)
        {
            beatsInLoop = 0;
        }

    }



    public void FullBeat()
    {
        //BeatEvent();
        Debug.Log("Full");

    }

    //sherm's rhythm system test method
    public void InThreshold()
    {
        for (int i = 0; i < targetBeats.Length; i++)
        {
            if (loopPositionInBeats > targetBeats[i] - beatThresholdEarly && loopPositionInBeats < targetBeats[i] + beatThresholdLate)
            {
                willPress = true;
                if (willPress == true)
                {
                    //Debug.Log("kill me");
                    break;
                }
            }
            else
            {
                willPress = false;
            }
        }
    }

    IEnumerator slackTimer()
    {
        willPress = true;
        yield return new WaitForSeconds(0.5f);
        willPress = false;

    }

    IEnumerator fadeText()
    {
        yield return new WaitForSeconds(0.4f);
        clickedText.SetActive(false);
        failedText.SetActive(false);
        successText.SetActive(false);
    }

    IEnumerator takePictureAnimator()
    {
        player.SetBool("takePicture", true);
        yield return new WaitForSeconds(0.01f);
        player.SetBool("takePicture", false);
    }

}