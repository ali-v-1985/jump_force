using System.Collections;
using System.Threading.Tasks;
using Environment;
using Events;
using GameState;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
        private static readonly int DeathB = Animator.StringToHash("Death_b");
        private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");
        private static readonly int SpeedF = Animator.StringToHash("Speed_f");

        [SerializeField] private float jumpPower;

        [SerializeField] private int maxMultiJump;

        private Rigidbody _rigidbody;
        private Animator _animator;
        private EffectsController _effectsControllerScript;
        private bool _isOnGround = true;
        private float _jumpAmount;
        private bool _canMultiJump;
        private int _multiJump;
        private float _mass;
        private float _initialAnimatorSpeed;
        private int _effectiveTime;
        private bool _shouldResetSpeed;
        private int _initialMaxMultiJump;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _mass = _rigidbody.mass;
            _jumpAmount = _mass * EnvironmentData.GravityForce * jumpPower;
            _effectsControllerScript = gameObject.GetComponent<EffectsController>();
            _initialAnimatorSpeed = _animator.speed;
            StartCoroutine(ReturnToRegularSpeed());
            _initialMaxMultiJump = maxMultiJump;
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameStateData.GameOver)
            {
                JumpIfNotJumping();
            }
            else
            {
                _effectsControllerScript.StopDirt();
                _animator.SetFloat(SpeedF, 0);
                _animator.SetBool(DeathB, true);
                _animator.SetInteger(DeathTypeINT, Random.Range(1, 3));
            }
        }

        private void JumpIfNotJumping()
        {
            CheckCanMultiJump();
            if (Input.GetButtonDown("Jump") && (_isOnGround || _canMultiJump))
            {
                Debug.Log("_multiJump from JumpIfNotJumping: " + _multiJump + " deltaTime:" + Time.deltaTime);
                _rigidbody.AddForce(Vector3.up * _jumpAmount, ForceMode.Impulse);
                _isOnGround = false;
                _animator.SetTrigger(JumpTrig);
                _effectsControllerScript.StopDirt();
                _effectsControllerScript.PlayJumpSound();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            CheckIfLand(other);
        }

        private void CheckIfLand(Collision other)
        {
            if (!_isOnGround && other.gameObject.CompareTag(Tags.Ground))
            {
                _isOnGround = true;
                Debug.Log("_multiJump from CheckIfLand: " + _multiJump + " deltaTime:" + Time.deltaTime);
                _effectsControllerScript.PlayDirt();
            }
        }

        private void CheckCanMultiJump()
        {
            if (!_isOnGround && _multiJump < maxMultiJump)
            {
                _canMultiJump = true;
                _multiJump++;
                Debug.Log("_multiJump from CheckCanMultiJump: " + _multiJump + " deltaTime:" + Time.deltaTime);
                return;
            }

            if (_isOnGround || _multiJump >= maxMultiJump)
            {
                _canMultiJump = false;
                _multiJump = 0;
            }
        }

        public void IncreaseJumpAmount(float jumpIncrease, int effectiveTime)
        {
            _jumpAmount += _jumpAmount * jumpIncrease;
            Task.Delay(effectiveTime * 1000).ContinueWith(t => ReturnToRegularJump());
        }


        public void IncreaseSpeedAmount(float speed, int effectiveTime)
        {
            EventRepo.ChangeSpeed.OnRaiseChangeSpeedEvent(this,
                new ChangeSpeedEventArgs(speed, effectiveTime));
            var speedValue = _animator.speed * speed;
            _animator.speed = speedValue;
            _effectiveTime = effectiveTime;
            _shouldResetSpeed = true;
        }

        IEnumerator ReturnToRegularSpeed()
        {
            while (!GameStateData.GameOver)
            {
                if (_shouldResetSpeed)
                {
                    yield return new WaitForSeconds(_effectiveTime);

                    _animator.speed = _initialAnimatorSpeed;
                    _shouldResetSpeed = false;
                }

                yield return null;
            }
        }

        private void ReturnToRegularJump()
        {
            _jumpAmount = _mass * EnvironmentData.GravityForce * jumpPower;
        }

        public void IncreaseMultiJumpAmount(float allowedMultiJump, int multiJumpLifeTime)
        {
            maxMultiJump = (int) allowedMultiJump;
            Task.Delay(multiJumpLifeTime * 1000).ContinueWith(t => maxMultiJump = _initialMaxMultiJump);
        }
    }
}