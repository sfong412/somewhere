using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    public enum dayCycle
    {
        Day,
        Night
    };

    static public dayCycle currentTime;

    public SpriteRenderer backgroundRenderer;

    public Sprite dayBackground;

    public Sprite nightBackground;

    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();

        if (currentTime == dayCycle.Day)
        {
            backgroundRenderer.sprite = dayBackground;
        }
        else if (currentTime == dayCycle.Night)
        {
            backgroundRenderer.sprite = nightBackground;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void switchBackground()
    {
        if (currentTime == dayCycle.Day)
        {
            currentTime = dayCycle.Night;
        }
        else if (currentTime == dayCycle.Night)
        {
            currentTime = dayCycle.Day;
        } 
    }
}
