using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Miventech.Security.AES
{
    public class ExampleUnityAes : MonoBehaviour
    {
        public string Data;
        public string Password;
        [TextArea(10, 10)]
        public string Base64Result;

        [ContextMenu("generate")]
        public void generate()
        {
            Base64Result = UnityManagerAES.EncryptToString(Data, Password);
            // UnityManagerAES.DecryptString()
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ExampleUnityAes))]
    public class ExampleUnityAESEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate"))
            {
                ((ExampleUnityAes)target).generate();
            }
        }
    }
#endif
}
