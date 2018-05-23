using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    [System.Serializable]
    public class Weapon
    {
        public string name;
        public string type;

    }

    public List<FIWeaponInterface> lWeapons;


}
