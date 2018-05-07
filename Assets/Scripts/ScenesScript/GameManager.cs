using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject tileChurch;
    [SerializeField] private GameObject tileBarril;
    [SerializeField] private GameObject tileDer;
    [SerializeField] private GameObject tileIzq;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Text hpLabel;
    [SerializeField] private Text pointsLabel;
    [SerializeField] private Text weaponClip;
    [SerializeField] private Text weaponName;
    [SerializeField] private Text finalPoints;
    [SerializeField] private Text finalGhost;
    [SerializeField] private Text finalTraps;
    [SerializeField] private GameObject finalCamera;
    [SerializeField] private GameObject finalScreen;
    [SerializeField] public static int gamePoints;
    private int[,] tileMap;
    private FirstPersonController player;
    public static int ghostKilled;
    public static int trapsDesactivated;
    private bool gameOver;
    private int contGhost;
    private int contTrap;
    private int contPoints;
    private GameObject terrain;
    // Use this for initialization
    void Start()
    {
        GameInitialize();
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
            player.gameObject.SetActive(false);
            finalScreen.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finalGhost.text = contGhost.ToString();
            finalTraps.text = contTrap.ToString();
            finalPoints.text = contPoints.ToString();
            if (contGhost < ghostKilled)
            {
                contGhost++;
            }
            if (contGhost == ghostKilled)
            {
                if (contTrap < trapsDesactivated)
                {
                    contTrap++;
                }
                if (contTrap == trapsDesactivated)
                {
                    if (contPoints < gamePoints)
                    {
                        contPoints += 10;
                    }
                }
            }
        }
        
    }

    private void SetTextUILabels()
    {
        hpLabel.text = "HP " + player.GetLife();
        pointsLabel.text = "POINTS " + gamePoints;
        if (player.GetCurrentWeapon() != null)
        {
            weaponName.text = player.GetCurrentWeapon().name;
            if (player.GetCurrentWeapon().name == "Flowerator")
            {
                weaponClip.text = player.GetCurrentWeapon().GetComponent<Flowerator>().GetMagazine() + " / " + player.GetCurrentWeapon().GetComponent<Flowerator>().GetAmmo();
            }
            else
            {
                weaponClip.text = player.GetCurrentWeapon().GetComponent<Matatrampas>().GetMagazine() + " / " + player.GetCurrentWeapon().GetComponent<Matatrampas>().GetAmmo();
            }
        }
    }

    private void CreateTerrain()
    {
        terrain = GameObject.Find("Terrain");
        Transform[] tiles = terrain.GetComponentsInChildren<Transform>();
        if (tiles.Length > 0)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].name != "Terrain")
                    Destroy(tiles[i].gameObject);
            }
        }
        tileMap = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                tileMap[i, j] = UnityEngine.Random.Range(0, 3);
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tileMap[i,j] == 2)
                {
                    if (j < 2)
                        tileMap[i, j + 1] = 3;
                    else
                        tileMap[i, j] = UnityEngine.Random.Range(0, 1);
                }
                if (tileMap[i,j] == 3)
                {
                    if (j > 0 && tileMap[i,j-1] != 3)
                        tileMap[i, j - 1] = 2;
                    else
                        tileMap[i, j] = UnityEngine.Random.Range(0, 1);
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 position = Vector3.zero;
                position.x = i * 200;
                position.z = j * 200;
                switch (tileMap[i,j])
                {
                    case 0:
                        {
                            Instantiate(tileChurch, position, transform.rotation, terrain.transform);
                            break;
                        }
                    case 1:
                        {
                            Instantiate(tileBarril, position, transform.rotation, terrain.transform);
                            break;
                        }
                    case 2:
                        {
                            Instantiate(tileDer, position, transform.rotation, terrain.transform);
                            break;
                        }
                    case 3:
                        {
                            Instantiate(tileIzq, position, transform.rotation, terrain.transform);
                            break;
                        }
                    default:
                        break;
                }
                
            }
        }
    }

    public void OnRestartButton()
    {
        Destroy(player.gameObject);
        GameInitialize();
    }

    private void GameInitialize()
    {
        CreateTerrain();
        player = Instantiate(playerPrefab, new Vector3(UnityEngine.Random.Range(100,500),40, UnityEngine.Random.Range(100, 500)), transform.rotation, transform.parent).GetComponent<FirstPersonController>();
        gameOver = false;
        ghostKilled = 0;
        trapsDesactivated = 0;
        finalScreen.gameObject.SetActive(false);
        contGhost = 0;
        contTrap = 0;
        contPoints = 0;
        player.gameObject.SetActive(true);
        player.SetLife(100);
        gamePoints = 0;
    }

    public FirstPersonController GetPlayer()
    {
        return player;
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
