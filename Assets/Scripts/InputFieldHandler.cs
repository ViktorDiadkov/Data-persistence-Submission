using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldHandler : MonoBehaviour
{
    public void GrabFromInputField(string text)
    {
        GameData.Instance.setUserName(text);
    }

}
