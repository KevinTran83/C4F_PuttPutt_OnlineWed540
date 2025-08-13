using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene
        (
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }
}
