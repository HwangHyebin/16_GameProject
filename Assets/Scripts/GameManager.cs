using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private CharacterBase[]     _array; //포인터를 담기 위한 배열
    private ControlCamera       _camera;
    private MapFactory          _map;
    private CharacterFactory    _factory;

	[HideInInspector] 
	public 	CharacterBase[]     _enemyArray = null;

    //나중에 xml 파싱을 통해 캐릭터의 수와 오브젝트의 수 등을 결정.
    private void Awake()
    {
        BaseInstance(3);

		//현재는 2마리로 정해져 있으나 나중엔 xml파싱을 통해 갯수결정; //enemy만을 담기 위한 배열
		_enemyArray = new CharacterBase[2]; 

        _map        = GameObject.FindObjectOfType<MapFactory>();
        _factory    = GameObject.FindObjectOfType<CharacterFactory>();
        _camera     = GameObject.FindObjectOfType<ControlCamera>();
    }
    private void Start()
    {
        _camera.init();
        _map.CreateMap();
        _map.CreateObstacle(10); //오브젝트를 몇개나 생성할 것인지?
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
        _factory.CreateCharacter("Player", ref _array[0]);

		for (int i = 0; i < _enemyArray.Length; ++i)
        {
			CharacterBase a = _factory.CreateCharacter ("Enemy", ref _array [i + 1]);
			Debug.Log (a);
			_enemyArray[i] = a;
        }

        for (int i = 0; i < _array.Length; ++i)
        {
            _array[i].init();
        }
    }
}
