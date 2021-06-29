using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelContent
{
    public string name;   
    public Material BG_Material;
    public Texture2D BG_TerrainTexture;
    public GameObject gun,brainObstacle;
    public float PlayerLife;
    public int EnemyCount, EnemyKill;
    public List<EnemyPrefab> levelEnemyList;
}
[System.Serializable]
public class EnemyPrefab
{
    public GameObject Enemyobj;    
}
public class LevelManager : MonoBehaviour
{
    public List<LevelContent> LevelController ;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

  
}
