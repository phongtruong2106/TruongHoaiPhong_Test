using UnityEngine;

public class TextMoneyGame : TextGame
{
    [SerializeField] private SO_INDEX sO_INDEX;
    private void Update()
    {
        this.CountPoint();
    }

    private void CountPoint()
    {
        if(sO_INDEX != null)
        {
          this._textMeshPro_game.text = $"{sO_INDEX.Money} $";
        }
    }
}