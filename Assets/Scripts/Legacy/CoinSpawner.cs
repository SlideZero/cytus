using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner coinSpawner;

    [SerializeField] private string[] _objTags;

    //private float _spawnTimer = 0f;
    //public float spawnRate = 0f;

    private float _angle = 0f;
    private float _posX = 0f;
    private float _posY = 0f;
    private Vector3 newPosition;

    public Transform spawnOrigin;
    public float radious = 0f;

    private void Start()
    {
        coinSpawner = this;
    }

    private void Update()
    {
        //_spawnTimer += 1 * Time.deltaTime;
        if (BPM.beatFull)
        {
            //SpawnCoin("RedCoin");
            ScoreManager.scoreManager.gameScore.text = BPM._bPM.songPosition + ": " + BPM.beatCountFull.ToString();
            /*if (BPM.beatCountFull % 2 == 0)
            {
                SpawnCoin("GoldCoin");
            }*/
        }

        if(BPM.beatD8 && BPM.beatCountD8 % 4 == 0)
        {
            //SpawnCoin("GoldCoin");
        }
    }

    private void SpawnCoin(string tagString)
    {
        int tag = Random.Range(0, _objTags.Length);
        GameObject coin = ObjectPooler.SharedInstance.GetPooledObject(tagString);
        if (coin != null)
        {
            coin.transform.position = spawnOrigin.position;
            coin.SetActive(true);
        }
    }

    public Vector3 GetNewPosition()
    {
        _angle = Random.Range(0f, 360f);
        _posX = spawnOrigin.position.x + radious * Mathf.Cos(_angle);
        _posY = spawnOrigin.position.y + radious * Mathf.Sin(_angle);
        return newPosition = new Vector3(_posX, _posY, 0f);
    }

   /* public void ChangeMode(float newSpawnRate)
    {
        if(spawnRate != newSpawnRate)
        {
            spawnRate = newSpawnRate;
        }
    }*/
}
