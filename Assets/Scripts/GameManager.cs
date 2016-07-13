using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private CharacterBase[]     _array;
    private ControlCamera       _camera;
    private MapFactory          _map;
    private CharacterFactory    _factory;
    //enemy를 저장하는 리스트를 만듦.
    //매니저 싱글톤

    //나중에 xml 파싱을 통해 캐릭터의 수와 오브젝트의 수 등을 결정.
    private void Awake()
    {
        BaseInstance(3);
        _map        = GameObject.FindObjectOfType<MapFactory>();
        _factory    = GameObject.FindObjectOfType<CharacterFactory>();
        _camera     = GameObject.FindObjectOfType<ControlCamera>();
    }
    private void Start()
    {
        _camera.init();
        _map.CreateMap();
        _map.CreateObstacle(10);
        CharacterInit();
       
    }
    private void Update()
    {
        _camera.update(_array[0]);
        for (int i = 0; i < _array.Length; ++i)
        {
            _array[i].update();
        }
    }
    private void BaseInstance(int _num)
    {
        _array = new CharacterBase[_num];
        for (int i = 0; i < _num; ++i)
        {
            _array[i] = GetComponent<CharacterBase>();
        }
    }
    private void MapInit()
    {
        //_map.CreateMapPlane();
    }
    private void CharacterInit()
    {
        //for문.
        _factory.CreateCharacter("Player", ref _array[0]);
        _factory.CreateCharacter("Enemy", ref _array[1]);
        _factory.CreateCharacter("Enemy", ref _array[2]);

        for (int i = 0; i < _array.Length; ++i)
        {
            _array[i].init();
        }
    }
   

}
