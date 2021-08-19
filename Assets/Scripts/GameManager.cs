using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image hpBar;
    public static float hp = 1f;
    public GameObject enemyObject;
    bool isInstant = true;

    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstant)
        {
            StartCoroutine("InstantEnemy");
        }
        hpBar.fillAmount = hp;

        if (hp <= 0)
            GameOver();
    }
    
    public static void PlayerHit()
    {
        hp -= 0.1f;
    }

    IEnumerator InstantEnemy()
    {
        isInstant = false;
        Instantiate(enemyObject, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), Quaternion.identity);
        yield return new WaitForSeconds(2);
        isInstant = true;
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        hp = 1f;

        gameoverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }

    public void Re()
    {
        hp = 1f;

        gameoverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
