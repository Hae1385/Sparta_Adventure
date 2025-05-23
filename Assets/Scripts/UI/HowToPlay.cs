using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlay;
    public Button startButton;
    public PlayerController playerController;

    private void Start()
    {
        howToPlay.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        playerController.canLook = false;

        if (startButton != null) 
            startButton.onClick.AddListener(OnClickStartButton);
    }
    
    public void OnClickStartButton()
    {
        Time.timeScale = 1f;
        playerController.ToggleCursor();
        Cursor.lockState = CursorLockMode.Locked;
        playerController.canLook= true;
        howToPlay.SetActive(false);
    }
}
