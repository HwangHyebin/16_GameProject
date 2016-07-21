using UnityEngine;
using System.Collections;

public class MapFactory : MonoBehaviour 
{
	public  MapObjects[]    mapObjects;
	public  MapObjects[]    planeObjects;

    private Vector3         rand_pos;
    private Vector3         start_position = new Vector3(-20.0f, 0.0f, 20.0f);
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
        for (int i = 0; i < 40; ++i)
        {
            for (int j = 0; j < 40; ++j)
            {
                //확률에 맞춰 오브젝트를 뽑을 수 있는지?
				//rand = random.range(0,100); 해서 
				// rand의 값을 가지고 조건문을 달면 될듯.
				// if (rand < 40) //40%의 확률. 
				//{}
				//이걸 클래스로 만들어서 xml 파싱한뒤 적용해서 함수 사용해도 괜찮을듯.?
				GameObject _map = Instantiate(planeObjects[0].MapObecjet[Random.Range(0, planeObjects.Length)], new Vector3(start_position.x+j, -0.45f, start_position.z-i), Quaternion.identity) as GameObject;
                _map.transform.parent = this.gameObject.transform;
            }
        }
    }
    public void CreateObstacle(int _num)
    {
        for (int i = 0; i < _num; ++i)
        {
			//0번은 사막컨셉.
			GameObject _obstacle = Instantiate(mapObjects[0].MapObecjet[Random.Range(0, mapObjects[0].MapObecjet.Length)], 
                                               new Vector3(Random.Range(start_position.x, start_position.z - 1), -0.45f, Random.Range(start_position.x, start_position.z - 1)), 
                                               Quaternion.identity) as GameObject;
            _obstacle.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
            _obstacle.transform.parent = this.gameObject.transform;
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
