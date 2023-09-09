using System.Collections.Generic;
using UnityEngine;

public class story_fight_sc : MonoBehaviour
{
    [SerializeField] user_hero_db_sc _user_hero_db;
    [SerializeField] hero_db_sc _hero_db;
    [SerializeField] time_game_db_sc _time_game_db;
    [SerializeField] fight_db_sc _fight_db;
    [SerializeField] story_db_sc _story_db;
    [SerializeField] rune_sc _rune_sc;


    private void Start()
    {
        Story_Fight_Load();
    }
    public void Story_Fight_Load()
    {
        Fight_Db_Load();

        Ally_Spawn();
        Enemy_Spawn();
    }


    [SerializeField] Transform _ally_team_cont, _enemy_team_cont, _world_pn, _sk_pn, _chosen_sk_pn_place;
    void Fight_Db_Load()
    {
        //story_fight
        _fight_db._part_num = _story_db._part.IndexOf(_time_game_db._ch_part) + 1;

        //general_static_inf
        _fight_db._ally_team.Clear();
        _fight_db._enemy_team.Clear();
        _fight_db._ally_team_cont = _ally_team_cont;
        _fight_db._enemy_team_cont = _enemy_team_cont;
        _fight_db._world_pn = _world_pn;
        _fight_db._sk_pn = _sk_pn;
        _fight_db._chosen_sk_pn_place = _chosen_sk_pn_place;
        _fight_db._enemy_lv = _story_db._part_enemy_lv[_fight_db._part_num - 1];
        _fight_db._enemy_bonus = _story_db._part_enemy_bonus[_fight_db._part_num - 1];

        //setting for turn
        _fight_db._turn_hero = null;
        _fight_db._turn_lock = false;
        _fight_db._aim = null;
        _fight_db._chosen_sk = null;
    }


    public GameObject _hero_slot;
    void Ally_Spawn()
    {
        List<int> har = new();
        List<int> sk_lv = new();
        string hero_name;
        int lv, uh_num, h_num;
        int hp, atk, def, spd, crr, crd, acc, res;

        Ally_Clear();
        for (int i = 0; i < 5; i++)
        {
            if (_user_hero_db._team[i] != "No")
            {
                hero_name = _user_hero_db._team[i];
                uh_num = _user_hero_db._name.IndexOf(hero_name) + 1;
                h_num = _hero_db._name.IndexOf(hero_name) + 1;
                lv = _user_hero_db._lv[uh_num - 1];

                //har
                List<int> rune_stat = _rune_sc.Hero_Runes_Stat(uh_num);

                hp = (_hero_db._hp[h_num - 1] * (100 + 2 * lv)) / 100;
                atk = (_hero_db._atk[h_num - 1] * (100 + 2 * lv)) / 100;
                def = (_hero_db._def[h_num - 1] * (100 + 2 * lv)) / 100;
                spd = _hero_db._spd[h_num - 1];
                crr = _hero_db._crr[h_num - 1];
                crd = _hero_db._crd[h_num - 1];
                acc = _hero_db._acc[h_num - 1];
                res = _hero_db._res[h_num - 1];

                hp = hp * (rune_stat[1] + 100) / 100 + rune_stat[0];
                atk = atk * (rune_stat[3] + 100) / 100 + rune_stat[2];
                def = def * (rune_stat[5] + 100) / 100 + rune_stat[4];
                spd = spd + rune_stat[6];
                crr = crr + rune_stat[7];
                crd = crd + rune_stat[8];
                acc = acc + rune_stat[9];
                res = res + rune_stat[10];

                har = new() { hp, atk, def, spd, crr, crd, acc, res };

                //sk_lv
                sk_lv = new() { _user_hero_db._aa_lv[uh_num - 1], _user_hero_db._sk_lv[uh_num - 1], _user_hero_db._ul_lv[uh_num - 1], _user_hero_db._ps_lv[uh_num - 1] };

                Instantiate(_hero_slot, _ally_team_cont).GetComponent<hero_slot_sc>().Get_Setting(_user_hero_db._team[i], true, false, har, sk_lv);
            }
        }
    }
    void Ally_Clear()
    {
        int c = _ally_team_cont.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_ally_team_cont.GetChild(i).gameObject);
        }
    }


    void Enemy_Spawn()
    {
        List<int> har = new();
        List<int> sk_lv = new();
        string hero_name;
        int bonus, lv, h_num;
        int hp, atk, def, spd, crr, crd, acc, res;

        Enemy_Clear();
        int part_num = _fight_db._part_num;
        for (int i = 0; i < 5; i++)
        {
            if (_story_db._part_enemy[(part_num - 1) * 5 + i] != "No")
            {

                hero_name = _story_db._part_enemy[(part_num - 1) * 5 + i];
                h_num = _hero_db._name.IndexOf(hero_name) + 1;
                lv = _fight_db._enemy_lv;
                bonus = _fight_db._enemy_bonus;

                //har
                har.Clear();
                hp = (_hero_db._hp[h_num - 1] * (100 + 2 * lv)) / 100;
                atk = (_hero_db._atk[h_num - 1] * (100 + 2 * lv)) / 100;
                def = (_hero_db._def[h_num - 1] * (100 + 2 * lv)) / 100;
                spd = _hero_db._spd[h_num - 1];
                crr = _hero_db._crr[h_num - 1];
                crd = _hero_db._crd[h_num - 1];
                acc = _hero_db._acc[h_num - 1];
                res = _hero_db._res[h_num - 1];

                hp = (hp * (100 + bonus)) / 100;
                atk = (atk * (100 + bonus)) / 100;
                def = (def * (100 + bonus)) / 100;
                spd = spd + bonus;
                
                crr = crr + bonus / 2;
                crd = crd + bonus / 2;
                acc = acc + bonus / 2;
                res = res + bonus / 2;

                har = new() { hp, atk, def, spd, crr, crd, acc, res };

                //sk_lv
                sk_lv.Clear();
                sk_lv = new() { 2, 2, 2, 2 };

                Instantiate(_hero_slot, _enemy_team_cont).GetComponent<hero_slot_sc>().Get_Setting(_story_db._part_enemy[(part_num - 1) * 5 + i], false, false, har, sk_lv);
            }
        }
    }
    void Enemy_Clear()
    {
        int c = _enemy_team_cont.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_enemy_team_cont.GetChild(i).gameObject);
        }
    }


    void Reg_Ally_Enemy()
    {
        for (int i = 0; i < _ally_team_cont.childCount; i++)
        {
            _fight_db._ally_team.Add(_ally_team_cont.GetChild(i).gameObject);
        }
        for (int i = 0; i < _enemy_team_cont.childCount; i++)
        {
            _fight_db._enemy_team.Add(_enemy_team_cont.GetChild(i).gameObject);
        }
    }


    void Turn_Bar_Load()
    {

    }
}
