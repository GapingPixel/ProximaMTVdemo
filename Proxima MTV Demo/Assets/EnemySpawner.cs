using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int _count = 0;
    private readonly int enemyDistance = 64;
    private Camera _cam;
    private float _camHeight;
    private float _camWidth;
    public GameObject EnemyForwardObj;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _camHeight = 2f * _cam.orthographicSize;
        _camWidth = _camHeight * _cam.aspect;

        if (GameManager.Checkpoint != 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    private void FixedUpdate()//50 Ticks
    {
        GameObject[] enemyInstance = new GameObject[20];

        switch (_count)
        {
            case 1:
                enemyInstance[0] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y-enemyDistance, 0), Quaternion.identity);
                enemyInstance[0].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Down;
                break;
            
            case 10:
                enemyInstance[1] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y-enemyDistance, 0), Quaternion.identity);
                enemyInstance[1].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Down;
                break;
            
            case 18:
                enemyInstance[2] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y-enemyDistance, 0), Quaternion.identity);
                enemyInstance[2].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Down;
                break;
            
            case 27:
                enemyInstance[3] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y-enemyDistance, 0), Quaternion.identity);
                enemyInstance[3].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Down;
                break;
            
            //ROUND 2//
            case 1+100:
                enemyInstance[4] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y+enemyDistance, 0), Quaternion.identity);
                enemyInstance[4].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Up;
                break;
            
            case 10+100:
                enemyInstance[5] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y+enemyDistance, 0), Quaternion.identity);
                enemyInstance[5].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Up;
                break;
            
            case 18+100:
                enemyInstance[6] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y+enemyDistance, 0), Quaternion.identity);
                enemyInstance[6].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Up;
                break;
            
            case 27+100:
                enemyInstance[7] = (GameObject)Instantiate(EnemyForwardObj, new Vector3(_cam.transform.position.x+154, _cam.transform.position.y+enemyDistance, 0), Quaternion.identity);
                enemyInstance[7].GetComponent<EnemyForward>().Pattern = EnemyForward.Patterns.Up;
                break;
        }
        _count++;
    }
}
