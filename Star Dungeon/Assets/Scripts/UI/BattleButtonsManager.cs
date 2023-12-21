using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Skills
{
    public float _damage;
    public float _attackSpeed;
    public GameObject _target;
    public GameObject _launcher;

    public enum _enum {attack, bigattack, skip}
    public _enum _attack;
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
    [SerializeField] ButtonCustom _skillButton;
    [SerializeField] ButtonCustom _attackButton;
    [SerializeField] ButtonCustom _skipButton;

    [Header("Life")]
    [SerializeField] private List<Slider> _charactersSliders = new List<Slider>();

    [Header("Mana")]
    [SerializeField] private List<Slider> _charactersManaSliders = new List<Slider>();
    
    [Header("Skills")]
    Skills _skills = new Skills();
    Skills _skills1 = new Skills();
    Skills _skills2 = new Skills();
    Skills _skills3 = new Skills();

    public PlayerComponent _playerComponent;

    public GameObject _enemy;
    [SerializeField] private GameObject Combat_Canva;
    [SerializeField] private GameObject Combat_Text;

    private enum _enum { xander, synthia, saber };
    private _enum _character;
    private int _luckFactor;

    [Header("Max Life")]
    private float _xanderMaxLife;
    private float _synthiaMaxLife;
    private float _saberMaxLife;
    private float _thermisMaxLife;

    [Header("Max Mana")]
    private float _xanderMaxMana;
    private float _synthiaMaxMana;
    private float _saberMaxMana;



    public List<Skills> _skillsList = new List<Skills>();

    public void Restart()
    {
        if (_thermisMaxLife >0)
        {
            GameObject.Find("Thermis").GetComponent<ScriptableReader>()._entityLife = _thermisMaxLife;
        }
        Start();
    }
    private void Start()
    {
        _enemy = EnemyManager.Instance._enemyInBattle;
        _character = _enum.xander;

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Characters"))
        {
            _characters.Add(gameObject);
        }

        foreach (GameObject gameObjects in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            _enemies.Add(gameObjects);
        }

        _xanderMaxLife = GameObject.Find("Xander").GetComponent<ScriptableReader>()._entityLife;
        _synthiaMaxLife = GameObject.Find("Synthia").GetComponent<ScriptableReader>()._entityLife;
        _saberMaxLife = GameObject.Find("Saber").GetComponent<ScriptableReader>()._entityLife;
        _thermisMaxLife = GameObject.Find("Thermis").GetComponent<ScriptableReader>()._entityLife;
        _xanderMaxMana = GameObject.Find("Xander").GetComponent<ScriptableReader>()._entityMana;
        _synthiaMaxMana = GameObject.Find("Synthia").GetComponent<ScriptableReader>()._entityMana;
        _saberMaxMana = GameObject.Find("Saber").GetComponent<ScriptableReader>()._entityMana;


        _skills._launcher = GameObject.Find("Xander");
        _attackDialogue.SetText("What should " + _skills._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
        if (_playerComponent.Level < 2)
        {
            _skillButton._interactable = false;
        }

        _playerComponent.GetComponent<PlayerComponent>();
    }

    private void Update()
    {
        Life();
        Mana();
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
        _skills3._attack = Skills._enum.attack;
        _skills3._attackSpeed = _enemyStats._entityAttackSpeed;
        _skillsList.Add(_skills3);
        _skills3._launcher = GameObject.Find("Thermis");
        int randomTarget = Random.Range(0, _characters.Count());
        _skills3._target = _characters[randomTarget];        
    }

    public string WhoToHeal()
    {
        if (_xander._entityLife < _synthia._entityLife || (_synthia._entityLife == _synthiaMaxLife && _xander._entityLife < _xanderMaxLife))
        {
            if (_xander._entityLife < _saber._entityLife || (_saber._entityLife == _saberMaxLife && _xander._entityLife < _xanderMaxLife))
            {
                return (_xander._entityName);
            }
            else
            {
                return (_saber._entityName);
            }
        }
        else if(_synthia._entityLife < _saber._entityLife || (_saber._entityLife == _saberMaxLife && _synthia._entityLife < _synthiaMaxLife))
        {
            return (_synthia._entityName);
        }
        else
        {
            return (_saber._entityName);
        }
    }

    public void Attacks()
    {
        switch (_character)
        {
            case _enum.xander:
                _skills._attack = Skills._enum.attack;
                _skills._attackSpeed = _xander._entityAttackSpeed;
                _skills._target = _enemies.First();
                _skills1._launcher = GameObject.Find("Synthia");
                _attackDialogue.SetText("What should " + _skills1._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                _skillsList.Add(_skills);

                if (_playerComponent.Level >= 2 && _synthia._entityMana >= 50 && _synthia._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_synthia._entityCooldown > 0)
                {
                    _synthia._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.synthia;
                break;
            case _enum.synthia:
                _skills1._attack = Skills._enum.attack;
                _skills1._attackSpeed = _synthia._entityAttackSpeed;
                _skillsList.Add(_skills1);
                _skills1._target = _enemies.First();
                _skills2._launcher = GameObject.Find("Saber");
                _attackDialogue.SetText("What should " + _skills2._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                if (_playerComponent.Level >= 2 && _saber._entityMana >= 50 && _saber._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_saber._entityCooldown > 0)
                {
                    _saber._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.saber;
                break;
            case _enum.saber:
                _skills2._attack = Skills._enum.attack;
                _skills2._attackSpeed = _saber._entityAttackSpeed;
                _skillsList.Add(_skills2);
                _skills2._target = _enemies.First();
                _character = _enum.xander;
                SortingSkillsList();
                LaunchAttack();
                break;
            default: break;
        }
    }

    public void BigAttack()
    {
        switch (_character)
        {
            case _enum.xander:
                _skills._attack = Skills._enum.bigattack;
                _skills._attackSpeed = _xander._entityAttackSpeed*0.4f;
                _skillsList.Add(_skills);
                _skills._target = _enemies.First();
                _skills1._launcher = GameObject.Find("Synthia");
                _attackDialogue.SetText("What should " + _skills1._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                if (_playerComponent.Level >= 2 && _synthia._entityMana >= 50 && _synthia._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_synthia._entityCooldown > 0)
                {
                    _synthia._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.synthia;
                break;
            case _enum.synthia:
                _skills1._attack = Skills._enum.bigattack;
                _skills1._attackSpeed = _synthia._entityAttackSpeed;
                _skillsList.Add(_skills1);
                _skills1._target = GameObject.Find(WhoToHeal());
                _skills2._launcher = GameObject.Find("Saber");
                _attackDialogue.SetText("What should " + _skills2._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                if (_playerComponent.Level >= 2 && _saber._entityMana >= 50 && _saber._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_saber._entityCooldown > 0)
                {
                    _saber._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.saber;
                break;
            case _enum.saber:
                _skills2._attack = Skills._enum.bigattack;
                _skills2._attackSpeed = _saber._entityAttackSpeed*2;
                _skillsList.Add(_skills2);
                _skills2._target = _enemies.First();
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
                _skills._attack = Skills._enum.skip;
                _skills._attackSpeed = _xander._entityAttackSpeed;
                _skillsList.Add(_skills);
                _skills1._launcher = GameObject.Find("Synthia");
                _attackDialogue.SetText("What should " + _skills1._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                if (_playerComponent.Level >= 2 && _synthia._entityMana >= 50 && _synthia._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_synthia._entityCooldown > 0)
                {
                    _synthia._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.synthia;
                break;
            case _enum.synthia:
                _skills1._attack = Skills._enum.skip;
                _skills1._attackSpeed = _synthia._entityAttackSpeed;
                _skillsList.Add(_skills1);
                _skills2._launcher = GameObject.Find("Saber");
                _attackDialogue.SetText("What should " + _skills2._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
                if (_playerComponent.Level >= 2 && _saber._entityMana >= 50 && _saber._entityCooldown <= 0)
                {
                    _skillButton._interactable = true;
                }
                else if (_saber._entityCooldown > 0)
                {
                    _saber._entityCooldown -= 1;
                    _skillButton._interactable = false;
                }
                else
                {
                    _skillButton._interactable = false;
                }
                _character = _enum.saber;
                break;
            case _enum.saber:
                _skills2._attack = Skills._enum.skip;
                _skills2._attackSpeed = _saber._entityAttackSpeed;
                _skillsList.Add(_skills2);
                _skills2._launcher = GameObject.Find("Saber");
                _character = _enum.xander;
                SortingSkillsList();
                LaunchAttack();
                break;
            default: break;
        }
    }


    private void LaunchAttack()
    {
        StartCoroutine(WaitBeforeAttack());
        _skillsList.Clear();
    }
    private void Levelling()
    {    
        if (_playerComponent.Level < 3)
        {
            _attackDialogue.SetText("you have gained 50 xp");
            _playerComponent.Exp += 50;
            
            if (_playerComponent.Exp >= _playerComponent.threshold)
            {
                _attackDialogue.SetText("You have gained a lvl");
                _playerComponent.Level +=1;
                _playerComponent.threshold += 50;
                _playerComponent.Exp = 0;
            }
        }
    }

    private void EndGame()
    {
        foreach (GameObject characters in _characters.ToList())
        {
            if (characters.GetComponent<ScriptableReader>()._entityLife <= 0)
            {
                _characters.Remove(characters);
                _attackDialogue.SetText(characters.GetComponent<ScriptableReader>()._entityName + " is dead. ");
                _enemy.GetComponent<EnnemiAI>()._isDead = true;
            }
            else
                _attackDialogue.SetText("What should " + _skills._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");

        }

        foreach (GameObject enemy in _enemies.ToList())
        {
            if (enemy.GetComponent<ScriptableReader>()._entityLife <= 0)
            {
                _enemies.Remove(enemy);
                int randkey = Random.Range(0, 2);

                if (randkey == 0)
                {
                    _playerComponent.key += 1;
                    _attackDialogue.SetText(enemy.GetComponent<ScriptableReader>()._entityName + " has been defeated. You found a key,it can open locked doors !");
                    
                }
                else
                {
                    _attackDialogue.SetText(enemy.GetComponent<ScriptableReader>()._entityName + " has been defeated.");
                }
                Levelling();
                // SceneManager.LoadScene("Game");     
                // Save.Instance.LoadFromJSON();
                foreach (var _robot in EnemyManager.Instance._enemies)
                {
                    if (!_robot.GetComponent<EnnemiAI>()._isDead)
                    {
                        _robot.SetActive(true);
                    }
                    else if(_robot.GetComponent<EnnemiAI>()._isDead)
                    {
                        _robot.GetComponent<EnnemiAI>().transform.position = _robot.GetComponent<EnnemiAI>()._startPos.position;
                    }
                }
                Combat_Text.SetActive(false);
                Combat_Canva.SetActive(false);
                
            }
            else
                _attackDialogue.SetText("What should " + _skills._launcher.GetComponent<ScriptableReader>()._entityName + " do ?");
        }
    }

    private IEnumerator WaitBeforeAttack()
    {
        foreach (var skills in _skillsList.ToList())
        {
            _skillButton._interactable = false;
            _attackButton._interactable = false;
            _skipButton._interactable = false;
            if (skills._launcher.GetComponent<ScriptableReader>()._entityBleeding && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
            {
                if (skills._launcher.GetComponent<ScriptableReader>()._entityName == "Xander")
                {
                    skills._damage = _xanderMaxLife * 0.05f;
                }
                else if (skills._launcher.GetComponent<ScriptableReader>()._entityName == "Synthia")
                {
                    skills._damage = _synthiaMaxLife * 0.05f;
                }
                else
                {
                    skills._damage = _saberMaxLife * 0.05f;
                }
                skills._launcher.GetComponent<ScriptableReader>()._entityLife -= skills._damage;
                if (skills._launcher.GetComponent<ScriptableReader>()._entityBleedTimer > 0)
                {
                    skills._launcher.GetComponent<ScriptableReader>()._entityBleedTimer -= 1;
                }
                else if (skills._launcher.GetComponent<ScriptableReader>()._entityBleedTimer == 0)
                {
                    skills._launcher.GetComponent<ScriptableReader>()._entityBleeding = false;
                }
                _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " lost health due to bleeding");
                StartCoroutine(ClearDialogueBox());
            }
            else
            {
                skills._launcher.GetComponent<ScriptableReader>()._entityBleeding = false;
            }
            yield return new WaitForSeconds(1);
            if (skills._attack == Skills._enum.attack)
            {
                if (skills._target.GetComponent<ScriptableReader>()._entityLife >= 0 && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
                {
                    _luckFactor = Random.Range(20, 50);
                    Debug.Log("attack");
                    skills._damage = (skills._launcher.GetComponent<ScriptableReader>()._entityPower / skills._target.GetComponent<ScriptableReader>()._entityResistance) * _luckFactor;
                    skills._target.GetComponent<ScriptableReader>()._entityLife -= skills._damage;
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " attack " + skills._target.GetComponent<ScriptableReader>()._entityName);
                    yield return new WaitForSeconds(1);
                    int randbleed = Random.Range(0, 100);
                    if (randbleed <= 25 && skills._launcher.GetComponent<ScriptableReader>()._entityName == "Thermis" && !skills._target.GetComponent<ScriptableReader>()._entityBleeding)
                    {
                        skills._target.GetComponent<ScriptableReader>()._entityBleeding = true;
                        skills._target.GetComponent<ScriptableReader>()._entityBleedTimer = 3;
                        _attackDialogue.SetText(skills._target.GetComponent<ScriptableReader>()._entityName + " is bleeding");
                    }
                    StartCoroutine(ClearDialogueBox());
                }
                else if (skills._launcher.GetComponent<ScriptableReader>()._entityLife <= 0)
                {
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " is dead. They cannot attack.");
                    StartCoroutine(ClearDialogueBox());
                }
                else
                {
                    _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " attack...but " + skills._target.GetComponent<ScriptableReader>()._entityName + " is already dead.");
                    StartCoroutine(ClearDialogueBox());
                }
                yield return new WaitForSeconds(1);
            }
            else if(skills._attack == Skills._enum.skip)
            {
                Debug.Log("skip");
                _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " skipped their turn ");
                StartCoroutine(ClearDialogueBox());
                yield return new WaitForSeconds(1);
            }
            else if (skills._attack == Skills._enum.bigattack)
            {
                if (skills._launcher == GameObject.Find("Xander"))
                {
                    if (skills._target.GetComponent<ScriptableReader>()._entityLife >= 0 && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
                    {
                        _luckFactor = Random.Range(20, 50);
                        skills._damage = ((skills._launcher.GetComponent<ScriptableReader>()._entityPower*1.1f) / (skills._target.GetComponent<ScriptableReader>()._entityResistance) * _luckFactor);
                        skills._target.GetComponent<ScriptableReader>()._entityLife -= skills._damage;
                        _xander._entityMana -= 50;
                        _xander._entityCooldown = 2;
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " wind up and strikes " + skills._target.GetComponent<ScriptableReader>()._entityName+ " hard.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    else if (skills._launcher.GetComponent<ScriptableReader>()._entityLife <= 0)
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " is dead. They cannot act.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    else
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " act...but " + skills._target.GetComponent<ScriptableReader>()._entityName + " is already dead.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    yield return new WaitForSeconds(1);
                }
                if (skills._launcher == GameObject.Find("Saber"))
                {
                    if (skills._target.GetComponent<ScriptableReader>()._entityLife >= 0 && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
                    {
                        _luckFactor = Random.Range(20, 50);
                        skills._damage = ((skills._launcher.GetComponent<ScriptableReader>()._entityPower * 0.5f) / (skills._target.GetComponent<ScriptableReader>()._entityResistance) * _luckFactor);
                        skills._target.GetComponent<ScriptableReader>()._entityLife -= skills._damage;
                        _saber._entityMana -= 50;
                        _saber._entityCooldown = 2;
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " strike " + skills._target.GetComponent<ScriptableReader>()._entityName + " below the belt.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    else if (skills._launcher.GetComponent<ScriptableReader>()._entityLife <= 0)
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " is dead. They cannot act.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    else
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " act...but " + skills._target.GetComponent<ScriptableReader>()._entityName + " is already dead.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    yield return new WaitForSeconds(1);
                }
                if (skills._launcher == GameObject.Find("Synthia"))
                {
                    if (skills._target.GetComponent<ScriptableReader>()._entityLife >= 0 && skills._launcher.GetComponent<ScriptableReader>()._entityLife > 0)
                    {
                        if (_synthia._entityLife == _synthiaMaxLife && _saber._entityLife == _saberMaxLife && _xander._entityLife == _xanderMaxLife)
                        {
                            _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " tried to heal but no one was injured.");
                            StartCoroutine(ClearDialogueBox());
                        }
                        else
                        {
                            skills._damage = ((skills._launcher.GetComponent<ScriptableReader>()._entityPower * 0.7f));
                            skills._target.GetComponent<ScriptableReader>()._entityLife += skills._damage;
                            _synthia._entityMana -= 50;
                            _synthia._entityCooldown = 2;
                            _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " healed " + skills._target.GetComponent<ScriptableReader>()._entityName);
                            StartCoroutine(ClearDialogueBox());
                        }
                    }
                    else if (skills._launcher.GetComponent<ScriptableReader>()._entityLife <= 0)
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " is dead. They cannot act.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    else
                    {
                        _attackDialogue.SetText(skills._launcher.GetComponent<ScriptableReader>()._entityName + " act...but " + skills._target.GetComponent<ScriptableReader>()._entityName + " is already dead.");
                        StartCoroutine(ClearDialogueBox());
                    }
                    yield return new WaitForSeconds(1);
                }
            }
            
        }
        EndGame();
        _attackButton._interactable = true;
        _skipButton._interactable = true;
        if (_playerComponent.Level >= 2 && _xander._entityMana >= 50 && _xander._entityCooldown <= 0)
        {
            _skillButton._interactable = true;
        }
        else if (_xander._entityCooldown >0)
        {
            _xander._entityCooldown -= 1;
            _skillButton._interactable = false;
        }
        else
        {
            _skillButton._interactable = false;
        }
    }

    private IEnumerator ClearDialogueBox()
    {
        yield return new WaitForSeconds(1f);
        _attackDialogue.SetText("");
    }

    private void Life()
    {
        _charactersSliders[0].value = GameObject.Find("Xander").GetComponent<ScriptableReader>()._entityLife / _xanderMaxLife;
        _charactersSliders[1].value = GameObject.Find("Synthia").GetComponent<ScriptableReader>()._entityLife / _synthiaMaxLife;
        _charactersSliders[2].value = GameObject.Find("Saber").GetComponent<ScriptableReader>()._entityLife / _saberMaxLife;
        _charactersSliders[3].value = GameObject.Find("Thermis").GetComponent<ScriptableReader>()._entityLife / _thermisMaxLife;

        for (int i = 0; i < _charactersSliders.Count; i++)
        {
            if (_charactersSliders[i].value > 0.5)
                _charactersSliders[i].transform.Find("Life Bar").GetComponent<Image>().color = new Color32(173, 255, 117, 255);
            else if (_charactersSliders[i].value <= 0.5 && _charactersSliders[i].value >= 0.2)
                _charactersSliders[i].transform.Find("Life Bar").GetComponent<Image>().color = new Color32(255, 255, 117, 255);
            else if (_charactersSliders[i].value < 0.2)
                _charactersSliders[i].transform.Find("Life Bar").GetComponent<Image>().color = new Color32(255, 118, 126, 255);
        }
    }

    private void Mana()
    {
        _charactersManaSliders[0].value = GameObject.Find("Xander").GetComponent<ScriptableReader>()._entityMana / _xanderMaxMana;
        _charactersManaSliders[1].value = GameObject.Find("Synthia").GetComponent<ScriptableReader>()._entityMana / _synthiaMaxMana;
        _charactersManaSliders[2].value = GameObject.Find("Saber").GetComponent<ScriptableReader>()._entityMana / _saberMaxMana;
    }
}