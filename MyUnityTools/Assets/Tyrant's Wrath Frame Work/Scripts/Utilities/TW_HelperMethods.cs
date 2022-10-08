using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TyrantsWrath.HelperMethods
{
    public static class TW_HelperMethods
    {
        public static Vector2 GetMousePosition2D()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mousePosition;
        }

        public static Vector3 GetMousePosition3D()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mousePosition;
        }
    }
}