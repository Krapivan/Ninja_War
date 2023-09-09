using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hero_slot_sc : MonoBehaviour
{
    public user_hero_db_sc _user_hero_db;
    public hero_db_sc _hero_db;
    public fight_db_sc _fight_db;


    public rune_sc _rune_sc;
    public sk_sc _sk_sc;
    public ef_sc _ef_sc;
    public ps_sc _ps_sc;


    //har and stat====================
    public RuntimeAnimatorController _anim;
    public GameObject _model;
    public string _hero_name;
    public bool _is_ally;
    public bool _is_clone;
    public int _uh_num, _h_num;

    int _lv, _bonus;
    public int _hp, _hp_mx, _atk, _def, _spd, _crr, _crd, _acc, _res;

    //sk===============================
    public int _sk_cd, _ul_cd, _ps_cd, _aa_lv, _sk_lv, _ul_lv, _ps_lv;

    //ef===============================
    public List<string> _ef_name;
    public Transform _ef_pn;

    //bar==============================
    public GameObject _turn_bar_line, _turn_bar, _hp_bar_line;
    public float _turn_bar_k;
    float _bar_wight;

    //general==========================
    GameObject _sk_pn, _world_pn;
    public Transform _take_dmg_txt_spawn_point;

    [SerializeField] bool _move, _life;
    [SerializeField] Vector3 _nd_place;
    float _move_speed = 0.2f;


    private void FixedUpdate()
    {
        if (_move == true)
        {
            Move();
        }

        if (_life == true) 
        {
            Hp_Bar_Load();
            Turn_Bar_Load();
            Turn_Bar_Up();
        }
    }


    public void Get_Setting(string hero_name, bool is_ally, bool is_clone, List<int> har, List<int> sk_lv)
    {
        //general
        _hero_name = hero_name;
        _is_ally = is_ally;
        _is_clone = is_clone;
        _h_num = _hero_db._name.IndexOf(hero_name) + 1;
        if (is_ally == true)
        {
            gameObject.name = _hero_name + "ally";
            _fight_db._ally_team.Add(gameObject);
            _uh_num = _user_hero_db._name.IndexOf(hero_name) + 1;
        }
        else
        {
            _fight_db._enemy_team.Add(gameObject);
            gameObject.name = _hero_name + "enemy";
            _model.transform.localScale = new Vector3(-1, 1, 1);
        }
        _life = true;
        _move = false;
        _turn_bar_k = 0;

        //anim
        _anim = _hero_db.anim_con[_h_num - 1];

        //any
        _rune_sc = GameObject.Find("rune_sc").GetComponent<rune_sc>();
        _sk_sc = GameObject.Find("sk_sc").GetComponent<sk_sc>();
        _ef_sc = GameObject.Find("ef_sc").GetComponent<ef_sc>();
        _ps_sc = GameObject.Find("ps_sc").GetComponent<ps_sc>();
        _bar_wight = _turn_bar.GetComponent<RectTransform>().rect.width;

        //har
        _hp = _hp_mx = har[0];
        _atk = har[1];
        _def = har[2];
        _spd = har[3];
        _crr = har[4];
        _crd = har[5];
        _acc = har[6];
        _res = har[7];

        _aa_lv = sk_lv[0];
        _sk_lv = sk_lv[1];
        _ul_lv = sk_lv[2];
        _ps_lv = sk_lv[3];
    }


    //bar
    public TextMeshProUGUI _hp_bar_txt;
    void Hp_Bar_Load()
    {
        float hp_lost_bar_k = (float)_hp / (float)_hp_mx;
        float x = -1 * _bar_wight + _bar_wight * hp_lost_bar_k;
        _hp_bar_line.transform.localPosition = new Vector3(x, 0, 0);
        _hp_bar_txt.text = _hp + " | " + _hp_mx;
    }
    void Turn_Bar_Load()
    {
        float x = -1 * _bar_wight + _bar_wight * _turn_bar_k / 100;
        _turn_bar_line.transform.localPosition = new Vector3(x, 0, 0);
    }
    void Turn_Bar_Up()
    {
        if (_turn_bar_k < 100 && _fight_db._turn_lock == false)
        {
            _turn_bar_k += _spd * 0.01f;
        }
        else if (_turn_bar_k >= 100 && _fight_db._turn_lock == false)
        {
            _turn_bar_k = 100;
            _fight_db._turn_lock = true;
            _fight_db._turn_hero = gameObject;
            Turn_Load();
        }
    }


    //turn
    public void Turn_Load()
    {
        Before_Turn_Ef();

        if (_ef_name.Contains("sleep") == false || _ef_name.Contains("stun") == false)
        {
            if (_is_ally == true)
            {
                _sk_pn.SetActive(true);
                Sk_Pn_Load();
            }
            else if (_is_ally == false)
            {
                _sk_pn.SetActive(false);
            }

            Move_To_Place(new Vector3(0, 0, transform.position.z));
        }
    }
    void Before_Turn_Ef()
    {
        //bf
        if (_ef_name.Contains("healing") == true)
        {
        }

        //dbf
        if (_ef_name.Contains("corrosion") == true)
        {
        }
        if (_ef_name.Contains("bomb") == true)
        {
        }
        if (_ef_name.Contains("stigma") == true)
        {
        }
    }


    //sk_pn
    public GameObject _sk_slot;
    void Sk_Pn_Load()
    {
        Sk_Pn_Clear();
        string sk_name = "", sk_type = "";
        for (int i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1: sk_name = _hero_db._aa_name[_h_num - 1]; sk_type = "aa"; break;
                case 2: sk_name = _hero_db._sk_name[_h_num - 1]; sk_type = "sk"; break;
                case 3: sk_name = _hero_db._ul_name[_h_num - 1]; sk_type = "ul"; break;
                case 4: sk_name = _hero_db._ps_name[_h_num - 1]; sk_type = "ps"; break;
            }

            Instantiate(_sk_slot, _sk_pn.transform).GetComponent<sk_slot_sc>().Spawn_Setting(sk_type, sk_name, gameObject);
        }
    }
    void Sk_Pn_Clear()
    {
        for (int i = 0; i < _sk_pn.transform.childCount; i++)
        {
            Destroy(_sk_pn.transform.GetChild(i).gameObject);
        }
    }


    //move
    public void Move_To_Place(Vector3 new_nd_place)
    {
        transform.parent = _world_pn.transform;
        _nd_place = new_nd_place;
        _move = true;
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nd_place, _move_speed);
        
        if (transform.position.x == _nd_place.x && transform.position.y == _nd_place.y)
        {
            _move = false;
        }
    }

    public void Move_Back()
    {

    }


    //take dmg & ef
    public GameObject _take_dmg_txt;
    public void Take_Damage(int dmg, bool ig_red_dmg_ef, bool ig_grow_dmg_ef, bool ig_red_dmg_ps, bool ig_grow_dmg_ps, int ig_def_p, hero_slot_sc attacker_sc)
    {
        if (dmg > 0)
        {
            dmg -= _def * (100 - ig_def_p) / 100;

            if (ig_grow_dmg_ef == false)
            {
                dmg = _ef_sc.Take_Dmg_Grow_Ef(dmg, this);
            }
            if (ig_grow_dmg_ps == false)
            {
                dmg = _ps_sc.Take_Dmg_Grow_Ps(dmg, this);
            }

            if (ig_red_dmg_ef == false)
            {
                dmg = _ef_sc.Take_Dmg_Red_Ef(dmg, this);
            }
            if (ig_red_dmg_ps == false)
            {
                dmg = _ps_sc.Take_Dmg_Red_Ps(dmg, this);
            }


            Damage_Visual(dmg);
            _hp -= dmg;
            if (_ef_name.Contains("immortal") == true)
            {
                _hp = 1;
            }

            if (_ef_name.Contains("sleep") == true)
            {
            }
            if (_ef_name.Contains("stigma") == true)
            {
            }
        }
    }

    public void Damage_Visual(int dmg)
    {
        Instantiate(_take_dmg_txt, _take_dmg_txt_spawn_point.transform).GetComponent<take_dmg_txt_sc>().Spawn_Setting(dmg);
    }
    public void Take_Ef(string ef_name, int ef_lv, int ef_time, int ef_power, int ef_atk, bool is_bf)
    {
        if ((is_bf == false && _ef_name.Contains("immunity") == false) || (is_bf == true && _ef_name.Contains("curse") == false))
        {

        }
    }


    //button
    public GameObject _aim_tag;
    public void Hero_B()
    {
        if (_fight_db._aim == null)
        {
            _fight_db._aim = gameObject;
            _aim_tag.SetActive(true);
        }
        else if (_fight_db._aim != null && _fight_db._aim == gameObject)
        {
            _fight_db._aim = null;
            _aim_tag.SetActive(false);
        }
        else if (_fight_db._aim != null && _fight_db._aim != gameObject)
        {
            _fight_db._aim.GetComponent<hero_slot_sc>()._aim_tag.SetActive(false);
            _fight_db._aim = gameObject;
            _aim_tag.SetActive(true);
        }
    }
}
