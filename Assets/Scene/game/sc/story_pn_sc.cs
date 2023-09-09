using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story_pn_sc : MonoBehaviour
{
    public user_resource_db_sc user_resource_db;
    public user_hero_db_sc user_hero_db;
    public time_game_db_sc time_game_db;
    public fight_db_sc fight_db;
    public story_db_sc story_db;


    private void FixedUpdate()
    {
        Energy_Load();
    }
    public TextMeshProUGUI _energy_txt;
    void Energy_Load()
    {
        _energy_txt.text = user_resource_db._energy + " | " + user_resource_db._energy_mx;
    }


    public GameObject _story_pn, _story_pn_back_b;
    public void Story_Pn_Op_Cls(int v)
    {
        if (v == 1)
        {
            _story_pn.SetActive(true);
            _story_pn.GetComponent<Animation>().Play("slide_pn_op");
            Story_Pn_Load();
        }
        else if (v == 2)
        {
            _story_pn.GetComponent<Animation>().Play("slide_pn_cls");
            Invoke("Story_Pn_Off", 0.4f);
        }
    }
    void Story_Pn_Off(int h)
    {
        _story_pn.SetActive(false);
    }
    public void Story_Pn_Back_B()
    {
        _story_pn_back_b.GetComponent<Animation>().Play("click");
        Story_Pn_Op_Cls(2);
    }


    public TextMeshProUGUI _chapter_name;
    void Story_Pn_Load()
    {
        string ch_chapter = time_game_db._ch_chapter;
        if (ch_chapter == "" || ch_chapter == null)
        {
            ch_chapter = story_db._chapter[0];
            time_game_db._ch_chapter = ch_chapter;
        }
        int chapter_num = story_db._chapter.IndexOf(ch_chapter) + 1;

        _chapter_name.text = ch_chapter;
        Story_Part_Point_Load();
    }

    public GameObject _part_point_1, _part_point_2, _part_point_3, _part_point_4, _part_point_5, _part_point_6, _part_point_7;
    void Story_Part_Point_Load()
    {
        int chapter_num = story_db._chapter.IndexOf(time_game_db._ch_chapter) + 1;

        _part_point_1.GetComponent<Button>().interactable = false;
        _part_point_2.GetComponent<Button>().interactable = false;
        _part_point_3.GetComponent<Button>().interactable = false;
        _part_point_4.GetComponent<Button>().interactable = false;
        _part_point_5.GetComponent<Button>().interactable = false;
        _part_point_6.GetComponent<Button>().interactable = false;
        _part_point_7.GetComponent<Button>().interactable = false;

        int chpater_m = (chapter_num - 1) * 7;
        int anim_part_num = story_db._part_comp.LastIndexOf(1) + 2;

        //point 1
        _part_point_1.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 1 - 1];
        if (story_db._part_comp[chpater_m] == 1)
        {
            _part_point_1.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 1 == anim_part_num)
        {
            _part_point_1.GetComponent<Button>().interactable = true;
            _part_point_1.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 2
        _part_point_2.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 2 - 1];
        if (story_db._part_comp[chpater_m + 2 - 1] == 1)
        {
            _part_point_2.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 2 == anim_part_num)
        {
            _part_point_2.GetComponent<Button>().interactable = true;
            _part_point_2.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 3
        _part_point_3.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 3 - 1];
        if (story_db._part_comp[chpater_m + 3 - 1] == 1)
        {
            _part_point_3.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 3 == anim_part_num)
        {
            _part_point_3.GetComponent<Button>().interactable = true;
            _part_point_3.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 4
        _part_point_4.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 4 - 1];
        if (story_db._part_comp[chpater_m + 4 - 1] == 1)
        {
            _part_point_4.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 4 == anim_part_num)
        {
            _part_point_4.GetComponent<Button>().interactable = true;
            _part_point_4.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 5
        _part_point_5.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 5 - 1];
        if (story_db._part_comp[chpater_m + 5 - 1] == 1)
        {
            _part_point_5.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 5 == anim_part_num)
        {
            _part_point_5.GetComponent<Button>().interactable = true;
            _part_point_5.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 6
        _part_point_6.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 6 - 1];
        if (story_db._part_comp[chpater_m + 6 - 1] == 1)
        {
            _part_point_6.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 6 == anim_part_num)
        {
            _part_point_6.GetComponent<Button>().interactable = true;
            _part_point_6.GetComponent<Animation>().Play("part_point_idle");
        }
        //point 7
        _part_point_7.GetComponent<Image>().sprite = story_db._part_point_art[chpater_m + 7 - 1];
        if (story_db._part_comp[chpater_m + 7 - 1] == 1)
        {
            _part_point_7.GetComponent<Button>().interactable = true;
        }
        if (chpater_m + 7 == anim_part_num)
        {
            _part_point_7.GetComponent<Button>().interactable = true;
            _part_point_7.GetComponent<Animation>().Play("part_point_idle");
        }
    }


    public GameObject _part_pn, _part_pn_back_b;
    public TextMeshProUGUI _part_name;
    public void Part_Pn_Op_Cls(int v)
    {
        if (v == 1)
        {
            _part_pn.SetActive(true);
            _part_pn.GetComponent<Animation>().Play("part_pn_op");
            Part_Pn_Load();
        }
        else if (v == 2)
        {
            _part_pn.GetComponent<Animation>().Play("part_pn_cls");
            Invoke("Part_Pn_Off", 0.4f);
        }
    }
    public void Part_Pn_Back_B()
    {
        _part_pn_back_b.GetComponent<Animation>().Play("click");
        Part_Pn_Op_Cls(2);
    }
    void Part_Pn_Off()
    {
        _part_pn.SetActive(false);
    }


    void Part_Pn_Load()
    {
        _part_name.text = time_game_db._ch_part;

        Part_Visual_Load();
    }

    public void Hero_Paty_Slot_Part_Pn_Update()
    {
        Part_Ally_Team_Visual_Load();
        Part_All_Hero_Load();
    }
    void Part_Visual_Load()
    {
        if (time_game_db._ch_team_preset == 0)
        {
            time_game_db._ch_team_preset = 1;
        }
        Now_Team_Instal();
        Part_Ally_Team_Visual_Load();

        Part_All_Hero_Load();

        Part_Enemy_Team_Visual_Load();
    }
    void Now_Team_Instal()
    {
        int ctp_num = time_game_db._ch_team_preset;
        for (int i = 0; i < 5; i++)
        {
            user_hero_db._team[i] = user_hero_db._team_preset[(ctp_num - 1) * 5 + i];
        }
    }


    public Transform _enemy_team_cont;
    void Part_Enemy_Team_Visual_Clear()
    {
        int c = _enemy_team_cont.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_enemy_team_cont.GetChild(i).gameObject);
        }
    }
    void Part_Enemy_Team_Visual_Load()
    {
        Part_Enemy_Team_Visual_Clear();
        int part_num = story_db._part.IndexOf(time_game_db._ch_part) + 1;
        for (int i = 0; i < 5; i++)
        {
            if (story_db._part_enemy[(part_num - 1) * 5 + i] != "No")
            {
                time_game_db._ico_hero_name = story_db._part_enemy[(part_num - 1) * 5 + i];
                time_game_db._ico_hero_ally = false;
                Instantiate(_hero_party_slot, _enemy_team_cont);
            }
        }
    }


    public Transform _ally_team_cont;
    public GameObject _hero_party_slot;
    void Part_Ally_Team_Visual_Clear()
    {
        int c = _ally_team_cont.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_ally_team_cont.GetChild(i).gameObject);
        }
    }
    void Part_Ally_Team_Visual_Load()
    {
        Part_Ally_Team_Visual_Clear();
        for (int i = 0; i < 5; i++)
        {
            if (user_hero_db._team[i] != "No")
            {
                time_game_db._ico_hero_name = user_hero_db._team[i];
                time_game_db._ico_hero_ally = true;
                Instantiate(_hero_party_slot, _ally_team_cont);
            }
        }
    }


    public Transform _all_hero_cont;
    void Part_All_Hero_Clear()
    {
        int c = _all_hero_cont.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_all_hero_cont.GetChild(i).gameObject);
        }
    }
    void Part_All_Hero_Load()
    {
        Part_All_Hero_Clear();
        string hero_name;
        for (int i = 0; i < user_hero_db._name.Count; i++)
        {
            hero_name = user_hero_db._name[i];
            if (user_hero_db._team.Contains(hero_name) == false)
            {
                time_game_db._ico_hero_name = hero_name;
                time_game_db._ico_hero_ally = true;
                Instantiate(_hero_party_slot ,_all_hero_cont);
            }
        }
    }


    public void Story_Part_Point_B(int v)
    {
        switch (v)
        {
            case 1: _part_point_1.GetComponent<Animation>().Play("click"); break;
            case 2: _part_point_2.GetComponent<Animation>().Play("click"); break;
            case 3: _part_point_3.GetComponent<Animation>().Play("click"); break;
            case 4: _part_point_4.GetComponent<Animation>().Play("click"); break;
            case 5: _part_point_5.GetComponent<Animation>().Play("click"); break;
            case 6: _part_point_6.GetComponent<Animation>().Play("click"); break;
            case 7: _part_point_7.GetComponent<Animation>().Play("click"); break;
        }
        int chapter_num = story_db._chapter.IndexOf(time_game_db._ch_chapter) + 1;
        time_game_db._ch_part = story_db._part[(chapter_num - 1) * 7 + v - 1];
        Part_Pn_Op_Cls(1);
    }


    public GameObject _part_start_b;
    public void Start_Part_B()
    {
        _part_start_b.GetComponent<Animation>().Play("click");
        if (_ally_team_cont.childCount > 0)
        {
            SceneManager.LoadScene("story_fight");
        }
    }
}
