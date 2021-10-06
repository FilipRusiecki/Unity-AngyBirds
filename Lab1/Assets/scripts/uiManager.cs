using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{



    public void ButtonClick()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
