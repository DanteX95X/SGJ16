using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Game;
using System.IO;

namespace Assets.Scripts.States
{
    class LoadLevel : State
    {
        int mapWidth;
        int mapHeight;

        [SerializeField]
        GameObject field = null;

        [SerializeField]
        GameObject player = null;

        [SerializeField]
        GameObject enemy = null;

        [SerializeField]
        string levelPath = "Levels\\0";

        public override void Init()
        {
            GameObject grid = new GameObject("grid");

            using (StreamReader reader = new StreamReader(levelPath + ".grid"))
            {
                string line = reader.ReadLine();
                string[] words = line.Split();
                mapWidth = Int32.Parse(words[0]);
                mapHeight = Int32.Parse(words[1]);

                Grid.height = mapHeight;
                Grid.width = mapWidth;

                for (int i = 0; i < mapHeight; ++i)
                {
                    line = reader.ReadLine();
                    words = line.Split();

                    List<GameObject> fieldLine = new List<GameObject>();

                    for (int j = 0; j < mapWidth; ++j)
                    {
                        GameObject newField = null;

                        if (words[j] == "C")
                            newField = Instantiate(field, new Vector3(j, i, 0), Quaternion.identity) as GameObject;

                        newField.transform.parent = grid.transform;
                        fieldLine.Add(newField);
                    }

                    Grid.fields.Add(fieldLine);
                }
            }

            using (StreamReader reader = new StreamReader(levelPath + ".player"))
            {
                string line = reader.ReadLine();
                string[] words = line.Split();
                int x = Int32.Parse(words[0]);
                int y = Int32.Parse(words[1]);
                if (x < 0 || x >= mapWidth || y < 0 || y >= mapHeight)
                    Debug.Log("Congrats! You're an idiot. Place player on a grid.");

                GameObject newPlayer = Instantiate(player, new Vector3(x, y, -0.5f), Quaternion.identity) as GameObject;
                newPlayer.AddComponent<Player>();
                newPlayer.AddComponent<Movable>();
            }

            using (StreamReader reader = new StreamReader(levelPath + ".enemies"))
            {
                string line = reader.ReadLine();
                int howManyEnemies = Int32.Parse(line);

                for (int i = 0; i < howManyEnemies; ++i)
                {
                    line = reader.ReadLine();
                    string[] words = line.Split();
                    int x = Int32.Parse(words[0]);
                    int y = Int32.Parse(words[1]);
                    if (x < 0 || x >= mapWidth || y < 0 || y >= mapHeight)
                        Debug.Log("Congrats! You're an idiot. Place enemies on a grid.");

                    GameObject newEnemy = Instantiate(enemy, new Vector3(x, y, -0.5f), Quaternion.identity) as GameObject;
                    newEnemy.AddComponent<Enemy>();
                    newEnemy.AddComponent<Movable>();

                    x = Int32.Parse(words[2]);
                    y = Int32.Parse(words[3]);
                    if (x < 0 || x >= mapWidth || y < 0 || y >= mapHeight)
                        Debug.Log("Congrats! You're an idiot. Place enemy's target on a grid.");
                    newEnemy.GetComponent<Enemy>().TargetPosition = new Vector3(x, y, -0.5f);
                }
            }

            ChangeState<DummyState>();
        }

        public override void UpdateLoop()
        {
            
        }
    }
}
