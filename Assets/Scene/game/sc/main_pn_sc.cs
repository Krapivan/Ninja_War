using UnityEngine;

public class main_pn_sc : MonoBehaviour
{
    public character_pn_sc character_pn_sc;
    public story_pn_sc story_pn_sc;


    public GameObject _character_pn_b;
    public void Character_Pn_B()
    {
        _character_pn_b.GetComponent<Animation>().Play("click");
        character_pn_sc.Character_Pn_Op_Cls(1);
    }


    public GameObject _story_pn_b;
    public void Story_Pn_B()
    {
        _story_pn_b.GetComponent<Animation>().Play("click");
        story_pn_sc.Story_Pn_Op_Cls(1);
    }
}
