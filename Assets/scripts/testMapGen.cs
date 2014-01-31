using System;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using System.Collections;
using Random = System.Random;

public class testMapGen : MonoBehaviour {

    public GameObject fogSprite;
	public bool plaseFog = true;
	public GameObject[] SpriteObjs; // 0 is floor, 1 is wall, 2 is wall with torch, 3 is player spawner, 4 is chest
	public Vector3 ZeroPoint;
	public static int mapsize = 40;
    //public static int mapsizew = mapsize;

    public String[] map = new string[mapsize];

    /*private string[] map =  {
		"#*####*#", 
		"#@-----#", 
		"#--#-###",
		"#*##---#",
		"#------#",
		"##*-*###",
		"#-----C#",
		"########"};
	*/


	void Start () {
        randomGenMap();
        genWithMap(ZeroPoint);
	}



    void randomGenMap()
    {
        bool playerSpawnerIsSpawned = false;
        Random rnd = new Random();
        for (int i = 0; i < mapsize; i++)
        {
          
            for (int j = 0; j < mapsize; j++)
            {
                int rndnum = rnd.Next(-1, 4);
                switch (rndnum)
                {
                    case -1:
                    case 0:
                        map[i] += "-";
                        break;
                    case 1:
                        map[i] += "#";
                        break;
                    case 2:
                        map[i] += "*";
                        break;
                    case 3:
                        if (!playerSpawnerIsSpawned && i > (mapsize / rnd.Next(1,3)) && j > (mapsize / rnd.Next(1,3)))
                        {
                            map[i] += "@";
                            playerSpawnerIsSpawned = true;
                        }
                        else
                        {
                            map[i] += "-";
                        }
                        break;
                    case 4:
                        map[i] += "C";
                        break;
                    
                    
                }
            }
        }


    }


	void genWithMap(Vector3 zeroPoint)
	{
		for (int i = 0; i <	mapsize; i++) {
			char[] line = map[i].ToString().ToCharArray();
            for (int j = 0; j < line.GetLength(0); j++) {
                char block = line[j];
                Vector3 pos = new Vector3(ZeroPoint.x + j, ZeroPoint.y - i);
                switch (block)
                {
                    case '#': GameObject.Instantiate(SpriteObjs[1], pos, new Quaternion(0, 0, 0, 0));
					if(plaseFog)GameObject.Instantiate(fogSprite, new Vector3 (pos.x,pos.y,-3), new Quaternion(0, 0, 0, 0));
                        break;
                    case '-': GameObject.Instantiate(SpriteObjs[0], pos, new Quaternion(0, 0, 0, 0));
					if(plaseFog)GameObject.Instantiate(fogSprite, new Vector3 (pos.x,pos.y,-3), new Quaternion(0, 0, 0, 0));
                        break;
                    case '*': GameObject.Instantiate(SpriteObjs[2], pos, new Quaternion(0, 0, 0, 0));
					if(plaseFog)GameObject.Instantiate(fogSprite, new Vector3 (pos.x,pos.y,-3), new Quaternion(0, 0, 0, 0));
                        break;
					case '@': GameObject.Instantiate(SpriteObjs[3], pos, new Quaternion(0, 0, 0, 0));
					if(plaseFog)GameObject.Instantiate(fogSprite, new Vector3 (pos.x,pos.y,-3), new Quaternion(0, 0, 0, 0));
					    break;
                    case 'C': GameObject.Instantiate(SpriteObjs[4], new Vector3(ZeroPoint.x + j, ZeroPoint.y - i, -1f), new Quaternion(0, 0, 0, 0));
					if(plaseFog)GameObject.Instantiate(fogSprite, new Vector3 (pos.x,pos.y,-3), new Quaternion(0, 0, 0, 0));
                              GameObject.Instantiate(SpriteObjs[0], pos, new Quaternion(0, 0, 0, 0));
                        break;

                }   
                
                           

			}
		}
	}







}
