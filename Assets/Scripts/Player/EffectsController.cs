using UnityEngine;

namespace Player
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private ParticleSystem dirtParticle;
        [SerializeField] private AudioSource playerAudio;
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip crashSound;
        [SerializeField] private AudioClip pickupSound;
        [SerializeField] private AudioClip deathSound;

        // Start is called before the first frame update
        void Start()
        {
            playerAudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void PlayExplosion()
        {
            explosionParticle.Play();
        }

        public void PlayDirt()
        {
            dirtParticle.Play();
        }

        public void StopDirt()
        {
            dirtParticle.Stop();
        }

        public void PlayJumpSound()
        {
            playerAudio.PlayOneShot(jumpSound);
        }

        public void PlayCrashSound()
        {
            playerAudio.PlayOneShot(crashSound);
        }

        public void PlayPickupSound()
        {
            playerAudio.PlayOneShot(pickupSound);
        }

        public void PlayDeathSound()
        {
            playerAudio.PlayOneShot(deathSound);
        }
    }
}