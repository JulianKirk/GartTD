using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class LevelLoader : MonoBehaviour
{
    public string mapName;
    public int currentLevel = 0;
    private Level[] Rounds;

    #region TEMPORARY
    public GameObject Soldier;
    public GameObject Scout;
    public GameObject Golem;
    public GameObject Eagle;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Rounds = GenerateLevels(mapName);
        CreatePool(Rounds);

        StartLevel(1);
    }

    Level[] GenerateLevels(string map) 
    {
        string path = Application.persistentDataPath + "/Maps" + "/" + map + "/Level";
        return JsonConvert.DeserializeObject<Level[]>(File.ReadAllText(path));
    }

    void CreatePool(Level[] levels) 
    {
        for (int i = 0; i < levels.Length;  i++) 
        {
            //Instantiates enemy containers for each round
            GameObject roundHolder = new GameObject("Round" + i.ToString(), typeof(RoundHolder));
            roundHolder.transform.parent = gameObject.transform;

            //For each enemy type instantiate a GameObject. Probably refer to this in the future using addressables or something.
            for (int n = 0; n < levels[i].Soldiers; n++) 
            {
                Instantiate(Soldier, roundHolder.transform);
            }

            for (int n = 0; n < levels[i].Scouts; n++) 
            {
                Instantiate(Scout, roundHolder.transform);
            }

            for (int n = 0; n < levels[i].Golems; n++) 
            {
                Instantiate(Golem, roundHolder.transform);
            }

            for (int n = 0; n < levels[i].Eagles; n++) 
            {
                Instantiate(Eagle, roundHolder.transform);
            }

            roundHolder.SetActive(false);
        }
    }

    void StartNextLevel() 
    {
        StartLevel(currentLevel + 1);
        currentLevel += 1;
    }

    void StartLevel(int level)
    {
        //Include a spawn delay between each enemy. Maybe later introduce spawn clusters that spawn at once
        //IMPLEMENT THIS

        gameObject.transform.GetChild(Mathf.Clamp(currentLevel - 1, 0, Rounds.Length - 1)).gameObject.SetActive(false); //Set inactive instead of destroy in case it is level 1
        gameObject.transform.GetChild(level - 1).gameObject.SetActive(true);

        currentLevel = level;
    }
}
