using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class inEditor : MonoBehaviour
{
    public static bool EditorApplicationQuit = false;
    static bool WantsToQuit() {
        EditorApplicationQuit = true;
        return true;
    }
    
    void OnEnable() {
        //EditorApplication.wantsToQuit += WantsToQuit;
    }
    
}
