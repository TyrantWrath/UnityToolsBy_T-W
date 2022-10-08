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

        public static string GetPercentString(float percentageAmount, bool includeSign = true)
        {
            return Mathf.RoundToInt(percentageAmount * 100f) + (includeSign ? "%" : "");
        }
        #endregion


        #region Collect Components At A Given Position
        public static bool GetComponentsAtCursorLocation2D<T>(out List<T> componentsAtPositionList, Vector3 positionToCheck)
        {
            bool found = false;

            List<T> componentList = new List<T>();

            Collider2D[] collider2DArray = Physics2D.OverlapPointAll(positionToCheck);

            T tComponent = default(T);

            for (int i = 0; i < collider2DArray.Length; i++)
            {
                tComponent = collider2DArray[i].gameObject.GetComponentInParent<T>();
                if (tComponent != null)
                {
                    found = true;
                    componentList.Add(tComponent);
                }
                else
                {
                    tComponent = collider2DArray[i].gameObject.GetComponentInChildren<T>();
                    if (tComponent != null)
                    {
                        found = true;
                        componentList.Add(tComponent);
                    }
                }
            }

            componentsAtPositionList = componentList;
            return found;
        }

        public static bool GetComponentsAtCursorLocation3D<T>(
            out List<T> componentsAtPositionList, Vector3 positionToCheck, float radiusToCheck, LayerMask layersToCheck)
        {
            bool found = false;

            List<T> componentList = new List<T>();

            Collider[] colliderArray = Physics.OverlapSphere(positionToCheck, radiusToCheck, layersToCheck);

            T tComponent = default(T);

            for (int i = 0; i < colliderArray.Length; i++)
            {
                tComponent = colliderArray[i].gameObject.GetComponentInParent<T>();
                if (tComponent != null)
                {
                    found = true;
                    componentList.Add(tComponent);
                }
                else
                {
                    tComponent = colliderArray[i].gameObject.GetComponentInChildren<T>();
                    if (tComponent != null)
                    {
                        found = true;
                        componentList.Add(tComponent);
                    }
                }
            }

            componentsAtPositionList = componentList;
            return found;
        }


        public static T[] GetComponentsAtCursorLocation3DNonAlloc<T>(
            Vector3 positionToCheck, float radiusToCheck, LayerMask layersToCheck, int numberOfCollidersToTest)
        {

            List<T> componentList = new List<T>();
            Collider[] colliderArray = new Collider[numberOfCollidersToTest];
            Physics.OverlapSphereNonAlloc(positionToCheck, radiusToCheck, colliderArray, layersToCheck);

            T tComponent = default(T);
            T[] componentArray = new T[colliderArray.Length];

            for (int i = colliderArray.Length - 1; i >= 0; i--)
            {

                if (colliderArray[i] != null)
                {
                    tComponent = colliderArray[i].gameObject.GetComponent<T>();
                    if (tComponent != null)
                    {
                        componentArray[i] = tComponent;
                    }
                }

            }
            return componentArray;
        }

        #endregion

    }
}