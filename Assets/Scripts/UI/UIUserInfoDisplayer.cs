using System.Text;
using UnityEngine;
using TMPro;

public class UIUserInfoDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelUser;
    [SerializeField] private GameObject _panelParent;

    public void DisplayUserInfo(UserBase[] userList)
    {
        for (int i = 0; i < userList.Length; i++) 
        {
            var panelUserInstance = Instantiate(_panelUser,
                new Vector3(0, 0, 0),
                Quaternion.identity,
                _panelParent.transform);

            StringBuilder sb = new StringBuilder("", 100);

            sb.Append(ConstStrings.USER_ID);
            sb.Append(userList[i].id);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_FIRST_NAME);
            sb.Append(userList[i].first_name);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_LAST_NAME);
            sb.Append(userList[i].last_name);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_EMAIL);
            sb.Append(userList[i].email);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_GENDER);
            sb.Append(userList[i].gender);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_IP_ADDRESS);
            sb.Append(userList[i].ip_address);
            sb.Append("; ");
            sb.Append(ConstStrings.USER_ADDRESS);
            sb.Append(userList[i].address);
            sb.Append("; ");

            var textMeshPro = panelUserInstance.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = sb.ToString();
        }
    }
}
