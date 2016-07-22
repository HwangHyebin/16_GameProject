using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private CharacterBase[]     _array; //포인터를 담기 위한 배열, player포함
    private ControlCamera       _camera;
    private MapFactory          _map;
    private CharacterFactory    _factory;

	[HideInInspector] 
	public 	CharacterBase[]     _enemyArray = null; //오직 enemy만 담는 배열 

    //나중에 xml 파싱을 통해 캐릭터의 수와 오브젝트의 수 등을 결정.
    private void Awake()
    {
        _map        = GameObject.FindObjectOfType<MapFactory>();
        _factory    = GameObject.FindObjectOfType<CharacterFactory>();
        _camera     = GameObject.FindObjectOfType<ControlCamera>();

        _camera.init();
        _map.CreateMap();
        _map.CreateObstacle(10); //오브젝트를 몇개나 생성할 것인지?
        CharacterBase_Instance(3);
        //현재는 2마리로 정해져 있으나 나중엔 xml파싱을 통해 갯수결정; //enemy만을 담기 위한 배열
        _enemyArray = new CharacterBase[2]; 
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
    private void CharacterBase_Instance(int _num)
    {
        _array = new CharacterBase[_num];
        for (int i = 0; i < _num; ++i)
        {
            _array[i] = GetComponent<CharacterBase>();
        }
    }
    private void CharacterInit()
    {
        CharacterBase player = _factory.CreateCharacter("Player", ref _array[0]);
        Set_Character_Status(ref player, 100.0f, 10.0f);
        for (int i = 0; i < _enemyArray.Length; ++i) // enemy 생성
        {
            CharacterBase enemy = _factory.CreateCharacter("Enemy", ref _array[i + 1]);
            Set_Character_Status(ref enemy, 100.0f, 3.0f);
            _enemyArray[i]      = enemy;
        }
        for (int i = 0; i < _array.Length; ++i)
        {
            Debug.Log("Create");
            _array[i].init();
        }
    }
    public void Set_Character_Status(ref CharacterBase _base, float _hp, float _demage)
    {
        _base.status.hp     = _hp;
        _base.status.demage = _demage;
    }
}
