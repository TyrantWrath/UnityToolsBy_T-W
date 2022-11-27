using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TyrantsWrath.HelperMethods
{
    public static class TW_HelperMethods
    {
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


        public static T[] GetComponentsAtCursorLocation2DNonAlloc<T>(
            Vector3 positionToCheck, float radiusToCheck, LayerMask layersToCheck, int numberOfCollidersToTest)
        {

            List<T> componentList = new List<T>();
            Collider2D[] collider2DArray = new Collider2D[numberOfCollidersToTest];
            Physics2D.OverlapCircleNonAlloc(positionToCheck, radiusToCheck, collider2DArray, layersToCheck);

            T tComponent = default(T);
            T[] componentArray = new T[collider2DArray.Length];

            for (int i = collider2DArray.Length - 1; i >= 0; i--)
            {

                if (collider2DArray[i] != null)
                {
                    tComponent = collider2DArray[i].gameObject.GetComponent<T>();
                    if (tComponent != null)
                    {
                        componentArray[i] = tComponent;
                    }
                }

            }
            return componentArray;
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



        #region  Camera Related Methods
        public static void ShakeCamera(float intensity, float timer)
        {
            Vector3 lastCameraPosition = Vector3.zero;
            timer -= Time.unscaledDeltaTime;
            Vector3 randomMovement = new Vector3(
                UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * intensity;

            Camera.main.transform.position = Camera.main.transform.position - lastCameraPosition + randomMovement;
            lastCameraPosition = randomMovement;

        }

        public static void ShakeCamera(float intensity, float timer, Camera cameraToShake)
        {
            Vector3 lastCameraPosition = Vector3.zero;
            timer -= Time.unscaledDeltaTime;
            Vector3 randomMovement = new Vector3(
                UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * intensity;

            cameraToShake.transform.position = cameraToShake.transform.position - lastCameraPosition + randomMovement;
            lastCameraPosition = randomMovement;
        }

        #endregion



        #region Math Calculation Region
        public static bool TestChance(int chance, int chanceMax = 100)
        {
            return UnityEngine.Random.Range(0, chanceMax) < chance;
        }

        public static Vector3 GetRandomPositionWithinRectangle(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector3(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax));
        }

        public static int CalculateAngleFromVector3(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static void ResetGameObjectPosition(Transform gameObjectTransform)
        {
            gameObjectTransform.position = Vector3.zero;
        }

        ///<summary>
        ///Interval Methods Below Are Used To Caculate Overalapping Values
        ///--------------(Parameters)------------
        /// The Parameters Are The Numbers To Be Used In The Interval
        ///</summary>

        public static bool IsOverLappingInterval(int imin1, int imax1, int imin2, int imax2)
        {
            if (Mathf.Max(imin1, imin2) <= Mathf.Min(imax1, imax2))
            {
                return true;
            }
            return false;
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

        private static PointerEventData pointerEventData;
        private static List<RaycastResult> raycastResults;
        public static bool IsMouseOverUI()
        {
            pointerEventData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            raycastResults = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            return raycastResults.Count > 0;
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

        public static string GetWeekDayName(int weekDay)
        {
            switch (weekDay)
            {
                default:
                case 0: return "Monday";
                case 1: return "Tuesday";
                case 2: return "Wednesday";
                case 3: return "Thursday";
                case 4: return "Friday";
                case 5: return "Saturday";
                case 6: return "Sunday";
            }
        }

        public static string GetPercentString(float percentageAmount, bool includeSign = true)
        {
            return Mathf.RoundToInt(percentageAmount * 100f) + (includeSign ? "%" : "");
        }
        #endregion



        #region Array & Lists Region

        public static T GetRandomFromArray<T>(T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public static T GetRandomFromList<T>(List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static T[] RemoveDuplicatesFromArray<T>(T[] arrayName)
        {
            List<T> list = new List<T>();
            foreach (T t in arrayName)
            {
                if (!list.Contains(t))
                {
                    list.Add(t);
                }
            }
            return list.ToArray();
        }

        public static List<T> RemoveDuplicatesFromList<T>(List<T> listName)
        {
            List<T> list = new List<T>();
            foreach (T t in listName)
            {
                if (!list.Contains(t))
                {
                    list.Add(t);
                }
            }
            return list;
        }
        #endregion



        #region UI Related Methods Region

        public static void ClearAndSetDropDownData(Dropdown dropdown, List<string> dropDownNames)
        {
            dropdown.ClearOptions();

            foreach (var item in dropDownNames)
            {
                dropdown.options.Add(new Dropdown.OptionData() { text = item });
            }
        }

        public static void SetDropDownData(Dropdown dropdown, List<string> dropDownNames)
        {
            foreach (var item in dropDownNames)
            {
                dropdown.options.Add(new Dropdown.OptionData() { text = item });
            }
        }

        #endregion
    }
}