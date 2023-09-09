using UnityEngine;

public class user_rune_db_save_sc : MonoBehaviour
{
    public user_rune_db_sc _user_rune_db;


    public void User_Rune_Db_Save()
    {
        PlayerPrefs.SetInt("_rune_count", _user_rune_db._count);

        for (int i = 0; i < _user_rune_db._count; i++)
        {
            PlayerPrefs.SetInt("_rune_id_" + i, _user_rune_db._id[i]);

            PlayerPrefs.SetString("_rune_set_" + i, _user_rune_db._set[i]);
            PlayerPrefs.SetInt("_rune_slot_" + i, _user_rune_db._slot[i]);
            PlayerPrefs.SetInt("_rune_star_" + i, _user_rune_db._star[i]);
            PlayerPrefs.SetString("_rune_rare_" + i, _user_rune_db._rare[i]);
            PlayerPrefs.SetInt("_rune_lv_" + i, _user_rune_db._lv[i]);
            PlayerPrefs.SetString("_rune_hero_" + i, _user_rune_db._hero[i]);

            PlayerPrefs.SetString("_rune_m_stat_" + i, _user_rune_db._m_stat[i]);
            PlayerPrefs.SetString("_rune_1_d_stat_" + i, _user_rune_db._1_d_stat[i]);
            PlayerPrefs.SetString("_rune_2_d_stat_" + i, _user_rune_db._2_d_stat[i]);
            PlayerPrefs.SetString("_rune_3_d_stat_" + i, _user_rune_db._3_d_stat[i]);
            PlayerPrefs.SetString("_rune_4_d_stat_" + i, _user_rune_db._4_d_stat[i]);

            PlayerPrefs.SetInt("_rune_hp_m_" + i, _user_rune_db._hp_m[i]);
            PlayerPrefs.SetInt("_rune_hp_p_m_" + i, _user_rune_db._hp_p_m[i]);
            PlayerPrefs.SetInt("_rune_atk_m_" + i, _user_rune_db._atk_m[i]);
            PlayerPrefs.SetInt("_rune_atk_p_m_" + i, _user_rune_db._atk_p_m[i]);
            PlayerPrefs.SetInt("_rune_def_m_" + i, _user_rune_db._def_m[i]);
            PlayerPrefs.SetInt("_rune_def_p_m_" + i, _user_rune_db._def_p_m[i]);
            PlayerPrefs.SetInt("_rune_spd_m_" + i, _user_rune_db._spd_m[i]);
            PlayerPrefs.SetInt("_rune_crr_m_" + i, _user_rune_db._crr_m[i]);
            PlayerPrefs.SetInt("_rune_crd_m_" + i, _user_rune_db._crd_m[i]);
            PlayerPrefs.SetInt("_rune_acc_m_" + i, _user_rune_db._acc_m[i]);
            PlayerPrefs.SetInt("_rune_res_m_" + i, _user_rune_db._res_m[i]);

            PlayerPrefs.SetInt("_rune_hp_d_" + i, _user_rune_db._hp_d[i]);
            PlayerPrefs.SetInt("_rune_hp_p_d_" + i, _user_rune_db._hp_p_d[i]);
            PlayerPrefs.SetInt("_rune_atk_d_" + i, _user_rune_db._atk_d[i]);
            PlayerPrefs.SetInt("_rune_atk_p_d_" + i, _user_rune_db._atk_p_d[i]);
            PlayerPrefs.SetInt("_rune_def_d_" + i, _user_rune_db._def_d[i]);
            PlayerPrefs.SetInt("_rune_def_p_d_" + i, _user_rune_db._def_p_d[i]);
            PlayerPrefs.SetInt("_rune_spd_d_" + i, _user_rune_db._spd_d[i]);
            PlayerPrefs.SetInt("_rune_crr_d_" + i, _user_rune_db._crr_d[i]);
            PlayerPrefs.SetInt("_rune_crd_d_" + i, _user_rune_db._crd_d[i]);
            PlayerPrefs.SetInt("_rune_acc_d_" + i, _user_rune_db._acc_d[i]);
            PlayerPrefs.SetInt("_rune_res_d_" + i, _user_rune_db._res_d[i]);
        }
    }


    public void User_Rune_Db_Load()
    {
        _user_rune_db._count = PlayerPrefs.GetInt("_rune_count");

        for (int i = 0; i < _user_rune_db._count; i++)
        {
            _user_rune_db._id.Add(PlayerPrefs.GetInt("_rune_id_" + i));

            _user_rune_db._set.Add(PlayerPrefs.GetString("_rune_set_" + i));
            _user_rune_db._slot.Add(PlayerPrefs.GetInt("_rune_slot_" + i));
            _user_rune_db._star.Add(PlayerPrefs.GetInt("_rune_star_" + i));
            _user_rune_db._rare.Add(PlayerPrefs.GetString("_rune_rare_" + i));
            _user_rune_db._lv.Add(PlayerPrefs.GetInt("_rune_lv_" + i));
            _user_rune_db._hero.Add(PlayerPrefs.GetString("_rune_hero_" + i));

            _user_rune_db._m_stat.Add(PlayerPrefs.GetString("_rune_m_stat_" + i));
            _user_rune_db._1_d_stat.Add(PlayerPrefs.GetString("_rune_1_d_stat_" + i));
            _user_rune_db._2_d_stat.Add(PlayerPrefs.GetString("_rune_2_d_stat_" + i));
            _user_rune_db._3_d_stat.Add(PlayerPrefs.GetString("_rune_3_d_stat_" + i));
            _user_rune_db._4_d_stat.Add(PlayerPrefs.GetString("_rune_4_d_stat_" + i));

            _user_rune_db._hp_m.Add(PlayerPrefs.GetInt("_rune_hp_m_" + i));
            _user_rune_db._hp_p_m.Add(PlayerPrefs.GetInt("_rune_hp_p_m_" + i));
            _user_rune_db._atk_m.Add(PlayerPrefs.GetInt("_rune_atk_m_" + i));
            _user_rune_db._atk_p_m.Add(PlayerPrefs.GetInt("_rune_atk_p_m_" + i));
            _user_rune_db._def_m.Add(PlayerPrefs.GetInt("_rune_def_m_" + i));
            _user_rune_db._def_p_m.Add(PlayerPrefs.GetInt("_rune_def_p_m_" + i));
            _user_rune_db._spd_m.Add(PlayerPrefs.GetInt("_rune_spd_m_" + i));
            _user_rune_db._crr_m.Add(PlayerPrefs.GetInt("_rune_crr_m_" + i));
            _user_rune_db._crd_m.Add(PlayerPrefs.GetInt("_rune_crd_m_" + i));
            _user_rune_db._acc_m.Add(PlayerPrefs.GetInt("_rune_acc_m_" + i));
            _user_rune_db._res_m.Add(PlayerPrefs.GetInt("_rune_res_m_" + i));

            _user_rune_db._hp_d.Add(PlayerPrefs.GetInt("_rune_hp_d_" + i));
            _user_rune_db._hp_p_d.Add(PlayerPrefs.GetInt("_rune_hp_p_d_" + i));
            _user_rune_db._atk_d.Add(PlayerPrefs.GetInt("_rune_atk_d_" + i));
            _user_rune_db._atk_p_d.Add(PlayerPrefs.GetInt("_rune_atk_p_d_" + i));
            _user_rune_db._def_d.Add(PlayerPrefs.GetInt("_rune_def_d_" + i));
            _user_rune_db._def_p_d.Add(PlayerPrefs.GetInt("_rune_def_p_d_" + i));
            _user_rune_db._spd_d.Add(PlayerPrefs.GetInt("_rune_spd_d_" + i));
            _user_rune_db._crr_d.Add(PlayerPrefs.GetInt("_rune_crr_d_" + i));
            _user_rune_db._crd_d.Add(PlayerPrefs.GetInt("_rune_crd_d_" + i));
            _user_rune_db._acc_d.Add(PlayerPrefs.GetInt("_rune_acc_d_" + i));
            _user_rune_db._res_d.Add(PlayerPrefs.GetInt("_rune_res_d_" + i));
        }
    }


    public void User_Rune_Db_Reset()
    {
        PlayerPrefs.DeleteKey("_rune_count");

        for (int i = 0; i < _user_rune_db._count; i++)
        {
            PlayerPrefs.DeleteKey("_rune_id_" + i);

            PlayerPrefs.DeleteKey("_rune_set_" + i);
            PlayerPrefs.DeleteKey("_rune_slot_" + i);
            PlayerPrefs.DeleteKey("_rune_star_" + i);
            PlayerPrefs.DeleteKey("_rune_rare_" + i);
            PlayerPrefs.DeleteKey("_rune_lv_" + i);
            PlayerPrefs.DeleteKey("_rune_hero_" + i);

            PlayerPrefs.DeleteKey("_rune_m_stat_" + i);
            PlayerPrefs.DeleteKey("_rune_1_d_stat_" + i);
            PlayerPrefs.DeleteKey("_rune_2_d_stat_" + i);
            PlayerPrefs.DeleteKey("_rune_3_d_stat_" + i);
            PlayerPrefs.DeleteKey("_rune_4_d_stat_" + i);

            PlayerPrefs.DeleteKey("_rune_hp_m_" + i);
            PlayerPrefs.DeleteKey("_rune_hp_p_m_" + i);
            PlayerPrefs.DeleteKey("_rune_atk_m_" + i);
            PlayerPrefs.DeleteKey("_rune_atk_p_m_" + i);
            PlayerPrefs.DeleteKey("_rune_def_m_" + i);
            PlayerPrefs.DeleteKey("_rune_def_p_m_" + i);
            PlayerPrefs.DeleteKey("_rune_spd_m_" + i);
            PlayerPrefs.DeleteKey("_rune_crr_m_" + i);
            PlayerPrefs.DeleteKey("_rune_crd_m_" + i);
            PlayerPrefs.DeleteKey("_rune_acc_m_" + i);
            PlayerPrefs.DeleteKey("_rune_res_m_" + i);

            PlayerPrefs.DeleteKey("_rune_hp_d_" + i);
            PlayerPrefs.DeleteKey("_rune_hp_p_d_" + i);
            PlayerPrefs.DeleteKey("_rune_atk_d_" + i);
            PlayerPrefs.DeleteKey("_rune_atk_p_d_" + i);
            PlayerPrefs.DeleteKey("_rune_def_d_" + i);
            PlayerPrefs.DeleteKey("_rune_def_p_d_" + i);
            PlayerPrefs.DeleteKey("_rune_spd_d_" + i);
            PlayerPrefs.DeleteKey("_rune_crr_d_" + i);
            PlayerPrefs.DeleteKey("_rune_crd_d_" + i);
            PlayerPrefs.DeleteKey("_rune_acc_d_" + i);
            PlayerPrefs.DeleteKey("_rune_res_d_" + i);
        }
    }


    public void User_Rune_Db_Clear()
    {
        _user_rune_db._count = 0;

        _user_rune_db._id.Clear();

        _user_rune_db._set.Clear();
        _user_rune_db._slot.Clear();
        _user_rune_db._star.Clear();
        _user_rune_db._rare.Clear();
        _user_rune_db._lv.Clear();
        _user_rune_db._hero.Clear();

        _user_rune_db._m_stat.Clear();
        _user_rune_db._1_d_stat.Clear();
        _user_rune_db._2_d_stat.Clear();
        _user_rune_db._3_d_stat.Clear();
        _user_rune_db._4_d_stat.Clear();

        _user_rune_db._hp_m.Clear();
        _user_rune_db._hp_p_m.Clear();
        _user_rune_db._atk_m.Clear();
        _user_rune_db._atk_p_m.Clear();
        _user_rune_db._def_m.Clear();
        _user_rune_db._def_p_m.Clear();
        _user_rune_db._spd_m.Clear();
        _user_rune_db._crr_m.Clear();
        _user_rune_db._crd_m.Clear();
        _user_rune_db._acc_m.Clear();
        _user_rune_db._res_m.Clear();

        _user_rune_db._hp_d.Clear();
        _user_rune_db._hp_p_d.Clear();
        _user_rune_db._atk_d.Clear();
        _user_rune_db._atk_p_d.Clear();
        _user_rune_db._def_d.Clear();
        _user_rune_db._def_p_d.Clear();
        _user_rune_db._spd_d.Clear();
        _user_rune_db._crr_d.Clear();
        _user_rune_db._crd_d.Clear();
        _user_rune_db._acc_d.Clear();
        _user_rune_db._res_d.Clear();
    }
}
