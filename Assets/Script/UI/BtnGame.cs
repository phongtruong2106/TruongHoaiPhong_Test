using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnGame : NewMonoBehaviour
{
    [SerializeField] protected Button button;
    public Button _button => button;    
    [SerializeField] protected TMP_Text textMeshPro;
    public TMP_Text _textMeshPro => textMeshPro;
    [SerializeField] protected SO_IndexUp sO_IndexUp;
    [SerializeField] protected SO_INDEX sO_INDEX;
    protected bool isLoad;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
        this.LoadTMP();
    }
    protected override void Start()
    {
        base.Start();
        this.isLoad = false;
    }

    private void LoadButton()
    {
        if(this.button != null) return;
        this.button = gameObject.GetComponent<Button>();
    }
    private void LoadTMP()
    {
        if(this.textMeshPro != null) return;
        this.textMeshPro = gameObject.GetComponentInChildren<TMP_Text>();    
    }

    protected virtual void SaveMOneya()
    {
        PlayerPrefs.SetFloat("MoneyA", sO_INDEX.Money);
        PlayerPrefs.Save(); 
    }
    protected virtual void LoadMoneya()
    {
        if (PlayerPrefs.HasKey("MoneyA"))
        {
            sO_INDEX.Money = PlayerPrefs.GetFloat("MoneyA");
        }
    }
}