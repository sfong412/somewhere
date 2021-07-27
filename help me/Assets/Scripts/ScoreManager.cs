using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Animator text;
    public TextMeshProUGUI scoreText;
    static public float score;

    public GameObject RhythmGameMapper;

    // Start is called before the first frame update
    void Start()
    { 
        if (score == null)
        {
            score = 0;
        }
        
        scoreText.SetText(score.ToString());
        //RhythmGameMapper.SetActive(false);
    }

    void Awake()
    {
        //StartCoroutine(pancakes());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score += 1;
        scoreText.SetText(score.ToString());
        StartCoroutine(addScoreAnimation());
    }

    IEnumerator addScoreAnimation()
    {
        text.SetBool("addScore", true);
        yield return new WaitForSeconds(0.2f);
        text.SetBool("addScore", false);

    }

    IEnumerator pancakes()
    {
        yield return new WaitForSeconds(2f);
        RhythmGameMapper.SetActive(true);
    }
}
