using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraControl : MonoBehaviour
{

    public Transform TargetCharacter;

    public float CameraSpeed;
    public float CameraTurnSpeed;

    public GameObject playerObject;
    public GameObject playerSubObject;
    Rigidbody2D PlayerRigidBody;

    public bool faceRight ;

    public bool stopTurnFace = false ;
     void Start()
    {
       PlayerRigidBody = playerObject.GetComponent<Rigidbody2D>();

  


    } 
     
    void FixedUpdate()
    {

        if (!stopTurnFace)
        {
            
            stopTurnFace = playerSubObject.GetComponent<PlayerMovement>().isDead;
            faceRight = playerObject.GetComponent<ParentScript>().FaceRight;

        }

        if (playerObject != null)
        {

            if (  !faceRight)
            {

                if (PlayerRigidBody.velocity.x < 0)
                {
                    transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x -6, TargetCharacter.position.y, transform.position.z), CameraSpeed);
                }
                else if (PlayerRigidBody.velocity.x == 0)
                {
                    transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x -3, TargetCharacter.position.y, transform.position.z), CameraTurnSpeed);
                }
                
            }
            
            else if (faceRight) 
            {

                if (PlayerRigidBody.velocity.x > 0)
                {
                    transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x +6, TargetCharacter.position.y, transform.position.z), CameraSpeed);
                }
                else if (PlayerRigidBody.velocity.x == 0)
                {
                    transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x +3, TargetCharacter.position.y, transform.position.z), CameraTurnSpeed);
                }

            }
            //else
            //{
            //    transform.position = Vector3.Slerp(transform.position, new Vector3(TargetCharacter.position.x, TargetCharacter.position.y, transform.position.z), CameraSpeed);
            //}


        }
        else
        {


        }
    
    
    }
}
