using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Skills
{
    public float _damage;
    public float _attackSpeed;
    public GameObject _target;
    public GameObject _launcher;

    public bool _attack;
}


public class BattleButtonsManager : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] ScriptableReader _enemyStats;

    [Header("Character Stats")]
    [SerializeField] ScriptableReader _xander;
    [SerializeField] ScriptableReader _synthia;
    [SerializeField] ScriptableReader _saber;

    [Header("Characters")]
    [SerializeField] private List<GameObject> _characters = new List<GameObject>();
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();

    [Header("Texts")]
    [SerializeField] private TMP_Text _attackDialogue;

    [Header("Buttons")]
    [SerializeField] ButtonCustom _attackButton;
    [SerializeField] ButtonCustom _skipButton;

    private enum _enum { xander, synthia, saber };
    private _enum _character;
    private int _luckFactor;

    public List<Skills> _skillsList = new List<Skills>();

    [Header("Skills")]
    Skills _skills = new Skills();
    Skills _skills1 = new Skills();
    Skills _skills2 = new Skills();
    Skills _skills3 = new Skills();

    private void Start()
    {
        _character = _enum.xander;

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Characters"))
        {
            _characters.Add(gameObject);
        }

        foreach (GameObject gameObjects in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _enemies.Add(gameObjects);
        }
    }

    public void SortingSkillsList()
    {
        EnemyAttack();
        for (int i = 0; i < _skillsList.Count + 1; i++)
        {
            int n = i;
            for (int j = 0; j < _skillsList.Count - n - 1; j++)
            {
                Skills skill = _skillsList[j];
                Skills skill2 = _skillsList[j + 1];
                if (skill._attackSpeed < skill2._attackSpeed)
                {
                    _skillsList[j] = _skillsList[j + 1];
                    _skillsList[j + 1] = skill;

                }
            }
        }
    }

    public void EnemyAttack()
    {
        _skills3._attack = true;
        _skills3._attackSpeed = _enemyStats._entityAttackSpeed;
        _skillsList.Add(_skills3);
        
        _skills3._launcher = GameObject.Find("Thermis");
        int randomTarget = Random.Range(0, _characters.Count());
        _skills3._target = _characters[randomTarget];
    }

    public void Attacks()
    {
        switch (_character)
        {
            case _enum.xander:
                _skills._attack = true;
                _skills._attackSpeed = _xander._entityAttackSpeed;
                _skills._target = _enemies.First();
                _skills._launcher = GameObject.Find("Xander");
                Debug.Log(_skills._target);
                _skillsList.Add(_skills);
                _character = _enum.synthia;
                break;
            case _enum.synthia:
                _skills1._attack = true;
                _skills1._attackSpeed = _synthia._entityAttackSpeed;
                _skillsList.Add(_skills1);
                _skills1._target = _enemies.First();
                _skills1._launcher = GameObject.Find("Synthia");
                Debug.Log(_skills1._target);
                _character = _enum.saber;
                break;
            case _enum.saber:
                _skills2._attack = true;
                _skills2._attackSpeed = _saber._entityAttackSpeed;
                _skillsList.Add(_skills2);
                _skills2._target = _enemies.First();
                _skills2._launcher = GameObject.Find("Saber");
                Debug.Log(_skills2._target);
                _character = _enum.xander;
                SortingSkillsList();
                LaunchAttack();
                break;
            default: break;
        }
    }

    public void Skip()
    {
        switch (_character)
        {
            case _enum.xander:
                _skills._attack = false;
                _skills._attackSpeed = _xander._entityAttackSpeed;
                _skillsList.Add(_skills);
                _skills._launcher = GameObject.Find("Xander");
                Debug.Log("Skip");
                _character = _enum.synthia;
                break;
            case _enum.synthia:
                _skills1._attack = false;
                _skills1._attackSpeed = _synthia._entityAttackSpeed;
                _skillsList.Add(_skills1);
                _skills1._launcher = GameObject.Find("Synthia");
                Debug.Log("Skip");
                _character = _enum.saber;
                break;
            case _enum.saber:
                _skills2._attack = false;
                _skills2._attackSpeed = _saber._entityAttackSpeed;
                _skillsList.Add(_skills2);
                _skills2._launcher = GameObject.Find("Saber");
                Debug.Log("Skip");
                _character = _enum.xander;
                SortingSkillsList();
                LaunchAttack();
                break;
            default: break;
        }
    }


    public void LaunchAttack()
    {
        StartCoroutine(WaitBeforeAttack());
        _skillsList.Clear();
    }

    private void EndGame()
    {
        foreach (GameObject characters in _characters.ToList())
        {
            if (characters.GetComponent<ScriptableReader>()._entityLife <= 0)
            {
                _characters.Remove(characters);
                _attackDialogue.SetText(characters.GetComponent<ScriptableReader>()._entityName + " is dead.");
            }

        }

        foreach(GameObject enemy in _enemies.ToList())
        {
            if(enemy.GetComponent<ScriptableReader>()._entityLife <= 0)
            {
                _enemies.Remove(enemy);
                _attackDialogue.SetText(enemy.GetComponent<ScriptableReader>()._entityName + " is dead.");
            }
        }
    }

    private IEnumerator WaitBeforeAttack()
    {
        foreach (var skills in _skillsList.ToList())
        {
            _attackButton._interactable = false;
            _skipButton._interactable = false; 
            if(skills._attack == true)
            {
                if(skills._target.GetComponent<ScriptableReader>()._entityLife >= 0 && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
                {
                    _luckFactor = Random.Range(20, 50);
                    Debug.Log("attack");
                    skills._damage = (skills._launcher.GetComponent<ScriptableReader>()._entityPower / skills._target.GetComponent<ScriptableReader>()._entityResistance) * _luckFactor;
                    skills._target.GetComponent<ScriptableReader>()._entityLife -= skills._damage;
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " attack " + skills._target.GetComponent<ScriptableReader>()._entityName);
                    StartCoroutine(ClearDialogueBox());
                }
                else if(skills._launcher.GetComponent<ScriptableReader>()._entityLife <= 0)
                {
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " is dead. He cannot attack.");
                    StartCoroutine(ClearDialogueBox());
                }
                else
                {
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " attack...but " + skills._target.GetComponent<ScriptableReader>()._entityName + " is already dead.");
                    StartCoroutine(ClearDialogueBox());
                }
                yield return new WaitForSeconds(4);
            }
            else 
            {
                Debug.Log("skip");
                _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " skip his turn ");
                StartCoroutine(ClearDialogueBox());
                yield return new WaitForSeconds(4);
            }
        }
        EndGame();

        _attackButton._interactable = true;
        _skipButton._interactable = true;
    }

    private IEnumerator ClearDialogueBox()
    {
        yield return new WaitForSeconds(3f);
        _attackDialogue.SetText("");
    }
}