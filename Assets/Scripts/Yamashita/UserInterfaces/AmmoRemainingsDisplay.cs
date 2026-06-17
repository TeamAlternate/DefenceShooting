using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UserInterfaces
{
    public class AmmoRemainingsDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private Image gaugeImage;

        [SerializeField] private float gaugeWidthPerAmmo;
        private float gaugeHeight;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            gaugeHeight = gaugeImage.rectTransform.sizeDelta.y;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateCount(int newCount)
        {
            countText.text = newCount.ToString();
            gaugeImage.rectTransform.sizeDelta = new Vector2(newCount * gaugeWidthPerAmmo, gaugeHeight);
        }
    }
}
