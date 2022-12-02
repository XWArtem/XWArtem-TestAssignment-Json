using System.Linq;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset _textJson;
    [SerializeField] private UIUserInfoDisplayer _UIUserInfoProvider;

    public void ParseJsonFromURI(UsersList userList)
    {
        var _userListSorted = userList.Users.OrderBy(c => c.id).ToArray();
        _UIUserInfoProvider.DisplayUserInfo(_userListSorted);
    }
}
