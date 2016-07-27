using UnityEngine;
using System.Collections;

public class ControlCamera : MonoBehaviour 
{
    private Vector3     camera_vec;
    public void init()
    {
        camera_vec = this.transform.position;
    }
    public void update(CharacterBase _base)
    {
        camera_vec = new Vector3(_base.transform.position.x, this.transform.position.y, _base.transform.position.z - 4);
        this.transform.position = camera_vec;
    }
}
