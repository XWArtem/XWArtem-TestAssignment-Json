using System.Linq;
using UnityEngine;

public class NetworkDataReader : MonoBehaviour
{
    [SerializeField] private UIUserInfoDisplayer _UIUserInfoProvider;

    public void ReadUserInfo(UsersList userList)
    {
        var _userListSorted = userList.Users.OrderBy(c => c.id).ToArray();
        _UIUserInfoProvider.DisplayUserInfo(_userListSorted);
    }
}
