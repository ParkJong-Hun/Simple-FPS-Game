using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    PlayerMove player; //플레이어의 체력을 가져오기 위함
    public static GameManager gm;
    public GameObject gameLabel;
    Text gameText;
    private void Awake()
    {
        if (gm == null) gm = this;
    }
    public enum GameState
    {
        Ready, Run, Pause, GameOver
    }
    public GameState gState;
    public GameObject gameOption; // 옵션 화면 UI 오브젝트 변수
    // Start is called before the first frame update
    void Start()
    {
        //초기 게임 상태는 준비 상태로 설정한다.
        gState = GameState.Ready;
        //게임 상태 UI오브젝트에서 Text 컴포넌트를 가져온다.
        gameText = gameLabel.GetComponent<Text>();
        //상태 텍스트의 내용을 Ready...로 한다.
        gameText.text = "Ready...";
        //상태 텍스트의 색상을 주황색으로 한다.
        gameText.color = new Color32(255, 185, 0, 255);
        //게임 준비->게임 중 상태로 전환하기
        StartCoroutine(ReadyToStart());
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }
    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        Score.score = 0;
        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOptionWindow();
        }
        if (player.hp <= 0) // 플레이어가 죽었다면.
        {
            //플레이어 애니메이션을 멈춘다. 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0); 
            gameLabel.SetActive(true); // 상태 텍스트를 활성화 한다.
            gameText.text = "Game Over";// 상태 텍스트 내용을 Game Over로..
            gameText.color = new Color32(255, 0, 0, 255);
            //상태 텍스트의 자식 오브젝트의 트렌스폼 컨포넌트를 가져온다.
            Transform buttons = gameText.transform.GetChild(0);
            buttons.gameObject.SetActive(true);// 버튼 오브젝트를 활성화한다

        

            gState = GameState.GameOver;
        }
    }
    public void OpenOptionWindow()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOption.SetActive(true); // 옵션 창을 활성화 한다.
        Time.timeScale = 0f; // 게임 속도를 0배속으로 전환한다.
        gState = GameState.Pause; // 게임 상태를 일시정지 상태로 변경한다.
    }
    public void CloseOptionWindow()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameOption.SetActive(false);// 옵션 창을 비활성화 한다.
        Time.timeScale = 1f; //게임 속도를 1배속으로 전환한다. 
        gState = GameState.Run; // 게임 상태를 게임 중 상태로 변경한다. 
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.score = 0;
        Score.time = 0;
    }
    public void ResultGame()
    {
        Application.LoadLevel("Ending");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
