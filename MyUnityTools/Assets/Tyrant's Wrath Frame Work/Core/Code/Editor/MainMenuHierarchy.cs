using UnityEditor;
using UnityEngine;

namespace TyrantsWrath.EditorTools
{
    public class MainMenuHierarchy
    {
        #region Project Tools Menus
        [MenuItem("Tyrant's Wrath/Project Tools/Create Project Folders")]
        public static void CreateProjectFolders()
        {
            ProjectFolderSetup.InitWindow();
        }
        #endregion


        [MenuItem("Tyrant's Wrath/Scene Tools/Group Selected")]
        public static void GroupSelectedGameObjects()
        {
            GroupEditorWindow.InitWindow();
        }

        [MenuItem("GameObject/Tyrant's Wrath/Grouping", false, 11)]
        public static void ContextGrouping()
        {
            GroupEditorWindow.InitWindow();
        }


        [MenuItem("Tyrant's Wrath/Scene Tools/Create Level Group")]
        public static void CreateLevelController()
        {
            InitialSceneSetup.CreateLevelGroup();
        }

        [MenuItem("GameObject/Tyrant's Wrath/Create Level Group", false, 11)]
        public static void ContextCreateLevelController()
        {
            InitialSceneSetup.CreateLevelGroup();
        }

    }
}
