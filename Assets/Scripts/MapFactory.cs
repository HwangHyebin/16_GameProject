using UnityEngine;
using System.Collections;

public class MapFactory : MonoBehaviour 
{
    //더 좋은 방법으로 변경하고싶다!
    //배열관리 더 좋은 방법은 없는지?
    public  GameObject[]    mapObjects; //크리스탈
    //public  GameObject[]    mapObjects; //사막
    //public  GameObject[]    mapObjects; //정글

    public  GameObject[]    planeObjects; //크리스탈
    //public  GameObject[]    planeObjects; //사막
    //public  GameObject[]    planeObjects; //정글

    private Vector3         rand_pos;
    private Vector3         start_position = new Vector3(-12.0f, 0.0f, 12.0f);
    public enum MAP_PLANE
    {
        iced = 0,
        fire,
        desirt
    };
    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CreateMap()
    {
        for (int i = 0; i < 24; ++i)
        {
            for (int j = 0; j < 24; ++j)
            {
                //확률에 맞춰 오브젝트를 뽑을 수 있는지?
                GameObject _map = Instantiate(planeObjects[Random.Range(0, planeObjects.Length)], new Vector3(start_position.x+j, -0.45f, start_position.z-i), Quaternion.identity) as GameObject;
            }
        }
    }
    public void CreateObstacle(int _num)
    {
        for (int i = 0; i < _num; ++i)
        {
            GameObject _obstacle = Instantiate(mapObjects[Random.Range(0, mapObjects.Length)], 
                                               new Vector3(Random.Range(start_position.x, start_position.z - 1), -0.45f, Random.Range(start_position.x, start_position.z - 1)), 
                                               Quaternion.identity) as GameObject;
            _obstacle.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        }
    }

    //public void CreateMapPlane(MAP_PLANE _mapType)
    //{
    //    rand_pos = new Vector3(Random.Range(-23.0f, 24.0f), 0, Random.Range(-24.0f, 24.0f));
    //    switch (_mapType) // 맵에 따라 plane 오브젝트 변경 
    //    {
    //        case MAP_PLANE.iced :
    //            GameObject player = Instantiate(mapObjects[0], new Vector3(0.0f, 0.0f,0.0f), Quaternion.identity) as GameObject;
    //            break;
    //        case MAP_PLANE.fire:
    //            GameObject enemy = Instantiate(mapObjects[1], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
    //            break;
    //        case MAP_PLANE.desirt:
    //            break;
    //        //case 3:
    //        //    break;
    //        //case 4:
    //        //    break;
    //    }
    //}
}
