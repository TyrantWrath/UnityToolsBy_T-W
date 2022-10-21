using UnityEngine;
using UnityEditor;
//using Emortal.Gameplay;


namespace TyrantsWrath.EditorTools
{
    public static class InitialSceneSetup
    {
        #region Menu Methods

        public static void CreateLevelGroup()
        {
            GameObject levelGrp = new GameObject("Managers");

            string[] groupNames = new string[] { "Game_Manager", "PostProcessing_Manager", "Scene_Manager", "Audio_Manager", };
            CreateLevelGroups(levelGrp.transform, groupNames);

            //Select the Level Manager
            Selection.activeGameObject = levelGrp;

        }
        #endregion


        #region Utility Methods
        static void CreateLevelGroups(Transform levelManager, string[] groupNames)
        {
            if (levelManager && groupNames.Length > 0)
            {
                for (int i = 0; i < groupNames.Length; i++)
                {
                    GameObject curGroup = new GameObject(groupNames[i]);
                    curGroup.transform.SetParent(levelManager);
                }
            }
        }
        #endregion
    }
}
