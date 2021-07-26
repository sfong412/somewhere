using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logbook : MonoBehaviour
{
    RhythmGameMapper rhythmGameMapper;

    public GameObject pauseTab;
    public GameObject birdsTab;

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
        rhythmGameMapper.musicSource.UnPause();
        gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("GamePlay");
    }

    public void SwitchToPauseTab()
    {
        pauseTab.SetActive(true);
        birdsTab.SetActive(false);
    }

    public void SwitchToBirdsTab()
    {
        pauseTab.SetActive(false);
        birdsTab.SetActive(true);
    }
}
