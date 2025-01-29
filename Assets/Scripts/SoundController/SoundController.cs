using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController _instance;

    public static SoundController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a inst�ncia na cena
                _instance = FindObjectOfType<SoundController>();

                // Se n�o encontrar, cria uma nova inst�ncia
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SoundController).Name);
                    _instance = singletonObject.AddComponent<SoundController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garante apenas uma inst�ncia do Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Mant�m o singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(AudioSource audioSource, float minPitch = 0.8f, float maxPitch = 1.1f)
    {
        // Sorteia um pitch entre os valores m�nimos e m�ximos
        float randomPitch = Random.Range(minPitch, maxPitch);
        audioSource.pitch = randomPitch;

        audioSource.Play();
    }
}
