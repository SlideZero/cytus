using UnityEngine;

public class Coin : MonoBehaviour
{

    private bool _canMove = false;
    private Vector3 moveToPos;
    private float _aliveTimer = 0f;

    public float moveSpeed = 0f;
    public float aliveTime = 0f;

    public int beatNumber = 0;
    //public float 

    private void Update()
    {
        if (BPM.beatCountFull == beatNumber - 1)
            gameObject.SetActive(true);
        _aliveTimer += 1 * Time.deltaTime;

        if(gameObject.activeInHierarchy && !_canMove)
        {
            moveToPos = CoinSpawner.coinSpawner.GetNewPosition();
            _canMove = true;
        }

        if(_canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos, moveSpeed * Time.deltaTime);
        }

        if(transform.position == moveToPos && _aliveTimer > aliveTime)
        {
            _aliveTimer = 0f;
            _canMove = false;
            gameObject.SetActive(false);
        }
        
    }

    public void ResetCoin()
    {
        _canMove = false;
        _aliveTimer = 0;
        gameObject.SetActive(false);
        GameObject particle = ObjectPooler.SharedInstance.GetPooledObject("Particle");
        if(particle != null)
        {
            particle.SetActive(true);
            particle.transform.position = gameObject.transform.position;
        }
        ScoreManager.scoreManager.AddScorePoints(1);
    }

    private void OnBecameInvisible()
    {
        _canMove = false;
        _aliveTimer = 0;
        gameObject.SetActive(false);
    }
}
