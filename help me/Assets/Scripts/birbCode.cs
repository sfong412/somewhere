using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birbCode : MonoBehaviour
{

    public RhythmGameMapper mapper;
    public Animator birbMove;
    public Animator birb;
    // Start is called before the first frame update
    void Start()
    {
                mapper = GameObject.Find("Rhythm Game Mapper").GetComponent<RhythmGameMapper>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (mapper.birbTurn == true)
        {
           StartCoroutine(birbTurn());

        }
    }

    IEnumerator birbTurn()
    {
      birbMove.SetBool("birbGo", true);
      yield return new WaitForSeconds(0.5f);
      birb.SetBool("myTurn", true);

    }
}
