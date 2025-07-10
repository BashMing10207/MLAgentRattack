using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IGetCompoable, IPointerClickHandler, IPointerUpHandler
{
    [SerializeField]
    private Outline _outLineRenderer;
    [SerializeField]
    private float offset = -60;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _actName;
    public ActSO Act { get; private set; }
    public bool IsSelected = false;
    public UnityEvent OnClicked;
    public UnityEvent OnEnter;
    public UnityEvent OnExit, OnAnimeEnd;
    [SerializeField]
    private SkillAddManager _skillAddManager;

    private RectTransform _rectTrm;
    private GameManager _parent;
    private int _index = 0, _type = 0;


    private void OnEnable()
    {
        _rectTrm = GetComponent<RectTransform>();

        
    }

    public void AnimationEnd()
    {
        OnAnimeEnd?.Invoke();
    }

    public void Init(ActSO act, int idx, int type)
    {
        Act = act;
        _actName.text = Act.ActName;
        _image.sprite = Act.Icon;
        _index = idx;
        _type = type;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Initialize(GetCompoParent entity)
    {
        _parent = entity as GameManager;
        OnClicked.AddListener(SetAction);
    }
    public void OutLineHandle(bool enabled)
    {
        IsSelected = enabled;
        _outLineRenderer.enabled = enabled;
        _rectTrm.localPosition = enabled ? new Vector3(0, 0, offset) : new Vector3(0, 0, -offset);
    }
    public void ToggleOutLine()
    {
        OutLineHandle(_outLineRenderer.enabled);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //_parent.GetCompo<PlayerActions>().SetToolTip(eventData.pointerCurrentRaycast.worldPosition, Act.Description);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //_parent.GetCompo<PlayerActions>().DisableToolTip();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void SetAction()
    {
        _parent.CurrentClientPlayerManagerCompo.GetCompo<ItemManager>().Items.Add(Act);
        _parent.GetCompo<SkillAddManager>().AddAction(Act);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_skillAddManager.IsClicked)
        {
            _skillAddManager.IsClicked = true;
            OnClicked?.Invoke();
        }
  
    }
}
