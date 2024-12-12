using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBehaviour : MonoBehaviour // 버튼 작동 전용 Script 신설
{
  // 다시하기
  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1f;
  }

  // 승리 할시 다음 스테이지로 넘어감
  public void GameStart()
  {
    SceneManager.LoadScene(1);
    Time.timeScale = 1f;
  }

  public void Stage1()
  {
    SceneManager.LoadScene(2);
    Time.timeScale = 1f;
  }

  public void Stage2()
  {
    SceneManager.LoadScene(3);
    Time.timeScale = 1f;
  }

  public void Stage3()
  {
    SceneManager.LoadScene(4);
    Time.timeScale = 1f;
  }

  // 게임 종료 구현
  public void ExitGame()
  {
    Application.Quit();
  }
}

