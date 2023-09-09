using UnityEngine;
using TMPro;

public class sk_inf_pn_sc : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _sk_name_txt;
    [SerializeField] TextMeshProUGUI _sk_inf_txt;
    string _sk_name;


    public void Spawn_Setting(string sk_name)
    {
        _sk_name = sk_name;
        gameObject.name = "sk_inf_pn";
        Load_Inf();
    }
    void Load_Inf()
    {
        _sk_name_txt.text = _sk_name;
        _sk_inf_txt.text = sk_inf_sc.Sk_Inf(_sk_name);
    }
}
