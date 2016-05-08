using UnityEngine;
using System.Collections;

public class DeactiaveParticle : MonoBehaviour {

    private ParticleSystem checkParticles;
    public float ParticleSpeed = 4.0f;

	// Use this for initialization
	void Start () {
        checkParticles = GetComponent<ParticleSystem>();
        checkParticles.playbackSpeed = ParticleSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (checkParticles.isStopped)
        {
            this.gameObject.SetActive(false);
        }
	}
}
