using System;
using TravisRFrench.Dependencies.Injection;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC
{
    public class SampleGameManager : MonoBehaviour
    {
        [Inject]
        private IScoreService scoreService;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.scoreService?.IncrementScore();
            }
        }
    }
}
