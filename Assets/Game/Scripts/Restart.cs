using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] KeyCode restartButton = KeyCode.R;

    void Update()
    {
        if(Input.GetKey(restartButton))
            SceneManager.LoadScene("MyFirstGame");
    }
}
