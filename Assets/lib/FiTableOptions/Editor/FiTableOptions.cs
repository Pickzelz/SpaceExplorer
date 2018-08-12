using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FiTableOptions : EditorWindow {

    public GUIStyle WindowSkin;
    public GUIStyle HeaderStyle;
    public Vector2 HscrollPos = Vector2.zero;

    public GUISkin skin;

    [MenuItem("Tools/Table Window")]
    static void Init()
    {
        var window = GetWindow<FiTableOptions>();
        window.Show();
    }

    void CreateSkin()
    {
        
    }

    private void Awake()
    {
        Debug.Log("awake table options");
        WindowSkin = new GUIStyle();
        HeaderStyle = new GUIStyle();

        HeaderStyle.fontStyle = FontStyle.Bold;
        HeaderStyle.margin.left = 10;
        HeaderStyle.margin.top = 100;
        HeaderStyle.margin.bottom = 10;
        HeaderStyle.margin.right = 10;
        HeaderStyle.border.bottom = 1;

        skin = (GUISkin)Resources.Load("TableSkin");
    }

    void OnGUI()
    {
        GUI.skin = skin;
        using (var scrollView = new EditorGUILayout.ScrollViewScope(HscrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height)))
        {
            HscrollPos = scrollView.scrollPosition;
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();

            float totalWidth = 0;
            
            for (int i = 0; i < 100; i++)
            {
                GUILayout.Label("test 1 " + i, skin.customStyles[0]);
                GUIContent content = new GUIContent("test 1 " + i);

                Vector2 size = HeaderStyle.CalcSize(content);

                totalWidth += size.x;
            }

            //float boxHeight = 30;
            //float boxWidth = totalWidth;
            //float boxX = HeaderStyle.margin.left - GUI.skin.box.padding.left;
            //float boxY = HeaderStyle.margin.top;
            //GUI.Box(new Rect(boxX, boxY, boxWidth, boxHeight), "");

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            for (int i = 0; i < 10; i++)
            {
                GUILayout.Label("test 2 " + i);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}
