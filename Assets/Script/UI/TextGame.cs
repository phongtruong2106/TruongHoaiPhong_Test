using TMPro;
using UnityEngine;

public class TextGame : NewMonoBehaviour
{
    [SerializeField] protected TMP_Text textMeshPro_game;
    public TMP_Text _textMeshPro_game => textMeshPro_game;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    private void LoadText()
    {
        if(textMeshPro_game != null) return;
        this.textMeshPro_game = gameObject.GetComponent<TMP_Text>();
    }
}