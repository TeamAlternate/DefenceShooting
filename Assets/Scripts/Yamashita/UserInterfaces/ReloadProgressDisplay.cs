using UnityEngine;
using TMPro;

namespace UserInterfaces
{
    public class ReloadProgressDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;

        public void StartReload()
        {
            countText.enabled = true;
        }

        public void UpdateProgress(float progress)
        {
            countText.text = progress.ToString("P");
        }

        public void DoneReload()
        {
            countText.enabled = false;
        }
    }
}
