using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MappingCode : MonoBehaviour
{
    public RhythmGameMapper rhythms;

    public void TutorialRedCardinalPatternDemo()
    {
                    rhythms.loopType = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 5;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Bot Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 3;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void RedCardinalTutorialGameplay()
    {
                    rhythms.loopType = 2;
                    //Event Clear
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    //Cardinal Jump Out
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 5;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    //Cardinal Call
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Player Response
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void TutorialBlueJayPatterns()
    {
                    rhythms.loopType = 3;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 6;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 3;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 4;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Bot Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 8;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void BlueJayTutorialGameplay()
    {
                    rhythms.loopType = 4;
                    //Event Clear
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    //Blue Jay Hop Out
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 6;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    //Blue Jay Call
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 3;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 4;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Player Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 7;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }
    public void TutorialBullFinchPatterns()
    {
                    rhythms.loopType = 5;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 9;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 4;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 10;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Bot Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 12;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

     public void BullFinchTutorialGamePlay()
    {
                    rhythms.loopType = 6;
                    //Event Clear
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    //BullFinch Hop out
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 9;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    //BullFinch Call
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 4;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 10;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Player Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 11;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void TutorialParrotPatterns()
    {
                    rhythms.loopType = 7;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 13;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 2;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 16;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Bot Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 14;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void ParrotTutorialGamePlay()
    {
                    rhythms.loopType = 8;
                    //Event Clear
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    //Parrot Hop Out
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 13;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    //Parrot Call
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 16;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    //Player Call
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 15;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }

    public void Brazil()
    {
         rhythms.loopType = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 0;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;
    }  

    public void backingTrack1()
    {
         rhythms.loopType = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 1].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 1].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 1].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 1].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatsBtwWave = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 2].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 2].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 2].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 2].timeRest = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatsBtwWave = 3;
                    rhythms.Events[rhythms.currentEventNumber+ 3].eventType = 0;
                    rhythms.Events[rhythms.currentEventNumber+ 3].noOfEvents = 1;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatMode = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeMode = false;
                    rhythms.Events[rhythms.currentEventNumber+ 3].beatRest = true;
                    rhythms.Events[rhythms.currentEventNumber+ 3].timeRest = false;

                    rhythms.Events[4].beatsBtwWave = 1;
                    rhythms.Events[4].eventType = 13;
                    rhythms.Events[4].noOfEvents = 1;
                    rhythms.Events[4].beatMode = true;
                    rhythms.Events[4].timeMode = false;
                    rhythms.Events[4].beatRest = true;
                    rhythms.Events[4].timeRest = false;
                    
                    rhythms.Events[5].beatsBtwWave = 1;
                    rhythms.Events[5].eventType = 16;
                    rhythms.Events[5].noOfEvents = 1;
                    rhythms.Events[5].beatMode = true;
                    rhythms.Events[5].timeMode = false;
                    rhythms.Events[5].beatRest = true;
                    rhythms.Events[5].timeRest = false;

                    rhythms.Events[6].beatsBtwWave = 1;
                    rhythms.Events[6].eventType = 11;
                    rhythms.Events[6].noOfEvents = 1;
                    rhythms.Events[6].beatMode = true;
                    rhythms.Events[6].timeMode = false;
                    rhythms.Events[6].beatRest = true;
                    rhythms.Events[6].timeRest = false;

                    rhythms.Events[7].beatsBtwWave = 1;
                    rhythms.Events[7].eventType = 1;
                    rhythms.Events[7].noOfEvents = 1;
                    rhythms.Events[7].beatMode = true;
                    rhythms.Events[7].timeMode = false;
                    rhythms.Events[7].beatRest = true;
                    rhythms.Events[7].timeRest = false;

                    rhythms.Events[8].beatsBtwWave = 1;
                    rhythms.Events[8].eventType = 5;
                    rhythms.Events[8].noOfEvents = 1;
                    rhythms.Events[8].beatMode = true;
                    rhythms.Events[8].timeMode = false;
                    rhythms.Events[8].beatRest = true;
                    rhythms.Events[8].timeRest = false;

                    rhythms.Events[9].beatsBtwWave = 1;
                    rhythms.Events[9].eventType = 2;
                    rhythms.Events[9].noOfEvents = 1;
                    rhythms.Events[9].beatMode = true;
                    rhythms.Events[9].timeMode = false;
                    rhythms.Events[9].beatRest = true;
                    rhythms.Events[9].timeRest = false;

                    rhythms.Events[10].beatsBtwWave = 1;
                    rhythms.Events[10].eventType = 1;
                    rhythms.Events[10].noOfEvents = 1;
                    rhythms.Events[10].beatMode = true;
                    rhythms.Events[10].timeMode = false;
                    rhythms.Events[10].beatRest = true;
                    rhythms.Events[10].timeRest = false;

                    rhythms.Events[11].beatsBtwWave = 3;
                    rhythms.Events[11].eventType = 6;
                    rhythms.Events[11].noOfEvents = 1;
                    rhythms.Events[11].beatMode = true;
                    rhythms.Events[11].timeMode = false;
                    rhythms.Events[11].beatRest = true;
                    rhythms.Events[11].timeRest = false;

                    rhythms.Events[12].beatsBtwWave = 3;
                    rhythms.Events[12].eventType = 4;
                    rhythms.Events[12].noOfEvents = 1;
                    rhythms.Events[12].beatMode = true;
                    rhythms.Events[12].timeMode = false;
                    rhythms.Events[12].beatRest = true;
                    rhythms.Events[12].timeRest = false;

                    rhythms.Events[13].beatsBtwWave = 1;
                    rhythms.Events[13].eventType = 7;
                    rhythms.Events[13].noOfEvents = 1;
                    rhythms.Events[13].beatMode = true;
                    rhythms.Events[13].timeMode = false;
                    rhythms.Events[13].beatRest = true;
                    rhythms.Events[13].timeRest = false;

                    rhythms.Events[14].beatsBtwWave = 1;
                    rhythms.Events[14].eventType = 7;
                    rhythms.Events[14].noOfEvents = 1;
                    rhythms.Events[14].beatMode = true;
                    rhythms.Events[14].timeMode = false;
                    rhythms.Events[14].beatRest = true;
                    rhythms.Events[14].timeRest = false;

                    rhythms.Events[15].beatsBtwWave = 1;
                    rhythms.Events[15].eventType = 5;
                    rhythms.Events[15].noOfEvents = 1;
                    rhythms.Events[15].beatMode = true;
                    rhythms.Events[15].timeMode = false;
                    rhythms.Events[15].beatRest = true;
                    rhythms.Events[15].timeRest = false;

                    rhythms.Events[16].beatsBtwWave = 1;
                    rhythms.Events[16].eventType = 2;
                    rhythms.Events[16].noOfEvents = 1;
                    rhythms.Events[16].beatMode = true;
                    rhythms.Events[16].timeMode = false;
                    rhythms.Events[16].beatRest = true;
                    rhythms.Events[16].timeRest = false;

                    rhythms.Events[17].beatsBtwWave = 2;
                    rhythms.Events[17].eventType = 1;
                    rhythms.Events[17].noOfEvents = 1;
                    rhythms.Events[17].beatMode = true;
                    rhythms.Events[17].timeMode = false;
                    rhythms.Events[17].beatRest = true;
                    rhythms.Events[17].timeRest = false;
                    
    }  
}
