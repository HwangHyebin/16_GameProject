using UnityEngine;
using System.Collections;

public class ControlPlayerHPBar : MonoBehaviour 
{
    private Vector3     m_StartScale;
    private Animator    anim;
    private Transform   target = null;

    public float hp      = 100.0f;

    private void Start()
    {
        m_StartScale = transform.localScale;
        target = transform.parent.FindChild("mon01");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 hpScale = m_StartScale;
        hpScale.x = hpScale.x * ((float)hp * 0.01f);

        transform.localScale = hpScale;

        if (hp <= 0)
        {
            anim.SetInteger("animation", 2);
            //StartCoroutine("Death");
        }
    }
    //IEnumerator Death()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    //Destroy(transform.parent.gameObject);
    //    //종료창 띄워줌
    //}
}
