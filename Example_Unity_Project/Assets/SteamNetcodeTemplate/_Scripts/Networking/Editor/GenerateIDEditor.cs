using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using Multiplayer.Interactable;

namespace Rycon.Editor
{
    public class GenerateIDEditor : EditorWindow
    {
        [MenuItem("Multiplayer/IDs/Enable Fix Window")]
        public static void EnableShowWindow()
        {
            IDDuplicate.hideWindow = false;
        }

        [MenuItem("Multiplayer/IDs/Network Create IDs")]
        public static void CreateIDs()
        {
            int idsGiven = 0;

            // NetworkInteractables
            foreach (var netInteractable in FindObjectsByType<NetworkInteractable>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                netInteractable.id = idsGiven;
                idsGiven++;
                EditorFix.SetObjectDirty(netInteractable);
            }

            // GameManagerNetwork
            //FindAnyObjectByType<GameManager>().givenIDS = idsGiven;
            //EditorFix.SetObjectDirty(FindAnyObjectByType<GameManager>());

            Debug.Log("Gave " + idsGiven + " network objects an ID");
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        public static int CheckForDuplicates()
        {
            List<int> existingIds = new List<int>();

            int count = 0;

            foreach (var netInteractable in FindObjectsByType<NetworkInteractable>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                if (existingIds.Contains(netInteractable.id))
                {
                    count++;
                }
                existingIds.Add(netInteractable.id);
            }
            return count;
        }
    }

    public class IDDuplicate : EditorWindow
    {
        static int duplicates = 0;
        public static bool hideWindow = false;

        public static void ShowWarning(int amountOfDuplicates)
        {
            duplicates = amountOfDuplicates;
            IDDuplicate window = ScriptableObject.CreateInstance<IDDuplicate>();
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 365);
            if (hideWindow == false)
            {
                window.ShowModalUtility();
            }
            else
            {
                GenerateIDEditor.CreateIDs();
            }
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("You have " + duplicates + " NetworkObjects with the same ID!!!", EditorStyles.wordWrappedLabel);
            GUILayout.Space(5);
            hideWindow = EditorGUILayout.Toggle("Dont show this again", hideWindow);
            GUILayout.Space(5);
            //GUILayout.Box(banner, GUILayout.Width(400), GUILayout.Height(300));
            if (GUILayout.Button("Fix it", GUILayout.Width(400), GUILayout.Height(30)))
            {
                GenerateIDEditor.CreateIDs(); 
                this.Close();
            }
        }
    }

    public class FileModificationWarning : AssetModificationProcessor
    {
        static string[] OnWillSaveAssets(string[] paths)
        {
            int amountOfDuplicates = GenerateIDEditor.CheckForDuplicates();
            if (amountOfDuplicates != 0)
            {
                IDDuplicate.ShowWarning(amountOfDuplicates);
            }
            return paths;
        }
    }
    public static class EditorFix
    {
        public static void SetObjectDirty(Object o)
        {
            if (Application.isPlaying)
                return;

            if (o is GameObject)
            {
                SetObjectDirty((GameObject)o);
            }
            else if (o is Component)
            {
                SetObjectDirty((Component)o);
            }
            else
            {
                EditorUtility.SetDirty(o);
            }
        }

        public static void SetObjectDirty(GameObject go)
        {
            if (Application.isPlaying)
                return;

            HandlePrefabInstance(go);
            EditorUtility.SetDirty(go);

            //This stopped happening in EditorUtility.SetDirty after multi-scene editing was introduced.
            EditorSceneManager.MarkSceneDirty(go.scene);
        }

        public static void SetObjectDirty(Component comp)
        {
            if (Application.isPlaying)
                return;

            HandlePrefabInstance(comp.gameObject);
            EditorUtility.SetDirty(comp);

            //This stopped happening in EditorUtility.SetDirty after multi-scene editing was introduced.
            EditorSceneManager.MarkSceneDirty(comp.gameObject.scene);
        }

        // Some prefab overrides are not handled by Undo.RecordObject or EditorUtility.SetDirty.
        // eg. adding an item to an array/list on a prefab instance updates that the instance
        // has a different array count than the prefab, but not any data about the added thing
        private static void HandlePrefabInstance(GameObject gameObject)
        {
            var prefabType = PrefabUtility.GetPrefabAssetType(gameObject);
            if (prefabType != PrefabAssetType.NotAPrefab)
            {
                PrefabUtility.RecordPrefabInstancePropertyModifications(gameObject);
            }
        }
    }
}
