using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class rune_slot_sc : MonoBehaviour
{
    public time_game_db_sc time_game_db;
    public user_rune_db_sc user_rune_db;
    public rune_db_sc rune_db;


    public Image _art;
    public Transform _star_cont;
    public TextMeshProUGUI _rune_lv_txt, _rune_slot_txt;
    public GameObject _ch_rune_pn;
    public int _rune_id, _uh_num;


    private void Awake()
    {
        _rune_id = time_game_db._ch_rune_id;
        name = "rune_" + _rune_id;
    }
    private void Start()
    {
        Visual_Load();
    }
    void Visual_Load()
    {
        Art_Load();
        Star_Load(user_rune_db._star[_rune_id - 1], _star_cont);
        Slot_Lv_Load();
    }
    void Art_Load()
    {
        string rare = user_rune_db._rare[_rune_id - 1];
        string set = user_rune_db._set[_rune_id - 1];
        int set_rare_num = rune_db._set_rare_name.IndexOf(set + "_" + rare) + 1;
        _art.sprite = rune_db._set_rare_art[set_rare_num - 1];
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
    public void Slot_Lv_Load()
    {
        int lv = user_rune_db._lv[_rune_id - 1];
        int slot = user_rune_db._slot[_rune_id - 1];
        _rune_lv_txt.text = "+" + lv;
        _rune_slot_txt.text = slot.ToString();
    }


    public void Rune_Slot_B()
    {
        GetComponent<Animation>().Play("click");

        time_game_db._ch_rune_id = _rune_id;
        GameObject pn = GameObject.Find("ch_rune_pn");

        if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id != _rune_id)
        {
            pn.GetComponent<ch_rune_pn_sc>().Cls();
            Instantiate(_ch_rune_pn, transform.parent.parent.parent.parent);
        }
        else if (pn == null)
        {
            Instantiate(_ch_rune_pn, transform.parent.parent.parent.parent);
        }
        else if (pn != null && pn.GetComponent<ch_rune_pn_sc>()._rune_id == _rune_id)
        {
            pn.GetComponent<ch_rune_pn_sc>().Cls();
        }
    }
}
