using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class hero_ico_sc : MonoBehaviour
{
    public time_game_db_sc time_game_db;
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;
    public story_db_sc story_db;

    public story_pn_sc story_pn_sc;


    public List<string> _bg_name = new();
    public List<Sprite> _bg_sprite = new();

    public string _name, _rare;
    public int _h_num, _uh_num;
    int _star_count, _ev_star_count;
    public bool _ally;

    public Sprite _ev_star, _star;
    public Image _bg, _art, _star_1, _star_2, _star_3, _star_4, _star_5;
    public TextMeshProUGUI _lv_txt;
    public GameObject _star_pn;

    private void Awake()
    {
        _name = time_game_db._ico_hero_name;
        _ally = time_game_db._ico_hero_ally;
    }
    private void Start()
    {
        story_pn_sc = GameObject.Find("story_pn_sc").GetComponent<story_pn_sc>();

        Har_Load();

        Art_Bg_Load();
        Star_Load();
        Visual_Load();
    }


    void Har_Load()
    {
        _h_num = hero_db._name.IndexOf(_name) + 1;
        _rare = hero_db._rare[_h_num - 1];

        if (_ally == true)
        {
            _uh_num = user_hero_db._name.IndexOf(_name) + 1;
            _star_count = user_hero_db._star[_uh_num - 1];
            _ev_star_count = user_hero_db._ev_star[_uh_num - 1];
        }
    }
    void Visual_Load()
    {
        if (_ally == true)
        {
            _lv_txt.text = user_hero_db._lv[_uh_num - 1] + "";
        }

        if (_ally == false)
        {
            _star_pn.SetActive(false);
            int part_num = story_db._part.IndexOf(time_game_db._ch_part) + 1;
            _lv_txt.text = story_db._part_enemy_lv[part_num - 1] + "";
        }
    }
        
    void Art_Bg_Load()
    {
        _art.sprite = hero_db._ico[_h_num - 1];
        _bg.sprite = _bg_sprite[_bg_name.IndexOf(_rare)];
    }
    void Star_Load()
    {
        _star_1.gameObject.SetActive(true);
        _star_2.gameObject.SetActive(false);
        _star_3.gameObject.SetActive(false);
        _star_4.gameObject.SetActive(false);
        _star_5.gameObject.SetActive(false);

        switch (_star_count)
        {
            case 2:
                _star_2.gameObject.SetActive(true);
                break;
            case 3:
                _star_2.gameObject.SetActive(true);
                _star_3.gameObject.SetActive(true);
                break;
            case 4:
                _star_2.gameObject.SetActive(true);
                _star_3.gameObject.SetActive(true);
                _star_4.gameObject.SetActive(true);
                break;
            case 5:
                _star_2.gameObject.SetActive(true);
                _star_3.gameObject.SetActive(true);
                _star_4.gameObject.SetActive(true);
                _star_5.gameObject.SetActive(true);
                break;
        }
        switch (_ev_star_count)
        {
            case 1:
                _star_1.sprite = _ev_star;
                break;
            case 2:
                _star_1.sprite = _ev_star;
                _star_2.sprite = _ev_star;
                break;
            case 3:
                _star_1.sprite = _ev_star;
                _star_3.sprite = _ev_star;
                _star_4.sprite = _ev_star;
                break;
            case 4:
                _star_1.sprite = _ev_star;
                _star_2.sprite = _ev_star;
                _star_3.sprite = _ev_star;
                _star_4.sprite = _ev_star;
                break;
            case 5:
                _star_1.sprite = _ev_star;
                _star_2.sprite = _ev_star;
                _star_3.sprite = _ev_star;
                _star_4.sprite = _ev_star;
                _star_5.sprite = _ev_star;
                break;
        }
    }


    public void Hero_Ico_B()
    {
        gameObject.GetComponent<Animation>().Play("click");

        if (_ally == true)
        {
            if (transform.parent.name == "pre_fight_all_hero_cont" || transform.parent.name == "ally_team_cont")
            {
                Hero_Team_Add_Del();
                story_pn_sc.Hero_Paty_Slot_Part_Pn_Update();
            }
        }
    }
    void Hero_Team_Add_Del()
    {
        if (user_hero_db._team.Contains(_name) == false)
        {
            if (user_hero_db._team.Contains("No") == true)
            {
                int num = user_hero_db._team.IndexOf("No") + 1;
                user_hero_db._team[num - 1] = _name;
            }
        }
        else if (user_hero_db._team.Contains(_name) == true)
        {
            int num = user_hero_db._team.IndexOf(_name) + 1;
            user_hero_db._team[num - 1] = "No";
        }
    }
}
