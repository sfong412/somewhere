using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birbCode : MonoBehaviour
{
    public GameObject birbMouth;
    public RhythmGameMapper mapper;
    public Animator birbMove;
    public Animator birb;

    bool exit = true;
    // Start is called before the first frame update
    void Start()
    {
                mapper = GameObject.Find("Rhythm Game Mapper").GetComponent<RhythmGameMapper>();
    }

    void Awake()
    {
          mapper = GameObject.Find("Rhythm Game Mapper").GetComponent<RhythmGameMapper>();
        mapper.birdMouth = birbMouth.transform;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (mapper.birbTurn == true)
        {
           StartCoroutine(birbTurn());
          //  justSang = true;
        }
        if (exit == false || (mapper.birbTurn3 == false && mapper.tutorial == true))
        {
            birbMove.SetBool("birbGo", false);
            birb.SetBool("mySing", false);
            StartCoroutine(Death());
        }

        if (mapper.singRightNow == true)
        {
            birb.SetBool("mySing", true);
        }
        else
        {
            birb.SetBool("mySing", false);
        }


    }

    IEnumerator birbTurn()
    {
      birbMove.SetBool("birbGo", true);
      yield return new WaitForSeconds(0.5f);
      birb.SetBool("myTurn", true);

    }

    public void birbTurn3()
    {
      //  birbMove.SetBool("birbGo", false);
       // birb.SetBool("mySing", false);
       // StartCoroutine(Death());

       exit = false;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
       
    }
}
