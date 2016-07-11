using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour 
{
	public float        m_Hight         = 2.0f;
    public int          m_HP            =  100;

    private Vector3     m_StartScale;
    private Animator    anim;
    private Transform   target          = null;
   
	private void Start ()
    {
        m_StartScale        = transform.localScale;
        target              = transform.parent.FindChild("mon01");
        anim                = target.GetComponent<Animator>();
	}
	private void Update ()
    {
        transform.position  = target.position + (Vector3.up * m_Hight);
        transform.rotation  = Camera.main.transform.rotation;

        Vector3 hpScale     = m_StartScale;
        hpScale.x           = hpScale.x * ((float)m_HP * 0.01f);

        transform.localScale = hpScale;

        if(m_HP <= 0)
        {
            anim.SetInteger("animation", 2);
            StartCoroutine("Death");
        }
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.0f);
        //Destroy(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
    }
}
