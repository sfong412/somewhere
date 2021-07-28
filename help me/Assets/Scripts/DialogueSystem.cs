using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{

    public RhythmGameMapper rhythm;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI instructionText;
    public string[] dialogue;

    public string[] instructions;
    public float speed;

    public int textIndex;

    public int instructionIndex;

    public int[] targetIndex;

    public int targetIndexNumber;

    public bool showtime;

    public GameObject instructionText2;

    public GameObject dialogueText2;

    public bool pressed;

    public bool watch;

    public bool back;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void Awake()
    {
        targetIndexNumber = 0;
        showtime = false;
        pressed = false;
        watch = false;
        back = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!showtime)
        {
             if (Input.GetKeyDown(KeyCode.Return))
        {
            if (dialogueText.text == dialogue[textIndex])
            {
                NextLine();
                pressed = true;
                rhythm.Enter.SetBool("change", false);
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogue[textIndex];
            }
        }
        rhythm.Pause2();
        }
       
       if (back)
       {
           if (Input.GetKeyDown(KeyCode.Return))
           {
               showtime = false;
               back = false;
               NextLine();
                pressed = true;
                rhythm.Enter.SetBool("change", false);
                dialogueText2.transform.localScale = new Vector3(1, 1, 1);
                instructionText2.transform.localScale = new Vector3(0, 0 ,0);
                GameObject[] birds = GameObject.FindGameObjectsWithTag("Cardinals");
                foreach(GameObject bird in birds)
                GameObject.Destroy(bird);
                rhythm.mappingCode.Brazil();
           }
       }

       if (showtime)
       {
           rhythm.tutorial = true;
       }
       else
       {
           rhythm.tutorial = false;
       }

       
    }

    void StartDialogue()
    {
        textIndex = 0;
        StartCoroutine(TypeLine());
        StartCoroutine(hey());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[textIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(speed);
        }
    }

    void NextLine()
    {
        if (!showtime)
        {
             StartCoroutine(sus());
             if (textIndex <= targetIndex[targetIndexNumber])
        {
            textIndex++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
            rhythm.Enter.SetBool("change", false);
        }
        if (textIndex >= targetIndex[targetIndexNumber])
        {
            targetIndexNumber++;
            dialogueText2.transform.localScale = new Vector3(0, 0, 0);
            rhythm.Resume22();
            instructionText.text = instructions[instructionIndex];
            instructionText2.transform.localScale = new Vector3(1, 1 ,1);
            instructionIndex++;
            StartCoroutine(jumpOffABridge());
            watch = true;
            showtime = true;
            rhythm.paused = false;
        }
        }
       

        
    }

    IEnumerator jumpOffABridge()
    {
        yield return new WaitForSecondsRealtime(10f);
        rhythm.Enter.SetBool("change", true);
        back = true;
        
        
    }

    IEnumerator hey()
    {
        if (!watch)
        {
        yield return new WaitForSecondsRealtime(0.1f);
        pressed = false;
        yield return new WaitForSecondsRealtime(5f);
        if (pressed == false)
        {
            rhythm.Enter.SetBool("change", true);
        }
        }
      
    }

    IEnumerator sus()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        StartCoroutine(hey());
    }

   
}
