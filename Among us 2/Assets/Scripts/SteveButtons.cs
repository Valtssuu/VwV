using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SteveButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public int readyCount;

    void Start()
    {
        readyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && SceneManager.GetActiveScene().name == "Lobby")
        {
            readyCount += 1;
        }
    }
}
