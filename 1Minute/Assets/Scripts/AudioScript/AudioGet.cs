using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGet : MonoBehaviour
{
    public GameObject playerAudioOBJECT;
    
    
    AudioSource sourceAudio;

    public AudioClip shotAudio;
    
    public AudioClip jumpAudio;
    public bool isGroundAudio = true;
    void Start()
    {
     sourceAudio = GetComponent<AudioSource>();
        


    }


    void Update()
    {
      isGroundAudio =  playerAudioOBJECT.GetComponent<PlayerMovement>().isGrounded;
        
        playJump();
        playShot();
   
            
            
    }


    void playShot()
    {
        if ((Input.GetKeyDown(KeyCode.J)) || Input.GetMouseButtonDown(0))
        {
            sourceAudio.PlayOneShot(shotAudio);

        }

    }

     void playJump()
    {
        if (isGroundAudio &&(Input.GetKeyDown(KeyCode.Space)) )
        {
            sourceAudio.PlayOneShot(jumpAudio);

        }

    }





}
