using UnityEngine;
using System.Collections;

public class EnemyLife : HPBarBase 
{
	public      float           m_Hight         = 2.0f;
    public      GameObject      UI_back;
    public      GameObject      UI_HP_back;
    public static int           death_count;
    protected   Transform       target          = null;
    private     SpriteRenderer  img;
    private     Animator        anim;
    
	private void Start ()
    {
        base.Start();
        img                 = GetComponent<SpriteRenderer>();
        target              = transform.parent.FindChild("mon01");
        m_StartScale        = transform.localScale;
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        anim                = target.gameObject.GetComponent<Animator>();
        start_HP = m_HP     = GameObject.FindObjectOfType<Enemy>().status.hp;
	}
	private void Update ()
    {
        Vector3 hpScale = m_StartScale;
        if (m_HP > 0.0f)
        {
            UI_HP_back.transform.position = UI_back.transform.position = transform.position = target.position + (Vector3.up * m_Hight);
            UI_HP_back.transform.rotation = UI_back.transform.rotation = transform.rotation = Camera.main.transform.rotation;

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
            rgb.r   += 1.0f;
            if (rgb.r >= 255.0f && m_HP/start_HP <= 0.4f)
            {
                rgb.r = 255.0f;
                rgb.g -= 1.0f;
            }
            img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
        }   
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.8f);
        ++death_count;
        this.transform.parent.gameObject.SetActive(false);
        //if (this.transform.parent.gameObject.activeInHierarchy == false)
        //{
        //    Destroy(transform.parent.gameObject);
        //}
    }
    public int DeathCount
    {
        set { death_count = value; }
        get { return death_count; }
    }
}
