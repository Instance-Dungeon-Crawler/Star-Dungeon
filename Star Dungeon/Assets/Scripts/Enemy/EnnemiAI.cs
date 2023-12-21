using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    [SerializeField] AudioClip[] _footStepRobot;
    [SerializeField] AudioClip _seeRobot;
    private Node NodeStart;
    public GameObject _player;
    public Transform _startPos;
    public Animator _animator;
    public NavMeshAgent _agent;
    public AudioSource _audioSource;
    private float _timer = 0.6f;
    public StatsEntity _DataEnemy;
    public bool _isDead = false;

    private void Awake()
    {
        _startPos = transform;
    }


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        NodeStart = new Selector(new List<Node>
        {
              new Sequence(new List<Node>
              {
                  //check if the Ennemi see the player
                new NodeSeePlayer(transform, _player, _audioSource, _seeRobot),

                new Sequence(new List<Node>
                {
                //if player is seen move to him and start combat once player is reached
                    new NodeMoveToPlayer(transform, _player, _animator, _agent),
                    new NodeStartCombat(transform, _player),
                }),
              }),
            //default behavior of patrolling
            new NodePatrol(transform, _animator, _agent)
        });
    }

    private void Update()
    {
        NodeStart.Evaluate();
        Sound();
        _timer -= Time.deltaTime;
    }

    public void Sound()
    {
        if (_agent.velocity.magnitude > 0 && _timer <=0)
        {
            AudioClip clip = _footStepRobot[UnityEngine.Random.Range(0, _footStepRobot.Length)];
            _audioSource.PlayOneShot(clip);
            _timer = 0.6f;
        }
    }
}
