using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Change layer of trans and all its children to newLayer
    /// </summary>
    /// <param name="trans"></param>
    public static void ChangeLayerRecursively(this Transform trans, string newLayer)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(newLayer);
        if (trans.childCount > 0)
        {
            foreach (Transform child in trans)
            {
                child.ChangeLayerRecursively(newLayer);
            }
        }
    }
}
