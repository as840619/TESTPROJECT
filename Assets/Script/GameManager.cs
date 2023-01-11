using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        CreateEnemy();
        CreateRedFlower();
        CreateIron();
        CreateRock();
        SwitchTag();
        EndTag();
    }

    void Update()
    {
        UpdateUI();
    }

    [Header("玩家介面")]
    public Text _cell1Bar;
    public Text _cell2Bar;
    public Text _cell3Bar;
    public Text _cell4Bar;
    public Text _cell5Bar;
    public Text _cell6Bar;
    private static int cell1 = 11;
    private static int cell2 = 22;
    private static int cell3 = 22;
    private static int cell4 = 33;
    private static int cell5 = 44;
    private static int cell6 = 55;

    public static void AddCell1(int n)
    {
        cell1 += n;
        if(cell1 <= 0)
        {
            EditorApplication.isPlaying = false; 
        }
    }
    public static void AddCell2(int n)
    {
        cell2 += n;
    }
    public static void AddCell3(int n)
    {
        cell3 += n;
    }
    public static void AddCell6(int n)
    {
        cell6 += n;
    }
    public void UpdateUI()
    {
        _cell1Bar.text = cell1.ToString();
        _cell2Bar.text = cell2.ToString();
        _cell3Bar.text = cell3.ToString();
        _cell4Bar.text = cell4.ToString();
        _cell5Bar.text = cell5.ToString();
        _cell6Bar.text = cell6.ToString();
    }

    [Header("實例敵人")]
    [SerializeField] int _maxEnemyAmount = 250;
    [SerializeField] GameObject _enemy;

    public void CreateEnemy()
    {
        for (int n = 0; n < _maxEnemyAmount; n++)
        {
            Instantiate(_enemy, new Vector3(Random.Range(-50f, 50f), 3, Random.Range(-50f, 50f)), transform.rotation);
        }
        for (int n = 0; n < _maxEnemyAmount; n++)
        {
            Instantiate(_enemy, new Vector3(Random.Range(-125f, 125f), 3, Random.Range(375f, 625f)), transform.rotation);
        }
    }

    [Header("實例紅花")]
    [SerializeField] int _maxRedFlowerAmount = 50;
    [SerializeField] GameObject _redFlower;
    void CreateRedFlower()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "FirstScene" || number == 0)
        {
            for (int i = 0; i < Random.Range(0, _maxRedFlowerAmount); i++)
            {
                Instantiate(_redFlower, new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f)), transform.rotation);
            }
        }
    }

    [Header("實例鐵塊")]
    [SerializeField] int _maxIronAmount = 50;
    [SerializeField] GameObject _iron;
    public void CreateIron()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "FirstScene" || number == 0)
        {
            for (int i = 0; i < Random.Range(0, _maxIronAmount); i++)
            {
                Instantiate(_iron, new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f)), transform.rotation);
            }
        }
    }


    [Header("實例石頭")]
    [SerializeField] int _maxRockAmount = 50;
    [SerializeField] GameObject _rock;
    public void CreateRock()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "MainScene" || number == 1)
        {
            for (int i = 0; i < Random.Range(0, _maxRockAmount); i++)
            {
                Instantiate(_rock, new Vector3(Random.Range(-125f, 125f), 0, Random.Range(375f, 625f)), transform.rotation);
            }
        }
    }

    [Header("傳送門")]
    [SerializeField] GameObject _portal;

    public void SwitchTag()
    {
        Instantiate(_portal, new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f)), transform.rotation);
    }

    [Header("離開程式")]
    [SerializeField] GameObject _endObject;

    public void EndTag()
    {
        Instantiate(_endObject, new Vector3(Random.Range(-125f, 125f), 1, Random.Range(375f, 625f)), transform.rotation);
    }

}
