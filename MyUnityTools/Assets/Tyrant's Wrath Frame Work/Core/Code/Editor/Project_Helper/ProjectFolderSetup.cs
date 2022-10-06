using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

namespace TyrantsWrath.EditorTools
{
    public class ProjectFolderSetup : MainMenuEditorWindow
    {
        static ProjectFolderSetup thisWindow;

        string rootFolderName = "Game";
        string ProjectFolderSetupName = "Project Folder Setup";

        #region Main Methods
        public static void InitWindow()
        {
            thisWindow = GetWindow<ProjectFolderSetup>(true, "Project Folders", true);
            thisWindow.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Project Name: ", EditorStyles.boldLabel);
            rootFolderName = EditorGUILayout.TextField(rootFolderName);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Create Folder Structure", GUILayout.ExpandWidth(true), GUILayout.Height(48)))
            {

                CreateRootFolder();
            }

            if (thisWindow)
            {
                thisWindow.Repaint();
            }
        }
        #endregion


        #region Custom Methods
        void CreateRootFolder()
        {
            if (rootFolderName == "" || rootFolderName == null)
            {
                DialogDisplay("Invalid Name");
                return;
            }

            if (rootFolderName == "Root")
            {
                DialogDisplay("Replace The Name Please");
                return;
            }

            string assetFolder = Application.dataPath;
            string rootName = assetFolder + "/" + rootFolderName;

            DirectoryInfo rootInfo = Directory.CreateDirectory(rootName);

            if (!rootInfo.Exists)
            {
                return;
            }
            CreatSubDirectories(rootName);

            AssetDatabase.Refresh();

            if (thisWindow)
            {
                thisWindow.Close();
            }
        }

        void CreatSubDirectories(string rootFolderName)
        {
            DirectoryInfo rootInfo = null;
            List<string> afolderList = new List<string>();

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Animations");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Folder1");
                afolderList.Add("Folder2");
                afolderList.Add("Folder3");
                afolderList.Add("Folder4");

                CreateSubFolders(rootFolderName + "/" + "Animations", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Graphics");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Sprites");
                afolderList.Add("Models");
                afolderList.Add("Textures");

                CreateSubFolders(rootFolderName + "/" + "Graphics", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Fonts");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Custom");
                afolderList.Add("External");

                CreateSubFolders(rootFolderName + "/" + "Fonts", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Scripts");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("UI");
                afolderList.Add("Game");
                afolderList.Add("Characters");
                CreateSubFolders(rootFolderName + "/" + "Scripts", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Prefabs");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("UI");
                afolderList.Add("Game");
                afolderList.Add("Characters");
                afolderList.Add("Others");
                CreateSubFolders(rootFolderName + "/" + "Prefabs", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Settings");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Unity");
                afolderList.Add("Other");
                CreateSubFolders(rootFolderName + "/" + "Settings", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Audio");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Ambient");
                afolderList.Add("Sounds Effects");
                afolderList.Add("Music");
                afolderList.Add("UI");
                CreateSubFolders(rootFolderName + "/" + "Audio", afolderList);
            }

            rootInfo = Directory.CreateDirectory(rootFolderName + "/" + "Prefabs");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Characters");
                afolderList.Add("Props");
                afolderList.Add("UI");
            }

            DirectoryInfo sceneDir = Directory.CreateDirectory(rootFolderName + "/" + "Scenes");


            Scene curFrontendScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(
                curFrontendScene, "Assets/" + this.rootFolderName + "/Scenes/" + "Prototype.unity", true);

            Scene curMainScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(
                curMainScene, "Assets/" + this.rootFolderName + "/Scenes/" + "MainScene.unity", true);

            Scene curStartupScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(
                curStartupScene, "Assets/" + this.rootFolderName + "/Scenes/" + "Testing.unity", true);

        }

        void CreateSubFolders(string rootFolderName, List<string> subFolders)
        {
            foreach (string aFolder in subFolders)
            {
                Directory.CreateDirectory(rootFolderName + "/" + aFolder);
            }
        }

        void DialogDisplay(string messegeToDisplay)
        {
            EditorUtility.DisplayDialog(ProjectFolderSetupName + "Warning", messegeToDisplay, "OK");
        }
        #endregion
    }
}
