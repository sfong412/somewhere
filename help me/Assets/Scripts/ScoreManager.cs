using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Animator text;
    public TextMeshProUGUI scoreText;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.SetText(score.ToString());
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
         text.SetBool("addScore" ,true);
         yield return new WaitForSeconds(0.2f);
        text.SetBool("addScore" ,false);
         
    }
}
