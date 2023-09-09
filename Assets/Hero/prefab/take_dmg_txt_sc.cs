using UnityEngine;
using TMPro;

public class take_dmg_txt_sc : MonoBehaviour
{
    public fight_db_sc fight_db;

    public TextMeshProUGUI _txt;

    public void Spawn_Setting(int dmg)
    {
        _txt.text = dmg + "";
    }
    public void Del()
    {
        Destroy(gameObject);
    }
}
