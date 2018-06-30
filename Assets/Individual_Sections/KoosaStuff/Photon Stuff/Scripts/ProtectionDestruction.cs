using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionDestruction : MonoBehaviour
{
	void Awake ()
    {
        DontDestroyOnLoad(this);
		
	}
}
