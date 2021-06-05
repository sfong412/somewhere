using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameController : MonoBehaviour
{

    public float gameTimer;
    public AudioClip sus;

    public GameObject sussy;
    public GameObject sussy2;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
          
         StartCoroutine(playMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(audioSource.time);

        if (audioSource.time > 6.9f)
        {
            Debug.Log("nice");
        }
        
    }

    void FixedUpdate()
    {
        
    }

    void Timer()
    {
        
    }

    IEnumerator playMusic()
    {
        yield return new WaitForSeconds(2f);
        sussy2.SetActive(true);
        yield return new WaitForSeconds(1f);
        sussy.SetActive(true);
       
        
    }
}
