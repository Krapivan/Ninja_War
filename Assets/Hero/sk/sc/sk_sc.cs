using UnityEngine;

public class sk_sc : MonoBehaviour
{
    public void Sk_Use( hero_slot_sc user_sc, hero_slot_sc aim_sc)
    {
        if (user_sc._hero_name == "Naruto [Genin]")
        {
            Naruto_Genin_sc naruto_genin_sc = new();
            naruto_genin_sc.Sk(user_sc, aim_sc);
        }
    }
}
