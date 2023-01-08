using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        createplane();
        createenemy();
        createredflower();
        createiron();
        createrock();
        switchtag();
        endtag();
    }
    private void Update()
    {
        updateUI();
    }

    [HeaderAttribute("玩家介面")]
    public Text EnergyBar;
    public Text Cell1;
    public Text Cell2;
    public Text Cell3;
    public Text Cell6;
    private static int Energy = 0;
    private static int cell1 = 0;
    private static int cell2 = 0;
    private static int cell3 = 0;
    private static int cell6 = 0;

    public static void addenergy(int n)
    {
        Energy += n;
    }
    public static void addcell1(int n)
    {
        cell1 += n;
    }
    public static void addcell2(int n)
    {
        cell2 += n;
    }
    public static void addcell3(int n)
    {
        cell3 += n;
    }
    public static void addcell6(int n)
    {
        cell6 += n;
    }
    private void updateUI()
    {
        EnergyBar.text = "Energy:" + Energy.ToString();
        Cell1.text = "Energy:" + cell1.ToString();
        Cell2.text = "Energy:" + cell2.ToString();
        Cell3.text = "Energy:" + cell3.ToString();
        Cell6.text = "Energy:" + cell6.ToString();
    }

    [HeaderAttribute("實例地面")]
    public int width = 10;
    public int height = 1;
    public int length = 10;
    public GameObject Plane;

    public void createplane()
    {
        for (int x = 0; x < width + 1; x++)
        {
            for (int z = 0; z < length + 1; z++)
            {
                GameObject floor = Instantiate(Plane, new Vector3((-(width / 2) + x) * 10, height, (-(length / 2) + z) * 10), transform.rotation);
            }
        }
    }

    [HeaderAttribute("實例敵人")]
    public int MaxEnemyAmount = 200;
    public GameObject Enemy;

    public void createenemy()
    {
        for (int n = 0; n < MaxEnemyAmount; n++)
        {
            GameObject enemy1 = Instantiate(Enemy, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
        }
    }

    [HeaderAttribute("實例紅花")]
    public int MaxRedflowerAmount = 50;
    public GameObject RedFlower;
    public void createredflower()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "FirstScene" || number == 0)
        {
            for (int i = 0; i < Random.Range(0, 20); i++)
            {
                GameObject redflower = Instantiate(RedFlower, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
            }
        }
    }

    [HeaderAttribute("實例鐵塊")]
    public int MaxIronAmount = 50;
    public GameObject Iron;
    public void createiron()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "FirstScene" || number == 0)
        {
            for (int i = 0; i < Random.Range(0, 20); i++)
            {
                GameObject iron = Instantiate(Iron, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
            }
        }
    }


    [HeaderAttribute("實例石頭")]
    public int MaxRockAmount = 50;
    public GameObject Rock;
    public void createrock()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "MainScene" || number == 1)
        {
            for (int i = 0; i< Random.Range(0, 20);i++)
            {
                GameObject rock = Instantiate(Rock, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
            }
        }
    }

    [HeaderAttribute("傳送門")]
    public GameObject Portal;

    public void switchtag()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "FirstScene" || number == 0)
        {
            GameObject switch1 = Instantiate(Portal, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
        }
    }

    [HeaderAttribute("離開程式")]
    public GameObject EndObject;

    public void endtag()
    {
        int number = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;
        if (name == "MainScene" || number == 1)
        {
            GameObject end1 = Instantiate(EndObject, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), transform.rotation);
        }
    }

    public void sceneswitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
