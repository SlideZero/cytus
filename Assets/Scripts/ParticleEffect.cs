using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    ParticleSystem particleSystem;
    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(particleSystem.isStopped)
        {
            gameObject.SetActive(false);
        }
    }
}
