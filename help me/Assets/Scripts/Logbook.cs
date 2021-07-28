using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logbook : MonoBehaviour
{
    public RhythmGameMapper rhythmGameMapper;

    public GameObject pauseTab;
    public GameObject birdsTab;

    public Animator bookLog;

    public AudioSource audioSource;

    public AudioClip buttonClick1;
    public AudioClip buttonClick2;
    public AudioClip buttonClick3;

    // Start is called before the first frame update
    void Start()
    {
        rhythmGameMapper = GameObject.Find("Rhythm Game Mapper").GetComponent<RhythmGameMapper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        var randomButtonClick = Random.Range(0 , 2);
        switch(randomButtonClick)
        {
            case 0:
            audioSource.PlayOneShot(buttonClick1, 1f);
            break; 

            case 1:
            audioSource.PlayOneShot(buttonClick2, 1f);
            break;

            case 2:
            audioSource.PlayOneShot(buttonClick3, 1f);
            break;
        }
       bookLog.SetBool("Enter", false);
       rhythmGameMapper.Resume();
    }

    public void ReturnToMainMenu()
    {
        var randomButtonClick = Random.Range(0 , 2);
        switch(randomButtonClick)
        {
            case 0:
            audioSource.PlayOneShot(buttonClick1, 1f);
            break; 

            case 1:
            audioSource.PlayOneShot(buttonClick2, 1f);
            break;

            case 2:
            audioSource.PlayOneShot(buttonClick3, 1f);
            break;
        }
        StartCoroutine(ReturnToMenu());
        
    }

    public void RestartGame()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("GamePlay");
    }

    public void SwitchToPauseTab()
    {
        var randomButtonClick = Random.Range(0 , 2);
        switch(randomButtonClick)
        {
            case 0:
            audioSource.PlayOneShot(buttonClick1, 1f);
            break; 

            case 1:
            audioSource.PlayOneShot(buttonClick2, 1f);
            break;

            case 2:
            audioSource.PlayOneShot(buttonClick3, 1f);
            break;
        }
        pauseTab.SetActive(true);
        birdsTab.SetActive(false);
    }

    public void SwitchToBirdsTab()
    {
        var randomButtonClick = Random.Range(0 , 2);
        switch(randomButtonClick)
        {
            case 0:
            audioSource.PlayOneShot(buttonClick1, 1f);
            break; 

            case 1:
            audioSource.PlayOneShot(buttonClick2, 1f);
            break;

            case 2:
            audioSource.PlayOneShot(buttonClick3, 1f);
            break;
        }
        pauseTab.SetActive(false);
        birdsTab.SetActive(true);
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
