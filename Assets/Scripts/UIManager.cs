using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public InputField bestPlayerName;
   public void Restart() 
 {
        GameManager.gm.CheckScoreResult();


    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        GameManager.gm.SetActiveUI(false);
    
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ConfirmSaving()
    {
        // ���� ���� ���� 3���ڶ�� ...

        if (bestPlayerName.text.Length >= 2)
        {
            // �̸��� �����Ѵ�.
            PlayerPrefs.SetString("BestName", bestPlayerName.text);

        }

    }    
}
