using UnityEngine;
using TMPro;

public class game_sc : MonoBehaviour
{
    public user_resource_db_sc user_resource_db;


    private void FixedUpdate()
    {
        Resources_Visual_Update();
    }


    public TextMeshProUGUI _money, _gold, _coin, _energy;
    void Resources_Visual_Update()
    {
        _money.text = user_resource_db._money.ToString();
        _gold.text = user_resource_db._gold.ToString();
        _coin.text = user_resource_db._coin.ToString();
        _energy.text = user_resource_db._energy + " | " + user_resource_db._energy_mx;
    }
}
