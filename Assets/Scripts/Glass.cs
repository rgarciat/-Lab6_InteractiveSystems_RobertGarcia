using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glass : MonoBehaviour
{
    public static Glass glass;
    public Text whatGlassHave;


    void Awake()
    {
        glass = this;

        whatGlassHave.text = "Nothing";
    }

    // Called to fill the glass with new ingredients
    public void UpdateGlass(Text ingredient)
    {
        if (whatGlassHave.text == "Nothing")
        {
            whatGlassHave.text = ingredient.text;
        }
        else if (whatGlassHave.text.IndexOf(ingredient.text) == -1)
        {
            // Show the new ingredient
            whatGlassHave.text = whatGlassHave.text + ", " + ingredient.text;
        }
    }
    public void EmptyGlass()
    {
        whatGlassHave.text = "Nothing";
    }
}
