using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/rune_db")]
public class rune_db_sc : ScriptableObject
{
    //runes inf
    public List<string> _set_rare_name = new();
    public List<Sprite> _set_rare_art = new();

    public List<string> _stat_name = new();


    //main stat
    public List<string> _1_slot_m_stat = new();
    public List<string> _2_slot_m_stat = new();
    public List<string> _3_slot_m_stat = new();
    public List<string> _4_slot_m_stat = new();
    public List<string> _5_slot_m_stat = new();
    public List<string> _6_slot_m_stat = new();

    public List<int> _1_star_rune_m_value = new();
    public List<int> _2_star_rune_m_value = new();
    public List<int> _3_star_rune_m_value = new();
    public List<int> _4_star_rune_m_value = new();
    public List<int> _5_star_rune_m_value = new();


    //main_lv_up
    public List<int> _1_star_2_lv = new();
    public List<int> _2_star_2_lv = new();
    public List<int> _3_star_2_lv = new();
    public List<int> _4_star_2_lv = new();
    public List<int> _5_star_2_lv = new();

    public List<int> _1_star_3_lv = new();
    public List<int> _2_star_3_lv = new();
    public List<int> _3_star_3_lv = new();
    public List<int> _4_star_3_lv = new();
    public List<int> _5_star_3_lv = new();

    public List<int> _1_star_15_lv = new();
    public List<int> _2_star_15_lv = new();
    public List<int> _3_star_15_lv = new();
    public List<int> _4_star_15_lv = new();
    public List<int> _5_star_15_lv = new();



    //dop stat
    public List<string> _1_slot_d_stat = new();
    public List<string> _2_slot_d_stat = new();
    public List<string> _3_slot_d_stat = new();
    public List<string> _4_slot_d_stat = new();
    public List<string> _5_slot_d_stat = new();
    public List<string> _6_slot_d_stat = new();

    public List<int> _1_star_rune_d_value_mn = new();
    public List<int> _2_star_rune_d_value_mn = new();
    public List<int> _3_star_rune_d_value_mn = new();
    public List<int> _4_star_rune_d_value_mn = new();
    public List<int> _5_star_rune_d_value_mn = new();

    public List<int> _1_star_rune_d_value_mx = new();
    public List<int> _2_star_rune_d_value_mx = new();
    public List<int> _3_star_rune_d_value_mx = new();
    public List<int> _4_star_rune_d_value_mx = new();
    public List<int> _5_star_rune_d_value_mx = new();



    //lv up
    public List<int> _start_cost = new();
    public int _lv_cost_mod;


    //rune set
    public List<string> _set_name = new();
    public List<string> _set_stat = new();
    public List<int> _set_bonus = new();
}
