using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TyrantsWrath.HelperMethods
{
    public static class TW_HelperMethods
    {






        #region Math Calculation Region
        public static bool TestChance(int chance, int chanceMax = 100)
        {
            return UnityEngine.Random.Range(0, chanceMax) < chance;
        }
        #endregion





        #region Mouse Position Region
        public static Vector2 GetMousePosition2D(Camera mainCam)
        {
            if (!mainCam)
            {
                Vector2 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
                return mousePosition;
            }
            else
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return mousePosition;
            }

        }
        public static Vector3 GetMousePosition3D(Camera mainCam)
        {
            if (!mainCam)
            {
                Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
                return mousePosition;
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return mousePosition;
            }

        }
        #endregion
    }
}