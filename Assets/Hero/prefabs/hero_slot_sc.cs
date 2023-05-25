using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hero_slot_sc : MonoBehaviour
{
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;
    public fight_db_sc fight_db;


    public rune_sc rune_sc;
    public sk_sc sk_sc;
    public ef_sc ef_sc;
    public ps_sc ps_sc;


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


    private void Awake()
    {
        _hero_name = fight_db._spawn_hero_name;
        _is_ally = fight_db._spawn_hero_is_ally;
        _is_clone = fight_db._spawn_hero_is_clone;

        _sk_pn = GameObject.Find("sk_pn");
        _world_pn = GameObject.Find("world_pn");
    }
    private void Start()
    {
        rune_sc = GameObject.Find("rune_sc").GetComponent<rune_sc>();
        sk_sc = GameObject.Find("sk_sc").GetComponent<sk_sc>();
        ef_sc = GameObject.Find("ef_sc").GetComponent<ef_sc>();
        ps_sc = GameObject.Find("ps_sc").GetComponent<ps_sc>();

        if (_is_ally == true && _is_clone == false)
        {
            Ally_Har_Load();
        }
        else if (_is_ally == false && _is_clone == false)
        {
            Enemy_Har_Load();
        }
        else if (_is_clone == true)
        {
            Clone_Har_Load();
        }
        _bar_wight = _turn_bar.GetComponent<RectTransform>().rect.width;
    }
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
        if (_turn_bar_k < 100 && fight_db._turn_lock == false)
        {
            _turn_bar_k += _spd * 0.01f;
        }
        else if (_turn_bar_k >= 100 && fight_db._turn_lock == false)
        {
            _turn_bar_k = 100;
            fight_db._turn_lock = true;
            fight_db._turn_hero = gameObject;
            Turn_Load();
        }
    }


    //har load
    void Ally_Har_Load()
    {
        //general
        fight_db._ally_team.Add(gameObject);
        gameObject.name = _hero_name + "_ally";
        _life = true;
        _move = false;

        //har & stat
        _uh_num = user_hero_db._name.IndexOf(_hero_name) + 1;
        _h_num = hero_db._name.IndexOf(_hero_name) + 1;
        _lv = user_hero_db._lv[_uh_num - 1];

        List<int> rune_stat = rune_sc.Hero_Runes_Stat(_uh_num);

        int b_hp = (hero_db._hp[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_atk = (hero_db._atk[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_def = (hero_db._def[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_spd = hero_db._spd[_h_num - 1];
        int b_crr = hero_db._crr[_h_num - 1];
        int b_crd = hero_db._crd[_h_num - 1];
        int b_acc = hero_db._acc[_h_num - 1];
        int b_res = hero_db._res[_h_num - 1];

        _hp = _hp_mx = b_hp * (rune_stat[1] + 100) / 100 + rune_stat[0];
        _atk = b_atk * (rune_stat[3] + 100) / 100 + rune_stat[2];
        _def = b_def * (rune_stat[5] + 100) / 100 + rune_stat[4];
        _spd = b_spd + rune_stat[6];

        _crr = b_crr + rune_stat[7];
        _crd = b_crd + rune_stat[8];
        _acc = b_acc + rune_stat[9];
        _res = b_res + rune_stat[10];

        _turn_bar_k = 0;

        //sk
        _sk_cd = hero_db._sk_pcd[_h_num - 1];
        _ul_cd = hero_db._ul_pcd[_h_num - 1];
        _ps_cd = hero_db._ps_pcd[_h_num - 1];
        _aa_lv = user_hero_db._aa_lv[_uh_num - 1];
        _sk_lv = user_hero_db._sk_lv[_uh_num - 1];
        _ul_lv = user_hero_db._ul_lv[_uh_num - 1];
        _ps_lv = user_hero_db._ps_lv[_uh_num - 1];

        //anim
        _anim = hero_db.anim_con[_h_num - 1];
    }
    void Enemy_Har_Load()
    {
        //general
        fight_db._enemy_team.Add(gameObject);
        _model.transform.localScale = new Vector3(-1, 1, 1);
        gameObject.name = _hero_name + "_enemy";
        _life = true;
        _move = false;

        //har & stat
        _h_num = hero_db._name.IndexOf(_hero_name) + 1;

        _lv = fight_db._enemy_lv;
        _bonus = fight_db._enemy_bonus;

        int b_hp = (hero_db._hp[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_atk = (hero_db._atk[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_def = (hero_db._def[_h_num - 1] * (100 + 2 * _lv)) / 100;
        int b_spd = hero_db._spd[_h_num - 1];
        int b_crr = hero_db._crr[_h_num - 1];
        int b_crd = hero_db._crd[_h_num - 1];
        int b_acc = hero_db._acc[_h_num - 1];
        int b_res = hero_db._res[_h_num - 1];

        _hp = _hp_mx = (b_hp * (100 + _bonus))/100;
        _atk = (b_atk * (100 + _bonus)) / 100;
        _def = (b_def * (100 + _bonus)) / 100;
        _spd = b_spd + _bonus;

        _crr = b_crr + _bonus/2;
        _crd = b_crd + _bonus/2;
        _acc = b_acc + _bonus/2;
        _res = b_res + _bonus/2;

        _turn_bar_k = 0;

        //sk
        _sk_cd = hero_db._sk_pcd[_h_num - 1];
        _ul_cd = hero_db._ul_pcd[_h_num - 1];
        _ps_cd = hero_db._ps_pcd[_h_num - 1];
        _aa_lv = 2;
        _sk_lv = 2;
        _ul_lv = 2;
        _ps_lv = 2;

        //anim
        _anim = hero_db.anim_con[_h_num - 1];
    }
    void Clone_Har_Load()
    {
        //general
        if (_is_ally == true)
        {
            fight_db._ally_team.Add(gameObject);
            gameObject.name = _hero_name + "_ally";
        }
        else if (_is_ally == false)
        {
            fight_db._enemy_team.Add(gameObject);
            gameObject.name = _hero_name + "_enemy";
        }
        _life = true;
        _move = false;

        //har & stat
        _uh_num = user_hero_db._name.IndexOf(_hero_name) + 1;
        _h_num = hero_db._name.IndexOf(_hero_name) + 1;
        _lv = 1;

        _hp = _hp_mx = fight_db._cl_hp;
        _atk = fight_db._cl_atk;
        _def = fight_db._cl_def;
        _spd = fight_db._cl_spd;

        _crr = fight_db._cl_crr;
        _crd = fight_db._cl_crd;
        _acc = fight_db._cl_acc;
        _res = fight_db._cl_res;

        _turn_bar_k = 0;

        //sk
        if (_is_ally == true)
        {
            _aa_lv = user_hero_db._aa_lv[_uh_num - 1];
        }
        else if (_is_ally == false)
        {
            _aa_lv = 2;
        }
        _sk_cd = 0;
        _ul_cd = 0;
        _ps_cd = 0;
        _sk_lv = 0;
        _ul_lv = 0;
        _ps_lv = 0;


        //anim
        _anim = hero_db.anim_con[_h_num - 1];
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
                case 1: sk_name = hero_db._aa_name[_h_num - 1]; sk_type = "aa"; break;
                case 2: sk_name = hero_db._sk_name[_h_num - 1]; sk_type = "sk"; break;
                case 3: sk_name = hero_db._ul_name[_h_num - 1]; sk_type = "ul"; break;
                case 4: sk_name = hero_db._ps_name[_h_num - 1]; sk_type = "ps"; break;
            }

            fight_db._spawn_sk_type = sk_type;
            fight_db._spawn_sk_name = sk_name;
            fight_db._spawn_sk_hero_name = _hero_name;

            Instantiate(_sk_slot, _sk_pn.transform);
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
                dmg = ef_sc.Take_Dmg_Grow_Ef(dmg, this);
            }
            if (ig_grow_dmg_ps == false)
            {
                dmg = ps_sc.Take_Dmg_Grow_Ps(dmg, this);
            }

            if (ig_red_dmg_ef == false)
            {
                dmg = ef_sc.Take_Dmg_Red_Ef(dmg, this);
            }
            if (ig_red_dmg_ps == false)
            {
                dmg = ps_sc.Take_Dmg_Red_Ps(dmg, this);
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
        fight_db._take_dmg_txt = dmg;
        Instantiate(_take_dmg_txt, _take_dmg_txt_spawn_point.transform);
    }
    public void Take_Ef(string ef_name, int ef_lv, int ef_time, int ef_power, int ef_atk, bool is_bf)
    {
        if ((is_bf == false && _ef_name.Contains("immunity") == false) || (is_bf == true && _ef_name.Contains("curse") == false))
        {

        }
    }


    //button
    public void Hero_B()
    {
        hero_slot_sc turn_hero_sc = fight_db._turn_hero.GetComponent<hero_slot_sc>();

        if (fight_db._ch_sk_type != "" && fight_db._ch_sk_type != null)
        {
            if (fight_db._ch_sk_type == "aa" || (fight_db._ch_sk_type == "sk" && turn_hero_sc._sk_cd == 0) || (fight_db._ch_sk_type == "ul" && turn_hero_sc._ul_cd == 0))
            {
                sk_sc.Sk_Use(turn_hero_sc, this);
            }
            else
            {
            }
        }
    }
}
