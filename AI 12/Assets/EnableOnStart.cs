﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<BansheeGz.BGSpline.Components.BGCcCursorChangeLinear>().enabled = true;
	}

}
