using TMPro;
using UnityEngine;

namespace EComShared.View
{
public class ProductListing : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Initialize(string text)
    {
        _text.text = text;
    }

}
}