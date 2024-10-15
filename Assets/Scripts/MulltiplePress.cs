using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplePress : MonoBehaviour
{
    public static int totalPresses = 0;
    public GameObject PlayerWonPanel;
    public int numbPresses;

    void Start()
    {
        totalPresses = 0;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 2)
        {
            numbPresses = 3;
        }
        if (sceneIndex == 3)
        {
            numbPresses = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPresses >= numbPresses)
        {
            PlayerWonPanel.SetActive(true);
        }
    }
}
