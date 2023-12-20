using UnityEngine;

public class NodeSeePlayer : Node
{
    EnnemiAI _ennemiAI;
    private Transform _transform;
    private GameObject _player;
    private AudioSource _audioSource;
    private AudioClip _seeRobot;
    private int _doOnes = 0;
    public NodeSeePlayer(Transform transform, GameObject player, AudioSource audioSource, AudioClip seeRobot)
    {
        _transform = transform;
        _player = player;
        _audioSource = audioSource;
        _seeRobot = seeRobot;
    }

    public override NodeState Evaluate()
    {
        //check if the player is line of sight
        Vector3 targetDir = _player.transform.position - _transform.position;
        float angle = Vector3.Angle(targetDir, _transform.forward);




        RaycastHit hit;
        if (angle < 180 && Physics.Raycast(new Vector3(_transform.position.x, _transform.position.y + 2, _transform.position.z), targetDir,out hit,15))
        {
            if (hit.collider.tag == "Player")
            {
                _doOnes++;
                if (_doOnes == 1)
                {
                    AudioClip clip = _seeRobot;
                    _audioSource.PlayOneShot(clip);
                }
                return NodeState.SUCCESS;
            }
            else
            {
                _doOnes = 0;
                return NodeState.FAILURE;
            }
        }
        else
        {
            _doOnes = 0;
            return NodeState.FAILURE;
        }
    }
}
