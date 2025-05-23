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
        howToPlay.SetActive(true);  //조작방법 활성화
        Time.timeScale = 0f;  //시간멈추기

        Cursor.lockState = CursorLockMode.None; //커서 활성화
        playerController.canLook = false;  //화면이 돌아가지 않도록 플레이어 컨트롤러에 접근해 canLook을 false로

        if (startButton != null) 
            startButton.onClick.AddListener(OnClickStartButton);
    }
    
    public void OnClickStartButton()
    {
        Time.timeScale = 1f;                //버튼을 누르면 다시 시간흐르게
        playerController.ToggleCursor();    //플레이어에 접근해 커서가 활성화 되게
        playerController.canLook= true;     //다시 true로
        howToPlay.SetActive(false);         //창닫기
    }
}
