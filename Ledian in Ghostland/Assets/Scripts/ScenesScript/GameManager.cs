using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject tile;
    [SerializeField] private FirstPersonController player;
    [SerializeField] private Text hpLabel;
    [SerializeField] private Text pointsLabel;
    [SerializeField] private bool gameOver;
    [SerializeField] private static int gamePoints;
    // Use this for initialization
    void Start()
    {
        CreateTerrain();
        gameOver = false;
        gamePoints = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetLife() <= 0)
        {
            gameOver = true;
        }
        OnGameOver();
        SetTextUILabels();
	}

    private void OnGameOver()
    {
        if (gameOver)
        {
            SceneManager.LoadScene("FinalScreen");
        }
        
    }

    private void SetTextUILabels()
    {
        hpLabel.text = "HP " + player.GetLife();
        pointsLabel.text = "POINTS " + gamePoints;
    }

    private void CreateTerrain()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 position = Vector3.zero;
                position.x = i * 200;
                position.z = j * 200;
                Instantiate(tile, position, transform.rotation);
            }
        }
    }

    public FirstPersonController GetPlayer()
    {
        return player;
    }

    public static void SetPoints(int value)
    {
        gamePoints = value;
    }

    public static int GetPoints()
    {
        return gamePoints;
    }
}
