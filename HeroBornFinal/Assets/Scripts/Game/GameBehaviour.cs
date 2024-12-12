using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameBehaviour : MonoBehaviour
{
    // Hp와 적 숫자를 인스펙터에서 조정 가능하게 함
    public int maxEnemy = 4;
    public int startHp = 3;

    public TMP_Text healthText;
    public TMP_Text enemyText;
    public TMP_Text progressText;

    void Awake()
    {
        // 인스펙터에서 조정
        _enemysKilled = maxEnemy;
        _playerHp = startHp;

        enemyText.text += _enemysKilled;
        healthText.text += _playerHp;
    }

    public Button winButton;
    public Button lossButton;

    public void UpdateScene(string updatedText)
    {
        progressText.text = "updated Text";
        Time.timeScale = 0f;
    }

    // 적을 다 죽이는것으로 게임 목표 변경
    private int _enemysKilled = 0;
    public int Enemys
    {
        get { return _enemysKilled; }
        set
        {
            _enemysKilled = value;
            enemyText.text = "Enemys : " + Enemys;

            if (_enemysKilled == 0)
            {
                UpdateScene("You've kill all enemys");
                winButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                progressText.text = "Enemy kill only " + _enemysKilled + " more to go";
            }
        }
    }
    private int _playerHp = 0;
    public int HP
    {
        get { return _playerHp; }
        set
        {
            _playerHp = value;
            healthText.text = "Health : " + HP;

            if (_playerHp <= 0)
            {
                UpdateScene("You want anther life with that?");
                lossButton.gameObject.SetActive(true);
            }
            else
            {
                progressText.text = "You Changed your Hp.";
            }
            Debug.LogFormat("Items : {0}", _playerHp);
        }
    }

}
