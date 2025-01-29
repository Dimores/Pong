using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer;
    public string nameEnemy;

    public static SaveController _instance;

    private string _saveWinnerKey = "SavedWinner";

    // Propriedade est�tica para acessar a inst�ncia
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a inst�ncia na cena
                _instance = FindObjectOfType<SaveController>();

                // Se n�o encontrar, cria uma nova inst�ncia
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garante apenas uma inst�ncia do Singleton
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        }

        // Mant�m o singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(_saveWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(_saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
