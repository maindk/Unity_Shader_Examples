//Custum GUI notes
using UNityEngine;
using UnityEditor;

public class customGUI : ShaderGUI
{
  public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
  {
    //Chooser
    materialProperty _Material = FindProperty("_Material", properties);
    materialEditor.ShaderProperty(_Material, _Material.displayname);

    //Spacer line
    {
      GUILayout.Space(5);

      Rect lineRect = EditorGUILayout.GetControlRect(false, 1);
      editorGUI.DrawRect(LineRect, Color.gray);
    }

  GUILayout.Space(10);

  MaterialProperty _Material_One = FindProperty("_Material_One", properties);
  MaterialProperty _Material_Two = FindProperty("_Material_Two", properties);
  
  switch ((int)_Material_Selector.floatvalue)
    {
      case 0: //material_one
        materialEditor.ShaderProperty(_Material_One, _Material_One.displayName);

        break;
      case 1: //_Material_Two
        materialEditor.ShaderProperty(_Material_Two, _Material_Two.displayName);

        break;
    }
  //Shows materials three and four if a value is true
  MaterialProperty _Bool = FindProperty("_Bool", properties);
  materialEditor.ShaderProperty(_Bool, _Bool.displayName);

  MaterialProperty _Material_three = FindProperty("_Material_three", properties);
  MaterialProperty _Material_four = FindProperty("_Material_four", properties);

  if (_Bool.floatvalue ==1)
    {
      materialEditor.ShaderProperty(_Material_three, _Material_three.displayname);
      materialEditor.ShaderProperty(_Material_four, _Material_three.displayname);
    }
  }
}
