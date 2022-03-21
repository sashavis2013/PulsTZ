using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    private Transform _playerTransform;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        GameOver();
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    private void Update()
    {
        if (gameObject.transform.position.x+10<_playerTransform.position.x)
        {
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
