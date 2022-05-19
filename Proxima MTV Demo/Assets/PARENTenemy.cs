using UnityEngine;

using UnityEngine.Playables;
public class PARENTenemy : MonoBehaviour
{
    public int Hp = 1;
    public Object Explosion;
    [HideInInspector]public Camera _cam;
    [HideInInspector]public  float _camHeight;
    [HideInInspector] public  float _camWidth;

    [HideInInspector]public bool Activate = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        _cam = Camera.main;
        _camHeight = 2f * _cam.orthographicSize;
        _camWidth = _camHeight * _cam.aspect;
    }
    
    public virtual void Update()
    {
        
    }
    
    void OnBecameInvisible()
    {
        if (!Activate) return;
        Destroy(gameObject);
    }
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Hp-= other.GetComponent<scrBullet>().Dmg;
            CheckHp(ref Hp);
            Destroy(other.gameObject);
            if (this.GetType() == typeof(Boss) || this.GetType() == typeof( EnemyVerticalSpawner))
            {
                SoundController.PlaySound("takeDMG");
            }
        } else if (other.gameObject.CompareTag("PlayerMissile"))
        {
            Hp-= other.GetComponent<Missile>().Dmg;
            CheckHp(ref Hp);
            Destroy(other.gameObject);
            if (this.GetType() == typeof(Boss) || this.GetType() == typeof( EnemyVerticalSpawner))
            {
                SoundController.PlaySound("takeDMG");
            }
        }
    }

    private void CheckHp(ref int hp)
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Time.frameCount == 0 || inEditor.EditorApplicationQuit) {
            return;
        }
        if (GameManager.Reload) return;
        
        Instantiate(Explosion,transform.position, Quaternion.identity);
        
        if (this.GetType() == typeof (Boss))
        {
            ScoreManager.instance.AddPoint(500);
        }
        else
        {
            ScoreManager.instance.AddPoint(100);
            SoundController.PlaySound("EnemyDie");
        }
    }
    
}
