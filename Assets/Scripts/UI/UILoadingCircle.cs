using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadingCircle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _loadingCircleFrames;
    private bool _animationIsActive;

    private void OnEnable()
    {
        NetworkDataProvider.LoadingStarted += SetLoadingUI;
    }

    private void OnDisable()
    {
        NetworkDataProvider.LoadingStarted -= SetLoadingUI;
    }

    private void Start()
    {
        SetLoadingUI(false);
    }

    private void SetLoadingUI(bool loadingStarted)
    {
        if (!loadingStarted)
        {
            _animationIsActive = false;

            foreach (GameObject frame in _loadingCircleFrames)
            {
                frame.SetActive(false);
            }
        }
        else
        {
            _animationIsActive = true;
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        while (true)
        {
            for (int i = 0; i < _loadingCircleFrames.Count; i++)
            {
                if (_animationIsActive)
                {
                    _loadingCircleFrames[i].SetActive(true);

                    yield return new WaitForSeconds(.1f);

                    _loadingCircleFrames[i].SetActive(false);

                    if (i == _loadingCircleFrames.Count - 1)
                    {
                        i = 0;
                    }
                }
                else yield return null;
            }
        }
    }
}
