using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "db/hero_db")]
public class hero_db_sc : ScriptableObject
{
    //hero
    public List <string> _name = new();

    public List<Sprite> _art = new();
    public List<Sprite> _ico = new();
    public List<Sprite> _model = new();
    public List<RuntimeAnimatorController> anim_con = new();

    public List<string> _el = new();
    public List<string> _type = new();
    public List<string> _rare = new();

    public List<int> _hp = new();
    public List<int> _atk = new();
    public List<int> _def = new();
    public List<int> _spd = new();
    public List<int> _crr = new();
    public List<int> _crd = new();
    public List<int> _acc = new();
    public List<int> _res = new();

    public List<string> _aa_name = new();
    public List<string> _sk_name = new();
    public List<string> _ul_name = new();
    public List<string> _ps_name = new();

    public List<Sprite> _aa_art = new();
    public List<Sprite> _sk_art = new();
    public List<Sprite> _ul_art = new();
    public List<Sprite> _ps_art = new();

    public List<int> _aa_cd = new();
    public List<int> _sk_cd = new();
    public List<int> _ul_cd = new();
    public List<int> _ps_cd = new();

    public List<int> _aa_pcd = new();
    public List<int> _sk_pcd = new();
    public List<int> _ul_pcd = new();
    public List<int> _ps_pcd = new();

    public List<string> _aa_el = new();
    public List<string> _sk_el = new();
    public List<string> _ul_el = new();
    public List<string> _ps_el = new();


    //res
    public List<string> _rare_name = new();
    public List<Sprite> _rare_art = new();
}
