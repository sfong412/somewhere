using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
    public beatMap[] Events;

    public beatMap currentEvent;
    public int currentEventNumber;

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

    public AudioClip sound4;

    public AudioClip sound6;
    public AudioClip sound01;

    public AudioClip sound02;

    public AudioClip sound03;

    public AudioClip sound04;

    public AudioClip sound05;

    public AudioClip sound06;

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

    public GameObject birbNote1;
    public GameObject birbNote2;

    public GameObject birbNote3;

    public GameObject playerNote1;
    public GameObject playerNote2;
    public GameObject playerNote3;

    public bool birbTurn2;

    public bool playerTurn;

    public Transform playerMouth;

    public Transform birdMouth;

    DayNightCycle dayNightCycle;

    public GameObject logbook;

    public GameObject gameOverScreen;

    public TextMeshProUGUI birdSeedPacketsCounter;

    public int noteEventNumber;

    public bool canBird;

    public bool singRightNow;

    public bool birbTurn3;

    public bool Resume2;
    public Animator bookLog;

    public Animator blackOut;

    public Animator dayTime;

    public Animator lowSun;

    public Animator night;

    public Animator earlyMorning;

    public bool sceneChange;

    public int changeNumber;

    public bool paused;

    public bool notBadAtGame;

    public int lives;

    public bool tutorial;

    public Transform radioMouth;

    public int loopType;

    public MappingCode mappingCode;

    public Animator Enter;

    public bool watching;

    public int realerScore;

    public Animator light;

    public Animator leftLamp;

    public Animator rightLamp;

    public bool singleTap;

    public float _doubleTapTimeD;

    public int doubleTapRootBeer;

    bool doubleTapD = false;

    public float musicTimeStart;

    public float musicTimeRemaining;

    public bool timerIsRunning;

    public float minDouble;

    public float maxDouble;

    public bool imTired;

    public bool cryAboutIt;

    public Transform bopSpawn;

    public GameObject[] bop;

    public GameObject parent;

    public GameObject parent2;

    public GameObject parent3;

    public GameObject parent4;

    public Animator lampPost;

    public Animator lampPost2;

    public AudioClip song1;
    public AudioClip song2;

    public AudioClip song3;

    public float killmeplease;

    public bool no;


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
        dspSongTime = (float)AudioSettings.dspTime;
        //Start the music
        //musicSource.time = 10f;
        Application.targetFrameRate = 120;
        musicTimeRemaining = musicTimeStart;



        //dayNightCycle = GameObject.Find("Background").GetComponent<DayNightCycle>();
    }

    
     
    void Awake()
    {
        canPress = true;
        newWaveGenerate = true;
        nextEventRandom += 3;
        canBird = true;
        birbTurn3 = true;
        if (autoPlay)
        {
            musicSource.clip = song1;
            songLength = musicSource.clip.length;



        }
        currentEventNumber = 0;
        currentEvent = Events[currentEventNumber];
        changeNumber = 0;
        notBadAtGame = false;
        realerScore = 0;
        doubleTapRootBeer = 0;
        loopType = -1;
        parent.SetActive(false);
        parent2.SetActive(false);
        parent3.SetActive(false);
        parent4.SetActive(false);
        ScoreManager.score = 0;
        if (imTired)
        {
            Resume();
        }
        StartMusic();
        paused = true;
        killmeplease = 0;
        no = false;


   

    }

   


    void StartMusic()
    {
        StartCoroutine(pleaseWork());
    }

    IEnumerator pleaseWork()
    {
        yield return new WaitForSecondsRealtime(1);
        musicSource.Play();
        paused = false;
        mappingCode.backingTrack1();
        no = true;
    }

    IEnumerator killmeplease2()
    {
        yield return new WaitForSecondsRealtime(0.1f);
       paused = false;
    }


    void Update()
    {

       
        musicSource.pitch = 1f;
        if (lives == 0)
        {
            player.SetBool("isGameOver", true);
            musicSource.Pause();
            StartCoroutine(gameOver());
            paused = true;
            canPress = false;
            scoreManager.SaveScore();
            scoreManager.highScoreText.text = "High Score: " + ScoreManager.highScore;
            birbTurn3 = false;
            

            if (redBirbSpawn.transform.childCount > 0)
            {
                redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
                //Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
            }
        }


        birdSeedPacketsCounter.text = lives.ToString();

        if (musicSource.isPlaying == false)
        {
          
            if (no)
            {
                if (!paused)
        {
                songPosition = 0;
                sceneChange = true;
                killmeplease += 1;
                Debug.Log("change");
                
            }
            }
                 
            
            
        }

        if (musicSource.isPlaying)
        {
            lastReportedBeat = songPositionInBeats;

            secPerRealBeat = (60f / (beatsPerSecond));
            secPerBeat = (60f / (beatsPerSecond));
            secPerMeasure = secPerRealBeat * beatsPerMeasure;

            //determine how many seconds since the song started
            //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
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


            if (currentEvent.beatRest)
            {
                if (currentEvent.beatsBtwWave <= 0 && !canSpawn)
                {
                    canSpawn = true;
                    currentEventNumber += 1;
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
                    currentEventNumber += 1;
                    newWaveGenerate = true;
                    randomBirdnumber = Random.Range(0, 4);
                    currentEvent = Events[currentEventNumber];
                    beatGo = true;
                }


            }
            if (Input.GetMouseButtonDown(0))
            {
                if (singleTap)
                {
                    if (!watching)
                    {
                        if (canPress)
                        {
                            notBadAtGame = true;
                            if (!willPress)
                            {
                                if (lives < 2)
                                {
                                    lives--;
                                    player.SetBool("isGameOver", true);
                                    musicSource.Pause();
                                    StartCoroutine(gameOver());
                                    paused = true;
                                    canPress = false;
                                    scoreManager.SaveScore();
                                    scoreManager.highScoreText.text = "High Score: " + ScoreManager.highScore;
                                    birbTurn3 = false;

                                    if (redBirbSpawn.transform.childCount > 0)
                                    {
                                        redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
                                        //Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
                                    }
                                }
                                else
                                {
                                    Hurt();
                                    StartCoroutine(flyAway());
                                }
                            }
                            else if (willPress)
                            {
                                realerScore++;
                                PlayerTurnAnimation();
                                singRightNow = false;
                                StartCoroutine(flyAway());
                                //successText.SetActive(true);
                                willPress = false;
                                scoreManager.AddScore();
                                canPress = false;
                                switch (callBackNumber)
                                {
                                    case 0:
                                        metronome_audioSrc.PlayOneShot(sound5, 1f);
                                        break;
                                    case 1:
                                        metronome_audioSrc.PlayOneShot(sound1, 1f);
                                        break;
                                    case 3:
                                        metronome_audioSrc.PlayOneShot(sound05, 1f);
                                        break;
                                }
                                player.SetBool("isPressed", true);
                                StartCoroutine(pressTimer());
                                StartCoroutine(takePictureAnimator());

                                if (redBirbSpawn.transform.childCount > 0)
                                    {
                                        redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
                                        //Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
                                    }


                            }
                            //clickedText.SetActive(true);


                        }

                    }
                }
                else
                {



                    #region doubleTapD

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (willPress)
                        {
                            doubleTapRootBeer += 1;
                            if (doubleTapRootBeer == 1)
                            {
                                switch (callBackNumber)
                                {
                                    case 1:
                                        metronome_audioSrc.PlayOneShot(sound01, 1f);
                                        PlayerTurnAnimation();
                                        break;

                                    case 2:
                                        metronome_audioSrc.PlayOneShot(sound03, 1f);
                                        PlayerTurnAnimation();
                                        break;
                                }
                                notBadAtGame = false;

                            }
                            if (Time.time < _doubleTapTimeD + maxDouble)
                            {
                                doubleTapD = true;
                            }
                            _doubleTapTimeD = Time.time;
                        }

                    }

                    #endregion

                    if (doubleTapD)
                    {
                        if (canPress)
                        {
                            notBadAtGame = true;
                            if (willPress)
                            {
                                realerScore++;
                                PlayerTurnAnimation();
                                singRightNow = false;
                                StartCoroutine(flyAway());
                                //successText.SetActive(true);
                                willPress = false;
                                scoreManager.AddScore();
                                canPress = false;
                                switch (callBackNumber)
                                {
                                    case 1:
                                        metronome_audioSrc.PlayOneShot(sound02, 1f);
                                        break;
                                    case 2:
                                        metronome_audioSrc.PlayOneShot(sound04, 1f);
                                        break;

                                }
                                player.SetBool("isPressed", true);
                                StartCoroutine(pressTimer());
                                StartCoroutine(takePictureAnimator());
                                StopCoroutine(slackTimer(1f));
                                notBadAtGame = true;
                                Debug.Log("DoubleTapD");

                                if (redBirbSpawn.transform.childCount > 0)
                                    {
                                        redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
                                        //Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
                                    }

                            }
                            if (!willPress)
                            {
                                if (lives < 2)
                                {
                                    lives--;
                                    player.SetBool("isGameOver", true);
                                    musicSource.Pause();
                                    paused = true;
                                    canPress = false;
                                    scoreManager.SaveScore();
                                    scoreManager.highScoreText.text = "High Score: " + ScoreManager.highScore;
                                    birbTurn3 = false;

                                    if (redBirbSpawn.transform.childCount > 0)
                                    {
                                        redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
                                       // Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
                                    }

                                    StartCoroutine(gameOver());
                                    StopCoroutine(slackTimer(1f));
                                }
                                else
                                {
                                    if (!doubleTapD)
                                    {
                                        Hurt();
                                        StartCoroutine(flyAway());
                                    }

                                }
                            }
                        }

                    }
                }


            }




            if (currentEventNumber >= Events.Length - 1)
            {
                if (tutorial)
                {
                    currentEventNumber = 0;
                    nextEventRandom = 0;
                    currentEvent = Events[0];
                    switch (loopType)
                    {
                        case 1:
                            mappingCode.TutorialRedCardinalPatternDemo();
                            break;
                        case 2:
                            mappingCode.RedCardinalTutorialGameplay();
                            break;
                        case 3:
                            mappingCode.TutorialBlueJayPatterns();
                            break;

                        case 4:
                            mappingCode.BlueJayTutorialGameplay();
                            break;

                        case 5:
                            mappingCode.TutorialBullFinchPatterns();
                            break;

                        case 6:
                            mappingCode.BullFinchTutorialGamePlay();
                            break;

                        case 7:
                            mappingCode.TutorialParrotPatterns();
                            break;
                        case 8:
                            mappingCode.ParrotTutorialGamePlay();
                            break;

                        case 9:
                            StartCoroutine(fading());
                            break;


                    }
                }

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (imTired)
                {
                    Pause();
                }
                else
                {

                }

            }

            if (!metronome_audioSrc.isPlaying)
            {
                player.SetBool("isPressed", false);
            }
        }


        if (musicSource.isPlaying)
        {
            //bababoey


        }
        else
        {
           
        }

        if (sceneChange)
        {
            
           shootme();
           sceneChange = false;

        }

        if (changeNumber == 2)
        {
            leftLamp.SetBool("lightUp", true);
            rightLamp.SetBool("lightUp", true);
            lampPost.SetBool("groovy", true);
            lampPost2.SetBool("groovy2", true);
        }

        if (changeNumber == 3)
        {
            leftLamp.SetBool("lightUp", false);
            rightLamp.SetBool("lightUp", false);
            lampPost.SetBool("groovy", false);
            lampPost2.SetBool("groovy2", false);

        }








        //GameObject sus = Instantiate(bop, bopSpawn.position, Quaternion.identity);
    }

    void shootme()
    {
         switch (changeNumber)
            {
                case 0:
                    dayTime.SetBool("daytimeBool", true);
                    light.SetFloat("lightNumber", 1);
                    changeNumber += 1;
                    break;
                case 1:
                    lowSun.SetBool("lowSunBool", true);
                    light.SetFloat("lightNumber", 2);
                    changeNumber += 1;
                    break;
                case 2:
                    lampPost.SetBool("groovy", true);
                    lampPost2.SetBool("groovy2", true);
                    night.SetBool("nightBool", true);
                    light.SetFloat("lightNumber", 3);
                    changeNumber += 1;
                    break;
                case 3:
                    lampPost.SetBool("groovy", false);
                    lampPost2.SetBool("groovy2", false);
                    lowSun.SetBool("lowSunBool", false);
                    light.SetFloat("lightNumber", 4);
                    changeNumber += 1;
                    break;
                case 4:
                    dayTime.SetBool("daytimeBool", false);
                    light.SetFloat("lightNumber", 5);
                    changeNumber += 1;
                    break;
                case 5:
                    dayTime.SetBool("daytimeBool", true);
                    light.SetFloat("lightNumber", -1);
                    changeNumber = 1;
                    break;


            }
       
            Debug.Log(killmeplease);
            if (killmeplease == 0)
            {
                musicSource.PlayOneShot(song1, 1f);
                sceneChange = false;
            }

             if (killmeplease == 1)
            {
                musicSource.PlayOneShot(song2, 1f);
                sceneChange = false;
            }

             if (killmeplease == 2)
            {
                musicSource.PlayOneShot(song3, 1f);
                sceneChange = false;
            }

      
           

                 

            
            

            
    }

    public IEnumerator fading()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        blackOut.SetBool("Fade", true);
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("GamePlay");
    }

    IEnumerator gameOver()
    {
        Pause2222();
        yield return new WaitForSecondsRealtime(0.5f);
        gameOverScreen.SetActive(true);
    }




    public void Pause()
    {
        paused = true;
        bookLog.SetBool("Enter", true);
        blackOut.SetBool("Focus", true);
        Time.timeScale = 0;
        musicSource.Pause();
        metronome_audioSrc.Pause();
    }

    public void Pause2222()
    {
        paused = true;
        blackOut.SetBool("Focus", true);
        Time.timeScale = 0;
        musicSource.Pause();
        metronome_audioSrc.Pause();
    }

    public void Pause2()
    {
        paused = true;
        Time.timeScale = 0;
        musicSource.Pause();

    }

    public void Resume()
    {
        StartCoroutine(killmeplease2());
        blackOut.SetBool("Focus", false);
        StartCoroutine(DelayResume());
        Resume2 = true;
    }

    public void Resume22()
    {
        paused = false;
        bookLog.SetBool("Enter", false);
        StartCoroutine(DelayResume());
        Resume2 = true;
    }

    IEnumerator DelayResume()
    {
        yield return new WaitForSecondsRealtime(1);
        Resume2 = true;
    }

    void LateUpdate()
    {
        if (Resume2 == true)
        {
            Time.timeScale = 1;
            musicSource.UnPause();
            metronome_audioSrc.UnPause();
            Resume2 = false;
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

        GameObject red;
        GameObject blue;
        GameObject black;
        //GameObject parrot;

        switch (currentEvent.eventType)
        {
            //NOTHING HAPPENS
            case 0:
                canBird = true;
                break;
            //PLAYER PLAYS THE FLUTE FOR RED BIRD
            case 1:
                StartCoroutine(slackTimer(0.25f));
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when player sound plays: " + songPositionInBeats);
                //metronome_audioSrc.PlayOneShot(sound5, 1f);
                break;
            //RED BIRD SINGS
            case 2:
                if (cryAboutIt)
                {
                    StartCoroutine(redBop());
                }
                singleTap = true;
                //StartCoroutine(slackTimer());
                metronome_audioSrc.PlayOneShot(sound3, 1f);
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when bird sound plays: " + songPositionInBeats);
                birbTurn2 = true;
                singRightNow = true;
                BirbTurnAnimation();


                break;
            //PLAYER RESPONDS TO BLUE JAY
            case 3:

                noteEventNumber = currentEvent.eventType;
                Debug.Log("Song position in beats when player sound plays: " + songPositionInBeats);
                //metronome_audioSrc.PlayOneShot(sound5, 1f);
                RadioTurnAnimation();
                singRightNow = false;
                StartCoroutine(flyAway());
                //successText.SetActive(true);
                willPress = false;
                canPress = false;
                switch (callBackNumber)
                {
                    case 0:
                        metronome_audioSrc.PlayOneShot(sound5, 1f);
                        break;
                    case 1:
                        metronome_audioSrc.PlayOneShot(sound1, 1f);
                        break;
                }
                StartCoroutine(pressTimer());
                notBadAtGame = true;
                break;
            //BLUE JAY SING
            case 4:
                if (cryAboutIt)
                {
                    StartCoroutine(blueJayBop());
                }
                doubleTapRootBeer = 0;
                singleTap = false;
                metronome_audioSrc.PlayOneShot(sound2, 1f);
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when bird sound plays: " + songPositionInBeats);
                birbTurn2 = true;
                singRightNow = true;
                BirbTurnAnimation();
                break;

            //RED BIRD SPAWN
            case 5:
                red = Instantiate(redBirb, redBirbSpawn.position, Quaternion.identity, redBirbSpawn);
                Destroy(red, 10f);
                canBird = false;
                birbTurn = true;
                birbTurn3 = true;
                callBackNumber = 0;
                break;
            //BLUE JAY SPAWN
            case 6:
                singleTap = false;
                doubleTapD = false;
                Instantiate(blueJay, redBirbSpawn.position, Quaternion.identity, redBirbSpawn);
                canBird = false;
                birbTurn = true;
                birbTurn3 = true;
                callBackNumber = 1;
                break;
            //PLAYER RESPOND TO BLUE JAY
            case 7:
                singleTap = false;
                doubleTapD = false;
                StartCoroutine(slackTimer(1f));
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when player sound plays: " + songPositionInBeats);
                //metronome_audioSrc.PlayOneShot(sound5, 1f);
                break;

            case 8:
                StopCoroutine(slackTimer(0.4f));
                noteEventNumber = currentEvent.eventType;
                StartCoroutine(blueJay3());
                singRightNow = false;
                canPress = false;
                StartCoroutine(flyAway());
                break;

            //BLACKBIRD SPAWN
            case 9:
                Instantiate(blackBird, redBirbSpawn.position, Quaternion.identity, redBirbSpawn);
                doubleTapD = false;
                canBird = false;
                birbTurn = true;
                birbTurn3 = true;
                callBackNumber = 2;
                break;

            //BLACKBIRD SING
            case 10:
                if (cryAboutIt)
                {
                    StartCoroutine(bullFinchBop());
                }
                doubleTapRootBeer = 0;
                singleTap = false;
                metronome_audioSrc.PlayOneShot(sound4, 1f);
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when bird sound plays: " + songPositionInBeats);
                birbTurn2 = true;
                singRightNow = true;
                BirbTurnAnimation();
                break;

            case 11:
                StartCoroutine(slackTimer(0.6f));
                doubleTapD = false;
                noteEventNumber = currentEvent.eventType;
                break;

            case 12:
                StopCoroutine(slackTimer(0.6f));
                noteEventNumber = currentEvent.eventType;
                StartCoroutine(Bullfinch());
                singRightNow = false;
                canPress = false;
                StartCoroutine(flyAway());
                break;

            //PARROT SPAWN
            case 13:
                Instantiate(parrot, redBirbSpawn.position, Quaternion.identity, redBirbSpawn);
                canBird = false;
                birbTurn = true;
                birbTurn3 = true;
                callBackNumber = 3;
                break;

            case 14:
                StopCoroutine(slackTimer(0.8f));
                noteEventNumber = currentEvent.eventType;
                RadioTurnAnimation();
                singRightNow = false;
                canPress = false;
                StartCoroutine(flyAway());
                metronome_audioSrc.PlayOneShot(sound05, 1f);
                break;

            case 15:
                StartCoroutine(slackTimer(0.6f));
                noteEventNumber = currentEvent.eventType;
                break;

            //PARROT SINGS
            case 16:
                if (cryAboutIt)
                {
                    StartCoroutine(macawBop());
                }
                singleTap = true;
                metronome_audioSrc.PlayOneShot(sound6, 1f);
                noteEventNumber = currentEvent.eventType;
                //Debug.Log("Song position in beats when bird sound plays: " + songPositionInBeats);
                birbTurn2 = true;
                singRightNow = true;
                BirbTurnAnimation();
                break;







        }

    }

    IEnumerator redBop()
    {
        parent.SetActive(true);
        bop[0].SetActive(true);
        yield return new WaitForSeconds(0.21f);
        bop[0].SetActive(false);
        bop[1].SetActive(true);
        yield return new WaitForSeconds(0.21f);
        bop[1].SetActive(false);
        bop[2].SetActive(true);
        yield return new WaitForSeconds(0.21f);
        bop[2].SetActive(false);
        bop[3].SetActive(true);
        yield return new WaitForSeconds(0.84f);
        bop[3].SetActive(false);
        bop[4].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        bop[4].SetActive(false);
    }

    IEnumerator blueJayBop()
    {
        parent2.SetActive(true);
        bop[5].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[5].SetActive(false);
        bop[6].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        bop[6].SetActive(false);
        bop[7].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[7].SetActive(false);
        bop[8].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        bop[8].SetActive(false);
        bop[9].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        bop[9].SetActive(false);
        bop[10].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[10].SetActive(false);
        bop[11].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[11].SetActive(false);
    }

    IEnumerator bullFinchBop()
    {
        parent3.SetActive(true);
        bop[12].SetActive(true);
        yield return new WaitForSeconds(0.7f);
        bop[12].SetActive(false);
        bop[13].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[13].SetActive(false);
        bop[14].SetActive(true);
        yield return new WaitForSeconds(0.55f);
        bop[14].SetActive(false);
        bop[15].SetActive(true);
        yield return new WaitForSeconds(0.9f);
        bop[15].SetActive(false);
        bop[16].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        bop[16].SetActive(false);
        bop[17].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[17].SetActive(false);
    }

    IEnumerator macawBop()
    {
        parent4.SetActive(true);
        bop[18].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        bop[18].SetActive(false);
        bop[19].SetActive(true);
        yield return new WaitForSeconds(0.15f);
        bop[19].SetActive(false);
        bop[20].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bop[20].SetActive(false);
        bop[21].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[21].SetActive(false);
        bop[22].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        bop[22].SetActive(false);
        bop[23].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        bop[23].SetActive(false);
        bop[24].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        bop[24].SetActive(false);
    }


    IEnumerator blueJay3()
    {
        RadioTurnAnimation();
        metronome_audioSrc.PlayOneShot(sound01, 1f);
        yield return new WaitForSeconds(0.37f);
        RadioTurnAnimation();
        metronome_audioSrc.PlayOneShot(sound02, 1f);
    }

    IEnumerator Bullfinch()
    {
        RadioTurnAnimation();
        metronome_audioSrc.PlayOneShot(sound03, 1f);
        yield return new WaitForSeconds(0.35f);
        RadioTurnAnimation();
        metronome_audioSrc.PlayOneShot(sound04, 1f);
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
            //StartCoroutine(fadeText());
        }
        else
        {
            onBeat = false;
        }
    }

    [SerializeField] private int beatsInLoop;

    public void QuarterBeat()
    {
        if (metronome == true && lastReportedBeat >= 0f)
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

    void PlayerTurnAnimation()
    {
        player.SetBool("isPressed", true);
        switch (noteEventNumber)
        {
            case 1:
                var randomNoteNumber = Random.Range(0, 3);
                switch (randomNoteNumber)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, playerMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, playerMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, playerMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 7:
                var randomNoteNumber2 = Random.Range(0, 3);
                switch (randomNoteNumber2)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, playerMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, playerMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, playerMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 10:
                var randomNoteNumber3 = Random.Range(0, 3);
                switch (randomNoteNumber3)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, playerMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, playerMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, playerMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 15:
                var randomNoteNumber4 = Random.Range(0, 3);
                switch (randomNoteNumber4)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, playerMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, playerMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, playerMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 11:
                var randomNoteNumber5 = Random.Range(0, 3);
                switch (randomNoteNumber5)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, playerMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, playerMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, playerMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;
        }
    }


    void BirbTurnAnimation()
    {
        switch (noteEventNumber)
        {
            case 2:
                StartCoroutine(birbNoteTurn1());
                break;

            case 4:
                StartCoroutine(birbNoteTurn2());
                break;

            case 10:
                StartCoroutine(birbNoteTurn3());
                break;

            case 16:
                StartCoroutine(birbNoteTurn4());
                break;

        }
    }

    void RadioTurnAnimation()
    {
        switch (noteEventNumber)
        {

            case 3:
                var randomNoteNumber = Random.Range(0, 3);
                switch (randomNoteNumber)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, radioMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, radioMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, radioMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 8:
                var randomNoteNumber2 = Random.Range(0, 3);
                switch (randomNoteNumber2)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, radioMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, radioMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, radioMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 12:
                var randomNoteNumber3 = Random.Range(0, 3);
                switch (randomNoteNumber3)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, radioMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, radioMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, radioMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

            case 14:
                var randomNoteNumber4 = Random.Range(0, 3);
                switch (randomNoteNumber4)
                {
                    case 0:
                        GameObject effect = Instantiate(playerNote1, radioMouth.position, Quaternion.identity);
                        Destroy(effect, 2f);
                        break;

                    case 1:
                        GameObject effect2 = Instantiate(playerNote2, radioMouth.position, Quaternion.identity);
                        Destroy(effect2, 2f);
                        break;

                    case 2:
                        GameObject effect3 = Instantiate(playerNote3, radioMouth.position, Quaternion.identity);
                        Destroy(effect3, 2f);
                        break;
                }
                break;

        }
    }


    IEnumerator pressTimer()
    {
        yield return new WaitForSeconds(0.5f);
        canPress = true;

    }

    IEnumerator fadeText()
    {
        yield return new WaitForSeconds(0.6f);
        clickedText.SetActive(false);
        failedText.SetActive(false);
        successText.SetActive(false);
    }

    IEnumerator takePictureAnimator()
    {
        player.SetBool("takePicture", true);
        yield return new WaitForSeconds(0.3f);
        player.SetBool("takePicture", false);
    }

    IEnumerator slackTimer(float wait)
    {
        willPress = true;
        yield return new WaitForSeconds(wait);
        willPress = false;
        if (notBadAtGame == false)
        {
            Hurt();
        }
        else
        {
            notBadAtGame = false;
        }
    }

    void Hurt()
    {
        lives--;
        birbTurn3 = false;

        if (redBirbSpawn.transform.childCount > 0)
        {
            redBirbSpawn.transform.GetChild(0).GetComponent<birbCode>().birbTurn3();
            //Destroy(redBirbSpawn.transform.GetChild(0).gameObject);
        }

        willPress = false;
        canPress = false;
        StartCoroutine(pressTimer());
        StopCoroutine(slackTimer(0.5f));
        StartCoroutine(ow());
        StartCoroutine(flyAway());
    }

    IEnumerator birbNoteTurn1()
    {
        GameObject effect = Instantiate(birbNote1, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        GameObject effect2 = Instantiate(birbNote2, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        GameObject effect3 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        Destroy(effect3, 2f);
        Destroy(effect, 2f);
        Destroy(effect2, 2f);
    }

    IEnumerator birbNoteTurn2()
    {
        GameObject effect = Instantiate(birbNote1, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        GameObject effect2 = Instantiate(birbNote2, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        GameObject effect3 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        GameObject effect4 = Instantiate(birbNote1, birdMouth.position, Quaternion.identity);
        Destroy(effect3, 2f);
        Destroy(effect, 2f);
        Destroy(effect2, 2f);
        Destroy(effect4, 2f);
    }

    IEnumerator birbNoteTurn3()
    {
        GameObject effect = Instantiate(birbNote1, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        GameObject effect2 = Instantiate(birbNote2, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        GameObject effect3 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        Destroy(effect3, 2f);
        Destroy(effect, 2f);
        Destroy(effect2, 2f);
    }

    IEnumerator birbNoteTurn4()
    {
        GameObject effect = Instantiate(birbNote1, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject effect2 = Instantiate(birbNote2, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        GameObject effect3 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        GameObject effect4 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject effect5 = Instantiate(birbNote3, birdMouth.position, Quaternion.identity);
        Destroy(effect3, 2f);
        Destroy(effect, 2f);
        Destroy(effect2, 2f);
        Destroy(effect4, 2f);
        Destroy(effect5, 2f);
    }

    IEnumerator flyAway()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        birbTurn3 = false;

    }

    IEnumerator ow()
    {
        player.SetBool("isPressed", true);
        yield return new WaitForSecondsRealtime(0.3f);
        player.SetBool("isGameOver", true);
        yield return new WaitForSecondsRealtime(0.6f);
        player.SetBool("isPressed", false);
        player.SetBool("isGameOver", false);
    }





}