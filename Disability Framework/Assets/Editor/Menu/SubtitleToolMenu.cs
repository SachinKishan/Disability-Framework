using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Operation
{
    Allocate,
    Delete,
    Create
}
public class SubtitleToolMenu: EditorWindow
{
    [MenuItem("Tools/Subtitle Menu")]
    public static void OpenWindow() => GetWindow<SubtitleToolMenu>("Subtitles");

    private ScriptableObject target;
    private SerializedObject sound;
    private SerializedObject so;
    private SerializedProperty soundProperty;
    private SerializedProperty subtitleProperty;
    
    
    //subtitle creation
    private SerializedProperty path;

    [SerializeField]    public Operation type=Operation.Allocate;

    [SerializeField] private List<Sound_ScriptableObject_Demo> sounds = new List<Sound_ScriptableObject_Demo>()
    ;

    [SerializeField] private List<Subtitle> subtitles = new List<Subtitle>()
    ;

    private void OnEnable()
    {
        target = this;
       sound = new SerializedObject(target);
        so = new SerializedObject(target);
        soundProperty = sound.FindProperty("sounds");
        subtitleProperty = so.FindProperty("subtitles");
        path = so.FindProperty("path");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Subtitle Operations");
        so.Update();
        sound.Update();
        
        
        
        type = (Operation) EditorGUILayout.EnumPopup(type, GUILayout.MinWidth(1000));
        if (type == Operation.Allocate)
        {
            using (new GUILayout.HorizontalScope())
            {
                using (new GUILayout.VerticalScope())
                {
                    GUILayout.Label("Subtitle");
                
                    EditorGUILayout.PropertyField(subtitleProperty, true);
                }
                using (new GUILayout.VerticalScope())
                {
                    GUILayout.Label("Sound");
                
                    EditorGUILayout.PropertyField(soundProperty, true);
                
                }

            
            }
            if (GUILayout.Button("Allocate Subtitles to Sounds"))
            {
                for (int i = 0; i < sounds.Count; i++)
                {
                    sounds[i].subtitle = subtitles[i];
                }
            }
        }
        else if (type == Operation.Delete)
        {
            using (new GUILayout.VerticalScope())
            {
                GUILayout.Label("Sound");

                EditorGUILayout.PropertyField(soundProperty, true);

            }

            if (GUILayout.Button("Delete Subtitle Sound"))
            {

                for (int i = 0; i < sounds.Count; i++)
                {
                    sounds[i].subtitle = null;
                }
            }
        }
        /*
        else if (type == Operation.Create) 
        {
            //Subtitle example = ScriptableObject.CreateInstance<Subtitle>();
            EditorGUILayout.PropertyField(path);
            //AssetDatabase.CreateAsset(example, path);
            //AssetDatabase.SaveAssets();
            //AssetDatabase.Refresh();
            //EditorUtility.FocusProjectWindow();
            //Selection.activeObject = example;
        }*/
        sound.ApplyModifiedProperties();
        so.ApplyModifiedProperties();

    }
    void OnInspectorUpdate () {
        Repaint ();
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (sounds.Count > subtitles.Count)
        {
            sounds.Remove(sounds[sounds.Count - 1]);
        }
        else if (sounds.Count < subtitles.Count)
        {
            sounds.Add(null);   
        }
    }
#endif
   
}
