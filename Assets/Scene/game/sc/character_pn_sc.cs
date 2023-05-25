using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class character_pn_sc : MonoBehaviour
{
    public time_game_db_sc time_game_db;
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;
    public rune_db_sc rune_db;
    public user_rune_db_sc user_rune_db;
    public user_resource_db_sc user_resource_db;


    public rune_sc rune_sc;


    private void FixedUpdate()
    {
        Res_Load();
    }


    public TextMeshProUGUI _coin_txt;
    void Res_Load()
    {
        _coin_txt.text = user_resource_db._coin.ToString();
    }


    public GameObject _character_pn, _back_b;
    public void Character_Pn_Op_Cls(int v)
    {
        if (v == 1)
        {
            _character_pn.SetActive(true);
            _character_pn.GetComponent<Animation>().Play("slide_pn_op");
            Character_Pn_Load();
        }
        else if (v == 2)
        {
            _character_pn.GetComponent<Animation>().Play("slide_pn_cls");
            Invoke("Character_Pn_Off", 0.4f);
        }
    }
    public void Back_B()
    {
        _back_b.GetComponent<Animation>().Play("click");
        Character_Pn_Op_Cls(2);
    }
    void Character_Pn_Off()
    {
        _character_pn.SetActive(false);
    }


    public GameObject _hero_ico;
    public Transform _character_pn_all_hero_cont;
    public void Character_Pn_Load()
    {
        time_game_db._ch_hero_name = user_hero_db._name[0];

        Hero_Load();
        Character_Pn_All_Hero_Load();
    }
    void Character_Pn_All_Hero_Clear()
    {
        int count = _character_pn_all_hero_cont.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(_character_pn_all_hero_cont.GetChild(i).gameObject);
        }
    }
    void Character_Pn_All_Hero_Load()
    {
        Character_Pn_All_Hero_Clear();
        for (int i = 1; i <= user_hero_db._count; i++)
        {
            time_game_db._ico_hero_name = user_hero_db._name[i - 1];
            time_game_db._ico_hero_ally = true;
            Instantiate(_hero_ico, _character_pn_all_hero_cont);
        }
    }


    public Image _hero_art, _hero_model, _hero_rare;
    public TextMeshProUGUI _hero_name;
    void Hero_Load()
    {
        int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
        int h_num = hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;

        Hero_Visual_Load(uh_num, h_num);

        Hero_Inf_Har_Pn_B();
    }
    void Hero_Visual_Load(int uh_num, int h_num)
    {
        _hero_art.gameObject.SetActive(true);
        _hero_model.gameObject.SetActive(false);

        int rare_num = hero_db._rare_name.IndexOf(hero_db._rare[h_num - 1]) + 1;

        _hero_name.text = user_hero_db._name[uh_num - 1];

        _hero_art.sprite = hero_db._art[h_num - 1];
        _hero_model.sprite = hero_db._model[h_num - 1];
        _hero_rare.sprite = hero_db._rare_art[rare_num - 1];
    }


    void Any_Hero_Inf_Pn_Cls()
    {
        if (_hero_inf_har_pn.activeSelf == true)
        {
            _hero_inf_har_pn.GetComponent<Animation>().Play("push_pn_cls");
            Invoke("Hero_Inf_Har_Pn_Off", 0.3f);
        }
        if (_hero_inf_rune_pn.activeSelf == true)
        {
            _hero_inf_rune_pn.GetComponent<Animation>().Play("push_pn_cls");
            Invoke("Hero_Inf_Rune_Pn_Off", 0.3f);
        }
        if (_all_rune_pn.activeSelf == true)
        {
            _all_rune_pn.GetComponent<Animation>().Play("push_pn_cls");
            Invoke("All_Rune_Pn_Off", 0.3f);
            GameObject ch_rune_pn = GameObject.Find("ch_rune_pn");
            if (ch_rune_pn != null)
            {
                ch_rune_pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (_hero_inf_sk_pn.activeSelf == true)
        {
            _hero_inf_sk_pn.GetComponent<Animation>().Play("push_pn_cls");
            Invoke("Hero_Inf_Sk_Pn_Off", 0.3f);
            GameObject ch_sk_pn = GameObject.Find("ch_sk_pn");
            if (ch_sk_pn != null)
            {
                ch_sk_pn.GetComponent<ch_sk_pn_sc>().Cls();
            }
        }
    }
    void Hero_Inf_Har_Pn_Off()
    {
        _hero_inf_har_pn.SetActive(false);
    }
    void Hero_Inf_Rune_Pn_Off()
    {
        _hero_inf_rune_pn.SetActive(false);
    }
    void All_Rune_Pn_Off()
    {
        _all_rune_pn.SetActive(false);
    }
    void Hero_Inf_Sk_Pn_Off()
    {
        _hero_inf_sk_pn.SetActive(false);
    }


    public TextMeshProUGUI _lv_txt, _xp_txt, _har_1_txt, _har_2_txt;
    public GameObject _hero_inf_har_pn, _hero_inf_har_pn_b;
    public void Hero_Inf_Har_Pn_B()
    {
        _hero_inf_har_pn_b.GetComponent<Animation>().Play("click");
        if (_hero_inf_har_pn.activeSelf == false)
        {
            Any_Hero_Inf_Pn_Cls();
            _hero_inf_har_pn.SetActive(true);
            _hero_inf_har_pn.GetComponent<Animation>().Play("push_pn_op");

            int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            int h_num = hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            Hero_Inf_Har_Pn_Load(uh_num, h_num);
        }
    }
    void Hero_Inf_Har_Pn_Load(int uh_num, int h_num)
    {
        int lv = user_hero_db._lv[uh_num - 1];
        _lv_txt.text = "lv:" + lv;
        _xp_txt.text = "exp:" + user_hero_db._xp[uh_num - 1] + "|" + user_hero_db._xp_nd[uh_num - 1];

        List<int> rune_stat = rune_sc.Hero_Runes_Stat(uh_num);

        int b_hp = (hero_db._hp[h_num - 1] * (100 + 2 * lv)) / 100;
        int b_atk = (hero_db._atk[h_num - 1] * (100 + 2 * lv)) / 100;
        int b_def = (hero_db._def[h_num - 1] * (100 + 2 * lv)) / 100;
        int b_spd = hero_db._spd[h_num - 1];
        int b_crr = hero_db._crr[h_num - 1];
        int b_crd = hero_db._crd[h_num - 1];
        int b_acc = hero_db._acc[h_num - 1];
        int b_res = hero_db._res[h_num - 1];

        _har_1_txt.text = "hp:" + ((b_hp * (rune_stat[1] + 100))/100 + rune_stat[0]);
        _har_1_txt.text += "\natk:" + ((b_atk * (rune_stat[3] + 100))/ 100 + rune_stat[2]);
        _har_1_txt.text += "\ndef:" + ((b_def * (rune_stat[5] + 100))/ 100 + rune_stat[4]);
        _har_1_txt.text += "\nspd:" + (b_spd + rune_stat[6]);

        _har_2_txt.text = "crr:" + (b_crr + rune_stat[7]);
        _har_2_txt.text += "\ncrd:" + (b_crd + rune_stat[8]);
        _har_2_txt.text += "\nacc:" + (b_acc + rune_stat[9]);
        _har_2_txt.text += "\nres:" + (b_res + rune_stat[10]);
    }


    public Transform _hero_inf_sk_cont;
    public GameObject _sk_icon, _hero_inf_sk_pn, _hero_inf_sk_pn_b;
    public void Hero_Inf_Sk_Pn_B()
    {
        _hero_inf_sk_pn_b.GetComponent<Animation>().Play("click");

        if (_hero_inf_sk_pn.activeSelf == false)
        {
            Any_Hero_Inf_Pn_Cls();
            _hero_inf_sk_pn.SetActive(true);
            _hero_inf_sk_pn.GetComponent<Animation>().Play("push_pn_op");

            int h_num = hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            Hero_Inf_Sk_Pn_Load(h_num);
        }
    }
    void Hero_Inf_Sk_Pn_Load(int h_num)
    {
        Hero_Inf_Sk_Pn_Clear();

        for (int i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1: time_game_db._sk_type = "aa"; break;
                case 2: time_game_db._sk_type = "sk"; break;
                case 3: time_game_db._sk_type = "ul"; break;
                case 4: time_game_db._sk_type = "ps"; break;
            }
            Instantiate(_sk_icon, _hero_inf_sk_cont);
        }
    }
    void Hero_Inf_Sk_Pn_Clear()
    {
        int count = _hero_inf_sk_cont.childCount;
        for (int i = 1; i <= count; i++)
        {
            Destroy(_hero_inf_sk_cont.GetChild(i - 1).gameObject);
        }
    }


    public Transform _rune_1_stars, _rune_2_stars, _rune_3_stars, _rune_4_stars, _rune_5_stars, _rune_6_stars;
    public GameObject _rune_1_art, _rune_2_art, _rune_3_art, _rune_4_art, _rune_5_art, _rune_6_art;
    public GameObject _rune_1_plus, _rune_2_plus, _rune_3_plus, _rune_4_plus, _rune_5_plus, _rune_6_plus;
    public GameObject _hero_inf_rune_pn_b, _hero_inf_rune_pn;
    public TextMeshProUGUI _rune_1_lv_txt, _rune_2_lv_txt, _rune_3_lv_txt, _rune_4_lv_txt, _rune_5_lv_txt, _rune_6_lv_txt;
    public TextMeshProUGUI _rune_1_slot_txt, _rune_2_slot_txt, _rune_3_slot_txt, _rune_4_slot_txt, _rune_5_slot_txt, _rune_6_slot_txt;
    public TextMeshProUGUI _hero_rune_stat_1, _hero_rune_stat_2;
    public void Hero_Inf_Rune_Pn_B()
    {
        _hero_inf_rune_pn_b.GetComponent<Animation>().Play("click");

        if (_hero_inf_rune_pn.activeSelf == false)
        {
            Any_Hero_Inf_Pn_Cls();

            _hero_inf_rune_pn.SetActive(true);
            _hero_inf_rune_pn.GetComponent<Animation>().Play("push_pn_op");

            _all_rune_pn.SetActive(true);
            _all_rune_pn.GetComponent<Animation>().Play("push_pn_op");

            int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            Hero_Inf_Rune_Pn_Load(uh_num);
        }
    }
    public void Hero_Inf_Rune_Pn_Load(int uh_num)
    {
        Hero_Rune_Load(uh_num);
        Hero_Rune_Stat_Load(uh_num);
        All_Rune_Pn_Load();
    }
    public void Hero_Rune_Load(int uh_num)
    {
        int rune_1_id = user_hero_db._rune_1_id[uh_num - 1];
        int rune_2_id = user_hero_db._rune_2_id[uh_num - 1];
        int rune_3_id = user_hero_db._rune_3_id[uh_num - 1];
        int rune_4_id = user_hero_db._rune_4_id[uh_num - 1];
        int rune_5_id = user_hero_db._rune_5_id[uh_num - 1];
        int rune_6_id = user_hero_db._rune_6_id[uh_num - 1];

        string rare = "";
        string set = "";
        int set_rare_num = 0;
        int star = 0;

        if (rune_1_id != 0)
        {
            _rune_1_plus.SetActive(false);
            _rune_1_art.SetActive(true);
            _rune_1_lv_txt.gameObject.SetActive(true);
            _rune_1_stars.gameObject.SetActive(true);
            _rune_1_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_1_id - 1];
            set = user_rune_db._set[rune_1_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_1_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_1_id - 1];
            Star_Load(star, _rune_1_stars);

            _rune_1_lv_txt.text = "+" + user_rune_db._lv[rune_1_id - 1];
        }
        else if (rune_1_id == 0)
        {
            _rune_1_plus.SetActive(true);
            _rune_1_art.SetActive(false);
            _rune_1_lv_txt.gameObject.SetActive(false);
            _rune_1_stars.gameObject.SetActive(false);
            _rune_1_slot_txt.gameObject.SetActive(false);
        }

        if (rune_2_id != 0)
        {
            _rune_2_plus.SetActive(false);
            _rune_2_art.SetActive(true);
            _rune_2_lv_txt.gameObject.SetActive(true);
            _rune_2_stars.gameObject.SetActive(true);
            _rune_2_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_2_id - 1];
            set = user_rune_db._set[rune_2_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_2_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_2_id - 1];
            Star_Load(star, _rune_2_stars);

            _rune_2_lv_txt.text = "+" + user_rune_db._lv[rune_2_id - 1];
        }
        else if (rune_2_id == 0)
        {
            _rune_2_plus.SetActive(true);
            _rune_2_art.SetActive(false);
            _rune_2_lv_txt.gameObject.SetActive(false);
            _rune_2_stars.gameObject.SetActive(false);
            _rune_2_slot_txt.gameObject.SetActive(false);
        }

        if (rune_3_id != 0)
        {
            _rune_3_plus.SetActive(false);
            _rune_3_art.SetActive(true);
            _rune_3_lv_txt.gameObject.SetActive(true);
            _rune_3_stars.gameObject.SetActive(true);
            _rune_3_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_3_id - 1];
            set = user_rune_db._set[rune_3_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_3_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_3_id - 1];
            Star_Load(star, _rune_3_stars);

            _rune_3_lv_txt.text = "+" + user_rune_db._lv[rune_3_id - 1];
        }
        else if (rune_3_id == 0)
        {
            _rune_3_plus.SetActive(true);
            _rune_3_art.SetActive(false);
            _rune_3_lv_txt.gameObject.SetActive(false);
            _rune_3_stars.gameObject.SetActive(false);
            _rune_3_slot_txt.gameObject.SetActive(false);
        }

        if (rune_4_id != 0)
        {
            _rune_4_plus.SetActive(false);
            _rune_4_art.SetActive(true);
            _rune_4_lv_txt.gameObject.SetActive(true);
            _rune_4_stars.gameObject.SetActive(true);
            _rune_4_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_4_id - 1];
            set = user_rune_db._set[rune_4_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_4_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_4_id - 1];
            Star_Load(star, _rune_4_stars);

            _rune_4_lv_txt.text = "+" + user_rune_db._lv[rune_4_id - 1];
        }
        else if (rune_4_id == 0)
        {
            _rune_4_plus.SetActive(true);
            _rune_4_art.SetActive(false);
            _rune_4_lv_txt.gameObject.SetActive(false);
            _rune_4_stars.gameObject.SetActive(false);
            _rune_4_slot_txt.gameObject.SetActive(false);
        }

        if (rune_5_id != 0)
        {
            _rune_5_plus.SetActive(false);
            _rune_5_art.SetActive(true);
            _rune_5_lv_txt.gameObject.SetActive(true);
            _rune_5_stars.gameObject.SetActive(true);
            _rune_5_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_5_id - 1];
            set = user_rune_db._set[rune_5_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_5_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_5_id - 1];
            Star_Load(star, _rune_5_stars);

            _rune_5_lv_txt.text = "+" + user_rune_db._lv[rune_5_id - 1];
        }
        else if (rune_5_id == 0)
        {
            _rune_5_plus.SetActive(true);
            _rune_5_art.SetActive(false);
            _rune_5_lv_txt.gameObject.SetActive(false);
            _rune_5_stars.gameObject.SetActive(false);
            _rune_5_slot_txt.gameObject.SetActive(false);
        }

        if (rune_6_id != 0)
        {
            _rune_6_plus.SetActive(false);
            _rune_6_art.SetActive(true);
            _rune_6_lv_txt.gameObject.SetActive(true);
            _rune_6_stars.gameObject.SetActive(true);
            _rune_6_slot_txt.gameObject.SetActive(true);

            rare = user_rune_db._rare[rune_6_id - 1];
            set = user_rune_db._set[rune_6_id - 1];
            set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
            _rune_6_art.GetComponent<Image>().sprite = rune_db._set_rare_art[set_rare_num - 1];

            star = user_rune_db._star[rune_6_id - 1];
            Star_Load(star, _rune_6_stars);

            _rune_6_lv_txt.text = "+" + user_rune_db._lv[rune_6_id - 1];
        }
        else if (rune_6_id == 0)
        {
            _rune_6_plus.SetActive(true);
            _rune_6_art.SetActive(false);
            _rune_6_lv_txt.gameObject.SetActive(false);
            _rune_6_stars.gameObject.SetActive(false);
            _rune_6_slot_txt.gameObject.SetActive(false);
        }
    }
    void Star_Load(int star, Transform rune_stars)
    {
        for (int i = 0; i < rune_stars.childCount; i++)
        {
            rune_stars.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < star; i++)
        {
            rune_stars.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void Hero_Rune_Stat_Load(int uh_num)
    {
        List<int> stat_value = rune_sc.Hero_Runes_Stat(uh_num);

        _hero_rune_stat_1.text = "hp:" + stat_value[0] + "(" + stat_value[1] + "%)";
        _hero_rune_stat_1.text += "\natk:" + stat_value[2] + "(" + stat_value[3] + "%)";
        _hero_rune_stat_1.text += "\ndef:" + stat_value[4] + "(" + stat_value[5] + "%)";
        _hero_rune_stat_1.text += "\nspd:" + stat_value[6];

        _hero_rune_stat_2.text = "crr:" + stat_value[7];
        _hero_rune_stat_2.text += "\ncrd:" + stat_value[8];
        _hero_rune_stat_2.text += "\nacc:" + stat_value[9];
        _hero_rune_stat_2.text += "\nres:" + stat_value[10];
    }


    public GameObject _ch_rune_pn;
    public void Hero_Rune_B(int v)
    {
        GameObject pn = GameObject.Find("ch_rune_pn");
        int rune_id = 0;
        int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;

        if (v == 1)
        {
            rune_id = user_hero_db._rune_1_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (v == 2)
        {
            rune_id = user_hero_db._rune_2_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (v == 3)
        {
            rune_id = user_hero_db._rune_3_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (v == 4)
        {
            rune_id = user_hero_db._rune_4_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (v == 5)
        {
            rune_id = user_hero_db._rune_5_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
        if (v == 6)
        {
            rune_id = user_hero_db._rune_6_id[uh_num - 1];
            if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != rune_id && rune_id != 0)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn == null && rune_id != 0)
            {
                time_game_db._ch_rune_id = rune_id;
                Instantiate(_ch_rune_pn, _character_pn.transform);
            }
            else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == rune_id)
            {
                pn.GetComponent<ch_rune_pn_sc>().Cls();
            }
        }
    }


    public GameObject _rune_slot, _all_rune_pn;
    public Transform _all_rune_cont;
    public void All_Rune_Pn_Load()
    {
        All_Rune_Pn_Clear();
        for (int i = 0; i < user_rune_db._count; i++)
        {
            if (user_rune_db._hero[i] == "No")
            {
                time_game_db._ch_rune_id = user_rune_db._id[i];
                Instantiate(_rune_slot, _all_rune_cont);
            }
        }
    }
    void All_Rune_Pn_Clear()
    {
        int count = _all_rune_cont.childCount;
        for (int i = 1; i <= count; i++)
        {
            Destroy(_all_rune_cont.GetChild(i - 1).gameObject);
        }
    }
}
