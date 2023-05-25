using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/user_rune_db")]

public class user_rune_db_sc : ScriptableObject
{
    public int _count = new();

    public List<int> _id = new();

    public List<string> _set = new();
    public List<int> _slot = new();
    public List<int> _star = new();
    public List<string> _rare = new();
    public List<int> _lv = new();
    public List<string> _hero = new();

    public List<string> _m_stat = new();
    public List<string> _1_d_stat = new();
    public List<string> _2_d_stat = new();
    public List<string> _3_d_stat = new();
    public List<string> _4_d_stat = new();

    public List<int> _hp_m = new();
    public List<int> _hp_p_m = new();
    public List<int> _atk_m = new();
    public List<int> _atk_p_m = new();
    public List<int> _def_m = new();
    public List<int> _def_p_m = new();
    public List<int> _spd_m = new();
    public List<int> _crr_m = new();
    public List<int> _crd_m = new();
    public List<int> _acc_m = new();
    public List<int> _res_m = new();

    public List<int> _hp_d = new();
    public List<int> _hp_p_d = new();
    public List<int> _atk_d = new();
    public List<int> _atk_p_d = new();
    public List<int> _def_d = new();
    public List<int> _def_p_d = new();
    public List<int> _spd_d = new();
    public List<int> _crr_d = new();
    public List<int> _crd_d = new();
    public List<int> _acc_d = new();
    public List<int> _res_d = new();
}
