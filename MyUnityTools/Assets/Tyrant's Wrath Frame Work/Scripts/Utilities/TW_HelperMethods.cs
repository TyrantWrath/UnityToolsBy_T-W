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



        #region  int To string Region
        public static string GetMonthName(int month)
        {
            switch (month)
            {
                default:
                case 0: return "January";
                case 1: return "February";
                case 2: return "March";
                case 3: return "April";
                case 4: return "May";
                case 5: return "June";
                case 6: return "July";
                case 7: return "August";
                case 8: return "September";
                case 9: return "October";
                case 10: return "November";
                case 11: return "December";
            }
        }
        #endregion
    }
}