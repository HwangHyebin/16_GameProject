using UnityEngine;
using System.Collections;

public class ControlPlayerHPBar : MonoBehaviour 
{
    private UISprite    img;
    private Vector3     m_StartScale;
    private Animator    anim;
    private Transform   target = null;

    private float r = 0;
    private float g = 212;
    private float b = 15;

    public float hp      = 100.0f;

    private void Start()
    {
        m_StartScale = transform.localScale;
        target = transform.parent.FindChild("mon01");
        img = GetComponent<UISprite>();
        img.color = new Color(r/255, g/255, b/255);
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
        if (hpScale.x <= 0.9f) //  && enemy가 어택상태일때 컬러를 바꿔줌.
        {
            StartCoroutine("Change_Color");
        }
    }
    IEnumerator Change_Color()
    {
        if (b > 0)
        {
            b -= 0.1f;
        }
        else
        {
            b = 0.0f;
            r += 0.2f;
            if (r >= 255.0f)
            {
                r = 255.0f;
                g -= 0.2f;
            }
        }
        img.color = new Color(r/255, g/255, b/255);

        yield return new WaitForSeconds(1.0f);
    }
    //IEnumerator Death()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    //Destroy(transform.parent.gameObject);
    //    //종료창 띄워줌
    //}
}
