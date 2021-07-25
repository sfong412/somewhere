using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    RhythmGameMapper rhythm;

    TextMeshProUGUI randomBirdType;
    TextMeshProUGUI targetBeatsArray;

    // Start is called before the first frame update
    void Start()
    {
        rhythm = GameObject.Find("Rhythm Game Mapper").GetComponent<RhythmGameMapper>();

        randomBirdType = GameObject.Find("randomBirdType").GetComponent<TextMeshProUGUI>();
        targetBeatsArray = GameObject.Find("targetBeats array").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        randomBirdType.text = "random bird number: " + rhythm.randomBirdnumber;
        targetBeatsArray.text = string.Join("", rhythm.targetBeats);
    }
}
