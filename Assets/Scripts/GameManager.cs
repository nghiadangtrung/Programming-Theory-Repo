using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*[SerializeField]
    public struct enemyData
    {
        int name;
        int num;
        int dame;
    }
    enemyData test;
    List<enemyData> Enemy = new List<enemyData>();
    List<int> Enemys = new List<int>();
    Dictionary<int, string> h = new Dictionary<int, string>();*/
    // Start is called before the first frame update
    [SerializeField]
    List<enemy> Enemies = new List<enemy>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Enemies.Add(new enemy("ga", 5));
            Enemies.Add(new enemy("ha", 5));
            SaveData();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            LoadData();
        }
    }

    [System.Serializable]
    struct enemy
    {

        public string name;
        public int dame;


        public enemy(string v1, int v2)
        {
            this.name = v1;
            this.dame = v2;
        }
    } 
    class EnemyData
    {
        public List<enemy> Enemies = new List<enemy>();
    }
    void SaveData()
    {
        EnemyData Data = new EnemyData();
        Data.Enemies = Enemies;
        
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText("./savefile.json", json);

    }
    void LoadData()
    {
        string path = "./savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            EnemyData Data = JsonUtility.FromJson<EnemyData>(json);
            Enemies = Data.Enemies;
        }
    }
    
}
