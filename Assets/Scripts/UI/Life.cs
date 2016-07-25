using UnityEngine;
using System.Collections;

public class Life : HPBarBase 
{
	public  float           m_Hight         = 2.0f;
    public  GameObject      UI_back;
    public  GameObject      UI_HP_back;

    private Animator        anim;
    private SpriteRenderer  img;
   
	private void Start ()
    {
        base.Start();
        img                 = GetComponent<SpriteRenderer>();
        target              = transform.parent.FindChild("mon01");
        m_StartScale        = transform.localScale;
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        anim                = target.GetComponent<Animator>();
        start_HP = m_HP = GameObject.FindObjectOfType<Enemy>().status.hp;
	}
	private void Update ()
    {
        UI_HP_back.transform.position = UI_back.transform.position = transform.position = target.position + (Vector3.up * m_Hight);
        UI_HP_back.transform.rotation = UI_back.transform.rotation = transform.rotation = Camera.main.transform.rotation;

        Debug.Log("life m_hp = " + m_HP);
        Debug.Log("life status.hp = " + m_HP);
        Vector3 hpScale = m_StartScale;
        if (m_HP > 0.0f)
        {
            hpScale.x = m_HP/start_HP;
            transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            transform.localScale = hpScale;
            target.GetComponent<Enemy>().enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
            anim.SetInteger("animation", 2);
            StartCoroutine("Death");
          
        }
        if (m_HP/start_HP <= 0.7f)
        {
            rgb.r += 1.0f;
            if (rgb.r >= 255.0f && m_HP/start_HP <= 0.4f)
            //r이 255가 되는 정확한 시점을 알아서 그 시점에 따라 바꿔줌. hp가 얼마나 되었는지? m_HP / start_HP이게 몇%가 되었을때인지 정확히.
            {
                rgb.r = 255.0f;
                rgb.g -= 1.0f;
            }
            img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
            //Debug.Log("r = " + rgb.r);
        }   
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.8f);
        transform.parent.gameObject.SetActive(false);
    }
}
