using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class title_sc : MonoBehaviour
{
    public user_resource_db_sc _user_resource_db;
    public user_hero_db_sc _user_hero_db;

    public user_resource_db_save_sc _user_resource_db_save_sc;
    public user_rune_db_save_sc _user_rune_db_save_sc;
    public user_hero_db_save_sc _user_hero_db_save_sc;

    public summon_pn_sc _summon_pn_sc;

    private void Start()
    {
        _user_resource_db_save_sc.User_Resource_Db_Clear();
        _user_resource_db_save_sc.User_Resource_Db_Load();

        _user_hero_db_save_sc.User_Hero_Db_Clear();
        _user_hero_db_save_sc.User_Hero_Db_Load();

        _user_rune_db_save_sc.User_Rune_Db_Clear();
        _user_rune_db_save_sc.User_Rune_Db_Load();
    }


    public GameObject _setting_pn, _setting_b;
    public void Setting_B()
    {
        if (_setting_pn.activeSelf ==  false)
        {
            _setting_pn.SetActive(true);
            _setting_pn.GetComponent<Animation>().Play("setting_pn_op");
        }
        else if (_setting_pn.activeSelf == true)
        {
            _setting_pn.GetComponent<Animation>().Play("setting_pn_cls");
            Invoke("Setting_Pn_Off",0.35f);
        }
    }
    void Setting_Pn_Off()
    {
        _setting_pn.SetActive(false);
    }


    public GameObject _reset_acc_pn, _reset_acc_yes_b, _reset_acc_no_b;
    public void Reset_Acc_B()
    {
        if (_reset_acc_pn.activeSelf == false)
        {
            _reset_acc_pn.SetActive(true);
            _reset_acc_pn.GetComponent<Animation>().Play("push_pn_op");
        }
        else if (_reset_acc_pn.activeSelf == true)
        {
            _reset_acc_pn.GetComponent<Animation>().Play("push_pn_cls");
            Invoke("Del_Acc_Pn_Off", 0.3f);
        }
    }
    public void Reset_Acc_Yes_B()
    {
        _reset_acc_yes_b.GetComponent<Animation>().Play("click");

        _user_resource_db_save_sc.User_Resource_Db_Reset();
        _user_resource_db_save_sc.User_Resource_Db_Clear();

        _user_rune_db_save_sc.User_Rune_Db_Reset();
        _user_rune_db_save_sc.User_Rune_Db_Clear();

        _user_hero_db_save_sc.User_Hero_Db_Reset();
        _user_hero_db_save_sc.User_Hero_Db_Clear();

        _reset_acc_pn.GetComponent<Animation>().Play("push_pn_cls");
        Invoke("Reset_Acc_Pn_Off", 0.3f);
        Invoke("Reset_Title", 0.4f);
    }
    void Reset_Title()
    {
        SceneManager.LoadScene("title");
    }
    public void Reset_Acc_No_B()
    {
        _reset_acc_no_b.GetComponent<Animation>().Play("click");
        _reset_acc_pn.GetComponent<Animation>().Play("push_pn_cls");
        Invoke("Reset_Acc_Pn_Off", 0.3f);
    }
    void Reset_Acc_Pn_Off()
    {
        _reset_acc_pn.SetActive(false);
    }


    public GameObject _play_b, _exit_b, _new_user_name_pn, _new_user_name_enter_b;
    public TextMeshProUGUI _new_user_name;

    public void Play_B()
    {
        _play_b.GetComponent<Animation>().Play("click");
        if (_user_resource_db._user_name.Length < 3)
        {
            New_User_Name_Pn_Op();
        }
        else if (_user_resource_db._user_name.Length >= 3)
        {
            Load_Game();
        }
    }
    void New_User_Name_Pn_Op()
    {
        _new_user_name_pn.SetActive(true);
        _new_user_name_pn.GetComponent<Animation>().Play("push_pn_op");
        _new_user_name.text = "";
    }
    public void New_User_Name_Enter_B()
    {
        _new_user_name_enter_b.GetComponent<Animation>().Play("click");
        if (_new_user_name.text.Length < 3)
        {
            _new_user_name_enter_b.GetComponent<Animation>().Play("warning");
        }
        else if (_new_user_name.text.Length >= 3)
        {
            _user_resource_db._user_name = _new_user_name.text;
            Start_Game_Resource();

            Invoke("Load_Game", 0.1f);
        }
    }
    void Start_Game_Resource()
    {
        _user_hero_db._count++;
        _summon_pn_sc.Add_Hero("Naruto [Genin]");
        _user_hero_db_save_sc.User_Hero_Db_Save();

        _user_resource_db._energy = _user_resource_db._energy_mx = 30;
        _user_resource_db_save_sc.User_Resource_Db_Save();
    }
    void Load_Game()
    {
        SceneManager.LoadScene("game");
    }
    public void Exit_B()
    {
        _exit_b.GetComponent<Animation>().Play("click");
        Application.Quit();
    }
}
