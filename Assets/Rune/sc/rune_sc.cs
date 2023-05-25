using System.Collections.Generic;
using UnityEngine;

public class rune_sc : MonoBehaviour
{
    public user_hero_db_sc user_hero_db;
    public user_rune_db_sc user_rune_db;
    public rune_db_sc rune_db;


    public void Rune_Sp_B(int slot)
    {
        user_rune_db._count++;
        Add_Rune("energy", slot, 4, "r");
    }


    public void Add_Rune(string set, int slot, int star, string rare)
    {
        user_rune_db._id.Add(user_rune_db._id.Count + 1);

        user_rune_db._set.Add(set);
        user_rune_db._slot.Add(slot);
        user_rune_db._star.Add(star);
        user_rune_db._rare.Add(rare);
        user_rune_db._lv.Add(0);
        user_rune_db._hero.Add("No");

        user_rune_db._m_stat.Add("No");
        user_rune_db._1_d_stat.Add("No");
        user_rune_db._2_d_stat.Add("No");
        user_rune_db._3_d_stat.Add("No");
        user_rune_db._4_d_stat.Add("No");

        user_rune_db._hp_m.Add(0);
        user_rune_db._hp_p_m.Add(0);
        user_rune_db._atk_m.Add(0);
        user_rune_db._atk_p_m.Add(0);
        user_rune_db._def_m.Add(0);
        user_rune_db._def_p_m.Add(0);
        user_rune_db._spd_m.Add(0);
        user_rune_db._crr_m.Add(0);
        user_rune_db._crd_m.Add(0);
        user_rune_db._acc_m.Add(0);
        user_rune_db._res_m.Add(0);

        user_rune_db._hp_d.Add(0);
        user_rune_db._hp_p_d.Add(0);
        user_rune_db._atk_d.Add(0);
        user_rune_db._atk_p_d.Add(0);
        user_rune_db._def_d.Add(0);
        user_rune_db._def_p_d.Add(0);
        user_rune_db._spd_d.Add(0);
        user_rune_db._crr_d.Add(0);
        user_rune_db._crd_d.Add(0);
        user_rune_db._acc_d.Add(0);
        user_rune_db._res_d.Add(0);

        Add_Main_Stat(slot, star, user_rune_db._id.Count);
        New_Rune_Dop_Stat(slot, star, rare, user_rune_db._id.Count);
    }


    public void Rune_Lv_Up(int rune_id)
    {
        int lv = user_rune_db._lv[rune_id - 1];
        int slot = user_rune_db._slot[rune_id - 1];
        int star = user_rune_db._star[rune_id - 1];
        string m_stat = user_rune_db._m_stat[rune_id - 1];
        List<string> d_stat = new();
        d_stat.Add(user_rune_db._1_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._2_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._3_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._4_d_stat[rune_id - 1]);
        int m_stat_num = rune_db._stat_name.IndexOf(m_stat) + 1;
        int m_stat_up = 0;

        if (lv % 3 != 0)
        {
            if (star == 1)
            {
                m_stat_up = rune_db._1_star_2_lv[m_stat_num - 1];
            }
            else if (star == 2)
            {
                m_stat_up = rune_db._2_star_2_lv[m_stat_num - 1];
            }
            else if (star == 3)
            {
                m_stat_up = rune_db._3_star_2_lv[m_stat_num - 1];
            }
            else if (star == 4)
            {
                m_stat_up = rune_db._4_star_2_lv[m_stat_num - 1];
            }
            else if (star == 5)
            {
                m_stat_up = rune_db._5_star_2_lv[m_stat_num - 1];
            }

            Value_Insert(1, m_stat_up, m_stat, rune_id);
        }
        else if (lv % 3 == 0 && lv != 15)
        {
            if (star == 1)
            {
                m_stat_up = rune_db._1_star_3_lv[m_stat_num - 1];
            }
            else if (star == 2)
            {
                m_stat_up = rune_db._2_star_3_lv[m_stat_num - 1];
            }
            else if (star == 3)
            {
                m_stat_up = rune_db._3_star_3_lv[m_stat_num - 1];
            }
            else if (star == 4)
            {
                m_stat_up = rune_db._4_star_3_lv[m_stat_num - 1];
            }
            else if (star == 5)
            {
                m_stat_up = rune_db._5_star_3_lv[m_stat_num - 1];
            }

            Value_Insert(1, m_stat_up, m_stat, rune_id);

            Add_Dop_Stat(slot, star, rune_id);
        }
        else if (lv % 3 == 0 && lv == 15)
        {
            if (star == 1)
            {
                m_stat_up = rune_db._1_star_15_lv[m_stat_num - 1];
            }
            else if (star == 2)
            {
                m_stat_up = rune_db._2_star_15_lv[m_stat_num - 1];
            }
            else if (star == 3)
            {
                m_stat_up = rune_db._3_star_15_lv[m_stat_num - 1];
            }
            else if (star == 4)
            {
                m_stat_up = rune_db._4_star_15_lv[m_stat_num - 1];
            }
            else if (star == 5)
            {
                m_stat_up = rune_db._5_star_15_lv[m_stat_num - 1];
            }

            Value_Insert(1, m_stat_up, m_stat, rune_id);

            Add_Dop_Stat(slot, star, rune_id);
        }
    }


    void Add_Main_Stat(int slot, int star, int rune_id)
    {
        //main slot name
        string stat_name = "";
        int r = 0;
        if (slot == 1)
        {
            r = Random.Range(1, rune_db._1_slot_m_stat.Count + 1);
            stat_name = rune_db._1_slot_m_stat[r - 1];
        }
        else if (slot == 2)
        {
            r = Random.Range(1, rune_db._2_slot_m_stat.Count + 1);
            stat_name = rune_db._2_slot_m_stat[r - 1];
        }
        else if (slot == 3)
        {
            r = Random.Range(1, rune_db._3_slot_m_stat.Count + 1);
            stat_name = rune_db._3_slot_m_stat[r - 1];
        }
        else if (slot == 4)
        {
            r = Random.Range(1, rune_db._4_slot_m_stat.Count + 1);
            stat_name = rune_db._4_slot_m_stat[r - 1];
        }
        else if (slot == 5)
        {
            r = Random.Range(1, rune_db._5_slot_m_stat.Count + 1);
            stat_name = rune_db._5_slot_m_stat[r - 1];
        }
        else if (slot == 6)
        {
            r = Random.Range(1, rune_db._6_slot_m_stat.Count + 1);
            stat_name = rune_db._6_slot_m_stat[r - 1];
        }
        user_rune_db._m_stat[rune_id - 1] = stat_name;

        int m_num = rune_db._stat_name.IndexOf(stat_name) + 1;
        int stat_value = 0;
        if (star == 1)
        {
            stat_value = rune_db._1_star_rune_m_value[m_num - 1];
        }
        else if (star == 2)
        {
            stat_value = rune_db._2_star_rune_m_value[m_num - 1];
        }
        else if (star == 3)
        {
            stat_value = rune_db._3_star_rune_m_value[m_num - 1];
        }
        else if (star == 4)
        {
            stat_value = rune_db._4_star_rune_m_value[m_num - 1];
        }
        else if (star == 5)
        {
            stat_value = rune_db._5_star_rune_m_value[m_num - 1];
        }

        Value_Insert(1, stat_value, stat_name, rune_id);
    }
    void Add_Dop_Stat(int slot, int star, int rune_id)
    {
        List<string> d_stat = new();
        d_stat.Add(user_rune_db._1_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._2_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._3_d_stat[rune_id - 1]);
        d_stat.Add(user_rune_db._4_d_stat[rune_id - 1]);

        if (d_stat.Contains("No") == true)
        {
            B:
            string new_d_stat = "";
            int r = 0;
            if (slot == 1)
            {
                r = Random.Range(1, rune_db._1_slot_d_stat.Count + 1);
                new_d_stat = rune_db._1_slot_d_stat[r - 1];
            }
            else if (slot == 2)
            {
                r = Random.Range(1, rune_db._2_slot_d_stat.Count + 1);
                new_d_stat = rune_db._2_slot_d_stat[r - 1];
            }
            else if (slot == 3)
            {
                r = Random.Range(1, rune_db._3_slot_d_stat.Count + 1);
                new_d_stat = rune_db._3_slot_d_stat[r - 1];
            }
            else if (slot == 4)
            {
                r = Random.Range(1, rune_db._4_slot_d_stat.Count + 1);
                new_d_stat = rune_db._4_slot_d_stat[r - 1];
            }
            else if (slot == 5)
            {
                r = Random.Range(1, rune_db._5_slot_d_stat.Count + 1);
                new_d_stat = rune_db._5_slot_d_stat[r - 1];
            }
            else if (slot == 6)
            {
                r = Random.Range(1, rune_db._6_slot_d_stat.Count + 1);
                new_d_stat = rune_db._6_slot_d_stat[r - 1];
            }

            if (d_stat.Contains(new_d_stat) == true)
            {
                goto B;
            }
            else if (d_stat.Contains(new_d_stat) == false)
            {
                if (user_rune_db._1_d_stat[rune_id - 1] == "No")
                {
                    user_rune_db._1_d_stat[rune_id - 1] = new_d_stat;
                }
                else if (user_rune_db._2_d_stat[rune_id - 1] == "No")
                {
                    user_rune_db._2_d_stat[rune_id - 1] = new_d_stat;
                }
                else if (user_rune_db._3_d_stat[rune_id - 1] == "No")
                {
                    user_rune_db._3_d_stat[rune_id - 1] = new_d_stat;
                }
                else if (user_rune_db._4_d_stat[rune_id - 1] == "No")
                {
                    user_rune_db._4_d_stat[rune_id - 1] = new_d_stat;
                }

                int value = Dop_Stat_Value(new_d_stat, star);

                Value_Insert(2, value, new_d_stat, rune_id);
            }
        }
        else if (d_stat.Contains("No") == false)
        {
            int r = Random.Range(1, d_stat.Count + 1);
            string new_d_stat = d_stat[r - 1];

            int value = Dop_Stat_Value(new_d_stat, star);

            Value_Insert(2, value, new_d_stat, rune_id);
        }
    }
    int Dop_Stat_Value(string stat_name, int star)
    {
        int value = 0;

        int mn = 0;
        int mx = 0;
        int d_num = rune_db._stat_name.IndexOf(stat_name) + 1;
        if (star == 1)
        {
            mn = rune_db._1_star_rune_d_value_mn[d_num - 1];
            mx = rune_db._1_star_rune_d_value_mx[d_num - 1];
        }
        if (star == 2)
        {
            mn = rune_db._2_star_rune_d_value_mn[d_num - 1];
            mx = rune_db._2_star_rune_d_value_mx[d_num - 1];
        }
        if (star == 3)
        {
            mn = rune_db._3_star_rune_d_value_mn[d_num - 1];
            mx = rune_db._3_star_rune_d_value_mx[d_num - 1];
        }
        if (star == 4)
        {
            mn = rune_db._4_star_rune_d_value_mn[d_num - 1];
            mx = rune_db._4_star_rune_d_value_mx[d_num - 1];
        }
        if (star == 5)
        {
            mn = rune_db._5_star_rune_d_value_mn[d_num - 1];
            mx = rune_db._5_star_rune_d_value_mx[d_num - 1];
        }
        value = Random.Range(mn, mx + 1);

        return value;
    }
    void New_Rune_Dop_Stat(int slot, int star, string rare, int rune_id)
    {
        int d_stat_count = 0;
        if (rare == "c")
        {
            d_stat_count = 0;
        }
        if (rare == "n")
        {
            d_stat_count = 1;
        }
        if (rare == "r")
        {
            d_stat_count = 2;
        }
        if (rare == "e")
        {
            d_stat_count = 3;
        }
        if (rare == "l")
        {
            d_stat_count = 4;
        }

        if (d_stat_count != 0)
        {
            for (int i = 1; i <= d_stat_count; i++)
            {
                Add_Dop_Stat(slot, star, rune_id);
            }
        }
    }


    void Value_Insert(int v, int value, string stat_name, int rune_id)
    {
        if (v == 1)
        {
            if (stat_name == "hp")
            {
                user_rune_db._hp_m[rune_id - 1] += value;
            }
            else if (stat_name == "hp_p")
            {
                user_rune_db._hp_p_m[rune_id - 1] += value;
            }
            else if (stat_name == "atk")
            {
                user_rune_db._atk_m[rune_id - 1] += value;
            }
            else if (stat_name == "atk_p")
            {
                user_rune_db._atk_p_m[rune_id - 1] += value;
            }
            else if (stat_name == "def")
            {
                user_rune_db._def_m[rune_id - 1] += value;
            }
            else if (stat_name == "def_p")
            {
                user_rune_db._def_p_m[rune_id - 1] += value;
            }
            else if (stat_name == "spd")
            {
                user_rune_db._spd_m[rune_id - 1] += value;
            }
            else if (stat_name == "crr")
            {
                user_rune_db._crr_m[rune_id - 1] += value;
            }
            else if (stat_name == "crd")
            {
                user_rune_db._crd_m[rune_id - 1] += value;
            }
            else if (stat_name == "acc")
            {
                user_rune_db._acc_m[rune_id - 1] += value;
            }
            else if (stat_name == "res")
            {
                user_rune_db._res_m[rune_id - 1] += value;
            }
        }
        else if (v == 2)
        {
            if (stat_name == "hp")
            {
                user_rune_db._hp_d[rune_id - 1] += value;
            }
            else if (stat_name == "hp_p")
            {
                user_rune_db._hp_p_d[rune_id - 1] += value;
            }
            else if (stat_name == "atk")
            {
                user_rune_db._atk_d[rune_id - 1] += value;
            }
            else if (stat_name == "atk_p")
            {
                user_rune_db._atk_p_d[rune_id - 1] += value;
            }
            else if (stat_name == "def")
            {
                user_rune_db._def_d[rune_id - 1] += value;
            }
            else if (stat_name == "def_p")
            {
                user_rune_db._def_p_d[rune_id - 1] += value;
            }
            else if (stat_name == "spd")
            {
                user_rune_db._spd_d[rune_id - 1] += value;
            }
            else if (stat_name == "crr")
            {
                user_rune_db._crr_d[rune_id - 1] += value;
            }
            else if (stat_name == "crd")
            {
                user_rune_db._crd_d[rune_id - 1] += value;
            }
            else if (stat_name == "acc")
            {
                user_rune_db._acc_d[rune_id - 1] += value;
            }
            else if (stat_name == "res")
            {
                user_rune_db._res_d[rune_id - 1] += value;
            }
        }
    }


    public int Rune_Stat_Value(string stat, int rune_id)
    {
        int value = 0;

        if (rune_id != 0)
        {
            if (stat == "hp")
            {
                value += user_rune_db._hp_m[rune_id - 1];
                value += user_rune_db._hp_d[rune_id - 1];
            }
            if (stat == "hp_p")
            {
                value += user_rune_db._hp_p_m[rune_id - 1];
                value += user_rune_db._hp_p_d[rune_id - 1];
            }
            if (stat == "atk")
            {
                value += user_rune_db._atk_m[rune_id - 1];
                value += user_rune_db._atk_d[rune_id - 1];
            }
            if (stat == "atk_p")
            {
                value += user_rune_db._atk_p_m[rune_id - 1];
                value += user_rune_db._atk_p_d[rune_id - 1];
            }
            if (stat == "def")
            {
                value += user_rune_db._def_m[rune_id - 1];
                value += user_rune_db._def_d[rune_id - 1];
            }
            if (stat == "def_p")
            {
                value += user_rune_db._def_p_m[rune_id - 1];
                value += user_rune_db._def_p_d[rune_id - 1];
            }
            if (stat == "spd")
            {
                value += user_rune_db._spd_m[rune_id - 1];
                value += user_rune_db._spd_d[rune_id - 1];
            }
            if (stat == "crr")
            {
                value += user_rune_db._crr_m[rune_id - 1];
                value += user_rune_db._crr_d[rune_id - 1];
            }
            if (stat == "crd")
            {
                value += user_rune_db._crd_m[rune_id - 1];
                value += user_rune_db._crd_d[rune_id - 1];
            }
            if (stat == "acc")
            {
                value += user_rune_db._acc_m[rune_id - 1];
                value += user_rune_db._acc_d[rune_id - 1];
            }
            if (stat == "res")
            {
                value += user_rune_db._res_m[rune_id - 1];
                value += user_rune_db._res_d[rune_id - 1];
            }
        }

        return value;
    }


    //management
    public void Hero_Rune_Equip(string h_name, int rune_id)
    {
        int uh_num = user_hero_db._name.IndexOf(h_name) + 1;
        int r_slot = user_rune_db._slot[rune_id - 1];

        if (r_slot == 1)
        {
            if (user_hero_db._rune_1_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_1_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_1_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_1_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_1_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
        else if (r_slot == 2)
        {
            if (user_hero_db._rune_2_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_2_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_2_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_2_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_2_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
        else if (r_slot == 3)
        {
            if (user_hero_db._rune_3_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_3_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_3_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_3_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_3_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
        else if (r_slot == 4)
        {
            if (user_hero_db._rune_4_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_4_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_4_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_4_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_4_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
        else if (r_slot == 5)
        {
            if (user_hero_db._rune_5_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_5_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_5_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_5_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_5_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
        else if (r_slot == 6)
        {
            if (user_hero_db._rune_6_id[uh_num - 1] == 0)
            {
                user_hero_db._rune_6_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
            else if (user_hero_db._rune_6_id[uh_num - 1] != 0)
            {
                int p_rune_id = user_hero_db._rune_6_id[uh_num - 1];
                Rune_Remove(p_rune_id);
                user_hero_db._rune_6_id[uh_num - 1] = rune_id;
                Rune_Equip(h_name, rune_id);
            }
        }
    }
    public void Hero_Rune_Remove(string h_name, int rune_id)
    {
        int uh_num = user_hero_db._name.IndexOf(h_name) + 1;
        int r_slot = user_rune_db._slot[rune_id - 1];

        if (r_slot == 1)
        {
            user_hero_db._rune_1_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
        else if (r_slot == 2)
        {
            user_hero_db._rune_2_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
        else if (r_slot == 3)
        {
            user_hero_db._rune_3_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
        else if (r_slot == 4)
        {
            user_hero_db._rune_4_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
        else if (r_slot == 5)
        {
            user_hero_db._rune_5_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
        else if (r_slot == 6)
        {
            user_hero_db._rune_6_id[uh_num - 1] = 0;
            Rune_Remove(rune_id);
        }
    }
    void Rune_Equip(string h_name, int rune_id)
    {
        user_rune_db._hero[rune_id - 1] = h_name;
    }
    void Rune_Remove(int rune_id)
    {
        user_rune_db._hero[rune_id - 1] = "No";
    }

    public List<int> Hero_Runes_Stat(int uh_num)
    {
        List<int> all_rune_id = new();
        all_rune_id.Add(user_hero_db._rune_1_id[uh_num - 1]);
        all_rune_id.Add(user_hero_db._rune_2_id[uh_num - 1]);
        all_rune_id.Add(user_hero_db._rune_3_id[uh_num - 1]);
        all_rune_id.Add(user_hero_db._rune_4_id[uh_num - 1]);
        all_rune_id.Add(user_hero_db._rune_5_id[uh_num - 1]);
        all_rune_id.Add(user_hero_db._rune_6_id[uh_num - 1]);

        List<int> stat_value = new();
        string stat_name = "";

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < rune_db._stat_name.Count; j++)
            {
                if (i == 0)
                {
                    stat_name = rune_db._stat_name[j];
                    stat_value.Add(Rune_Stat_Value(stat_name, all_rune_id[i]));
                }
                else if (i != 0)
                {
                    stat_name = rune_db._stat_name[j];
                    stat_value[j] += Rune_Stat_Value(stat_name, all_rune_id[i]);
                }
            }
        }

        List<int> rune_set_bonus = Rune_Set_Bonus(uh_num);
        for (int i = 0; i < stat_value.Count; i++)
        {
            stat_value[i] += rune_set_bonus[i];
        }

        return stat_value;
    }
    List<int> Rune_Set_Bonus(int uh_num)
    {
        List<int> hero_rune_id = new();
        hero_rune_id.Add(user_hero_db._rune_1_id[uh_num - 1]);
        hero_rune_id.Add(user_hero_db._rune_2_id[uh_num - 1]);
        hero_rune_id.Add(user_hero_db._rune_3_id[uh_num - 1]);
        hero_rune_id.Add(user_hero_db._rune_4_id[uh_num - 1]);
        hero_rune_id.Add(user_hero_db._rune_5_id[uh_num - 1]);
        hero_rune_id.Add(user_hero_db._rune_6_id[uh_num - 1]);

        List<string> rune_set_name = new();
        for (int i = 0; i < 6; i++)
        {
            if (hero_rune_id[i] != 0)
            {
                rune_set_name.Add(user_rune_db._set[hero_rune_id[i] - 1]);
            }
        }

        string set_name;
        List<int> set_name_dubl = new();
        for (int i = 0; i < rune_db._set_name.Count; i++)
        {
            set_name_dubl.Add(0);
            set_name = rune_db._set_name[i];
            for (int j = 0; j < rune_set_name.Count; j++)
            {
                if (rune_set_name[j] == set_name)
                {
                    set_name_dubl[i]++;
                }
            }
        }

        List<int> stat_value = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        int set_c = 0;
        for (int i = 0; i < set_name_dubl.Count; i++)
        {
            set_c = set_name_dubl[i]/2;
            if (set_c >= 1)
            {
                switch (rune_db._set_stat[i])
                {
                    case "hp":
                        stat_value[0] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "hp_p":
                        stat_value[1] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "atk":
                        stat_value[2] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "atk_p":
                        stat_value[3] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "def":
                        stat_value[4] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "def_p":
                        stat_value[5] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "spd":
                        stat_value[6] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "crr":
                        stat_value[7] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "crd":
                        stat_value[8] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "acc":
                        stat_value[9] += rune_db._set_bonus[i] * set_c;
                        break;
                    case "res":
                        stat_value[10] += rune_db._set_bonus[i] * set_c;
                        break;
                }
            }
        }

        return stat_value;
    }
}
