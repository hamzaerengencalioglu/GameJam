using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ShopSceneScript : MonoBehaviour
{
    public int LoadSceneQueue;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            {
            SceneManager.LoadScene(LoadSceneQueue);

            }
    }
}
