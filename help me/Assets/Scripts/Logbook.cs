using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logbook : MonoBehaviour
{
    RhythmGameMapper rhythmGameMapper;

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
}
