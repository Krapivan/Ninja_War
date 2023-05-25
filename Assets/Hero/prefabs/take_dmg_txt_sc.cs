using UnityEngine;
using TMPro;

public class take_dmg_txt_sc : MonoBehaviour
{
    public fight_db_sc fight_db;

    public TextMeshProUGUI _txt;
    public int _dmg;


    private void Awake()
    {
        _dmg = fight_db._take_dmg_txt;
    }
    private void Start()
    {
        _txt.text = _dmg + "";
    }


    public void Del()
    {
        Destroy(gameObject);
    }
}
