using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    [SerializeField] private int nextScene;

    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == 2)
        {
            nextScene = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            StartCoroutine(MoveToNextScene());
        }
    }

    private IEnumerator MoveToNextScene()
    {
        if (nextScene.Equals(""))
        {
            Debug.LogWarning("bruh where is the scene");
        }
        else
        {
            yield return FadeOut();
            SceneManager.LoadScene((int)nextScene);
        }
        
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds((float)0);
    }
}
