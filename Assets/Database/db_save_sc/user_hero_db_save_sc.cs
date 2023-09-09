using UnityEngine;

public class user_hero_db_save_sc : MonoBehaviour
{
    public user_hero_db_sc _user_hero_db;


    public void User_Hero_Db_Save()
    {
        PlayerPrefs.SetInt("_hero_count", _user_hero_db._count);

        for (int i = 0; i < _user_hero_db._count; i++)
        {
            PlayerPrefs.SetString("_hero_name_" + i, _user_hero_db._name[i]);

            PlayerPrefs.SetInt("_hero_dubl_" + i, _user_hero_db._dubl[i]);

            PlayerPrefs.SetInt("_hero_star_" + i, _user_hero_db._star[i]);
            PlayerPrefs.SetInt("_hero_ev_star_" + i, _user_hero_db._ev_star[i]);
            PlayerPrefs.SetInt("_hero_lv_" + i, _user_hero_db._lv[i]);
            PlayerPrefs.SetInt("_hero_xp_" + i, _user_hero_db._xp[i]);
            PlayerPrefs.SetInt("_hero_xp_nd_" + i, _user_hero_db._xp_nd[i]);

            PlayerPrefs.SetInt("_hero_rune_1_id_" + i, _user_hero_db._rune_1_id[i]);
            PlayerPrefs.SetInt("_hero_rune_2_id_" + i, _user_hero_db._rune_2_id[i]);
            PlayerPrefs.SetInt("_hero_rune_3_id_" + i, _user_hero_db._rune_3_id[i]);
            PlayerPrefs.SetInt("_hero_rune_4_id_" + i, _user_hero_db._rune_4_id[i]);
            PlayerPrefs.SetInt("_hero_rune_5_id_" + i, _user_hero_db._rune_5_id[i]);
            PlayerPrefs.SetInt("_hero_rune_6_id_" + i, _user_hero_db._rune_6_id[i]);

            PlayerPrefs.SetInt("_hero_aa_lv_" + i, _user_hero_db._aa_lv[i]);
            PlayerPrefs.SetInt("_hero_sk_lv_" + i, _user_hero_db._sk_lv[i]);
            PlayerPrefs.SetInt("_hero_ul_lv_" + i, _user_hero_db._ul_lv[i]);
            PlayerPrefs.SetInt("_hero_ps_lv_" + i, _user_hero_db._ps_lv[i]);
        }
    }


    public void User_Hero_Db_Load()
    {
        _user_hero_db._count = PlayerPrefs.GetInt("_hero_count");
        for (int i = 0; i < _user_hero_db._count; i++)
        {
            _user_hero_db._name.Add(PlayerPrefs.GetString("_hero_name_" + i));

            _user_hero_db._dubl.Add(PlayerPrefs.GetInt("_hero_dubl_" + i));

            _user_hero_db._star.Add(PlayerPrefs.GetInt("_hero_star_" + i));
            _user_hero_db._ev_star.Add(PlayerPrefs.GetInt("_hero_ev_star_" + i));
            _user_hero_db._lv.Add(PlayerPrefs.GetInt("_hero_lv_" + i));
            _user_hero_db._xp.Add(PlayerPrefs.GetInt("_hero_xp_" + i));
            _user_hero_db._xp_nd.Add(PlayerPrefs.GetInt("_hero_xp_nd_" + i));

            _user_hero_db._rune_1_id.Add(PlayerPrefs.GetInt("_hero_rune_1_id_" + i));
            _user_hero_db._rune_2_id.Add(PlayerPrefs.GetInt("_hero_rune_2_id_" + i));
            _user_hero_db._rune_3_id.Add(PlayerPrefs.GetInt("_hero_rune_3_id_" + i));
            _user_hero_db._rune_4_id.Add(PlayerPrefs.GetInt("_hero_rune_4_id_" + i));
            _user_hero_db._rune_5_id.Add(PlayerPrefs.GetInt("_hero_rune_5_id_" + i));
            _user_hero_db._rune_6_id.Add(PlayerPrefs.GetInt("_hero_rune_6_id_" + i));

            _user_hero_db._aa_lv.Add(PlayerPrefs.GetInt("_hero_aa_lv_" + i));
            _user_hero_db._sk_lv.Add(PlayerPrefs.GetInt("_hero_sk_lv_" + i));
            _user_hero_db._ul_lv.Add(PlayerPrefs.GetInt("_hero_ul_lv_" + i));
            _user_hero_db._ps_lv.Add(PlayerPrefs.GetInt("_hero_ps_lv_" + i));
        }
    }


    public  void User_Hero_Db_Reset()
    {
        PlayerPrefs.DeleteKey("_hero_count");

        for (int i = 0; i < _user_hero_db._count; i++)
        {
            PlayerPrefs.DeleteKey("_hero_name_" + i);

            PlayerPrefs.DeleteKey("_hero_dubl_" + i);

            PlayerPrefs.DeleteKey("_hero_star_" + i);
            PlayerPrefs.DeleteKey("_hero_ev_star_" + i);
            PlayerPrefs.DeleteKey("_hero_lv_" + i);
            PlayerPrefs.DeleteKey("_hero_xp_" + i);
            PlayerPrefs.DeleteKey("_hero_xp_nd_" + i);

            PlayerPrefs.DeleteKey("_hero_rune_1_id_" + i);
            PlayerPrefs.DeleteKey("_hero_rune_2_id_" + i);
            PlayerPrefs.DeleteKey("_hero_rune_3_id_" + i);
            PlayerPrefs.DeleteKey("_hero_rune_4_id_" + i);
            PlayerPrefs.DeleteKey("_hero_rune_5_id_" + i);
            PlayerPrefs.DeleteKey("_hero_rune_6_id_" + i);

            PlayerPrefs.DeleteKey("_hero_aa_lv_" + i);
            PlayerPrefs.DeleteKey("_hero_sk_lv_" + i);
            PlayerPrefs.DeleteKey("_hero_ul_lv_" + i);
            PlayerPrefs.DeleteKey("_hero_ps_lv_" + i);
        }
    }


    public void User_Hero_Db_Clear()
    {
        _user_hero_db._count = 0;

        _user_hero_db._name.Clear();

        _user_hero_db._dubl.Clear();

        _user_hero_db._star.Clear();
        _user_hero_db._ev_star.Clear();
        _user_hero_db._lv.Clear();
        _user_hero_db._xp.Clear();
        _user_hero_db._xp_nd.Clear();

        _user_hero_db._rune_1_id.Clear();
        _user_hero_db._rune_2_id.Clear();
        _user_hero_db._rune_3_id.Clear();
        _user_hero_db._rune_4_id.Clear();
        _user_hero_db._rune_5_id.Clear();
        _user_hero_db._rune_6_id.Clear();

        _user_hero_db._aa_lv.Clear();
        _user_hero_db._sk_lv.Clear();
        _user_hero_db._ul_lv.Clear();
        _user_hero_db._ps_lv.Clear();
    }
}
