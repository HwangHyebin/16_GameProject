using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager
{
    public CharacterBase[]      _array;        //포인터를 담기 위한 배열, player포함
    public ControlCamera       _camera;
    public MapFactory          _map;
    public CharacterFactory    _factory;

	[HideInInspector]
    public Actor[] _enemyArray; //오직 enemy만 담는 배열 

    private static ObjectManager instance;
    public static ObjectManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ObjectManager();
            return instance;
        }
    }
    public void Enter()
    {
        _map        = GameObject.FindObjectOfType<MapFactory>();
        _factory    = GameObject.FindObjectOfType<CharacterFactory>();
        _camera     = GameObject.FindObjectOfType<ControlCamera>();
        Object_Init();
    }
    public void Execute()
    {
        _camera.update(_array[0]);
        for (int i = 0; i < _array.Length; ++i)
        {
            _array[i].GetComponentInChildren<CharacterBase>().update();
        }
    }
    private void Object_Init()
    {
        _camera.init();
        _map.CreateMap();
        _map.CreateObstacle(10);                                //오브젝트를 몇개나 생성할 것인지?
        CharacterBase_Instance(3);
        _enemyArray = new CharacterBase[(_array.Length - 1)];   //나중엔 xml파싱을 통해 갯수결정; enemy만을 담기 위한 배열
        CharacterInit();
    }
    private void CharacterBase_Instance(int _num)
    {
        _array = new CharacterBase[_num];
    }
    private void CharacterInit()
    {
        Actor player = new CharacterBase();
        player = _factory.CreateCharacter("Player", ref _array[0]);
        AttackManager.Object_list.Add(player);
        //AttackManager<CharacterBase>.Object_list.Add(player);
        for (int i = 0; i < _enemyArray.Length; ++i)
        {
            Actor enemy = new CharacterBase();
            enemy = _factory.CreateCharacter("Enemy", ref _array[i + 1]);
            _enemyArray[i]      = enemy;
            //AttackManager<CharacterBase>.Object_list.Add(player);
        }
        for (int i = 0; i < _array.Length; ++i)
        {
            _array[i].GetComponentInChildren<CharacterBase>().init();
        }
    }

    public Actor Get_EnemyArray
    {
        get {return _enemyArray[_enemyArray.Length];}
    }
}
