using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour, IGetCompoable,IAfterInitable
{
    [SerializeField]
    private ToolTip _toolTip;
    private List<List<UIACTCard>> _cards = new List<List<UIACTCard>>();

    [SerializeField]
    private List<RefreshableLayout> _cardParents = new List<RefreshableLayout>();
    [SerializeField]
    private SkillAnimator _skillAnimator;
    //[SerializeField]
    //private LayoutGroup _layoutGroup;

    private UserPlayer _parent;

    private PlayerAgentManager _agentManager;

    private ActCommander _actCommander;
    private ItemManager _itemManager = new();
    [SerializeField]
    private int _currentActType = 0, _currentActIdx = 0;

    private bool _isEnabled = true;


    private bool _didStart = false;

    private void Start()
    {
        GameManager.Instance.OnTurnEndEvent +=Init;
        _didStart = true;
    }

    public bool IsOnPointer { get; private set; } = false;
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity as UserPlayer;

        for (int i = 0; i < _cardParents.Count; i++)
        {
            _cards.Add(_cardParents[i].GetComponentsInChildren<UIACTCard>().ToList());
        }
        GameManager.Instance.PlayerInputSO.Arrow += Arrow;

       
    }

    public void AfterInit()
    {
        _agentManager = _parent.GetCompo<PlayerAgentManager>();
        _actCommander = _parent.GetCompo<ActCommander>(true);
    }

    private void OnDisable()
    {
        _isEnabled = true;
    }

    private void Update()
    {
        if (_isEnabled)
        {
            _isEnabled = false;
            Init();
        }
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance.IsPlayerturn)
        {
            SetTrm();
            if (_agentManager.IsHolding)
            {

            }
        }
    }

    private void SetTrm()
    {
    //    Vector3 rot = _parent.GetCompo<CameraManager>().MainCamera1.transform.eulerAngles;
    //    Vector3 dir = Quaternion.Euler(0, rot.y, 0) * (BashUtils.V2ToV3(_agentManager.PostMousePos - Mouse.current.position.value).normalized);
    //    //_skillAnimator.transform.SetPositionAndRotation(_parent.SelectedUnit().WeaponTrm.position ,Quaternion.FromToRotation(Vector3.forward, dir));
    //    _skillAnimator.transform.position = _agentManager.SelectedUnit().WeaponTrm.position;
    //    _skillAnimator.transform.localScale = Vector3.one * _agentManager.SelectedUnit().WeaponTrm.lossyScale.x;
    //    _skillAnimator.transform.rotation = Quaternion.Lerp(_skillAnimator.transform.rotation, Quaternion.FromToRotation(Vector3.forward, dir), 0.45f);
    }

    private void Arrow(Vector2 dir)
    {
        //_itemManager[1] = _agentManager.SelectedUnit().GetCompo<ItemManager>();

        //SetAction(Mathf.Abs(((int)dir.y +_currentActType) % 2), ((int)dir.x + _currentActIdx) % (_itemManager[Mathf.Abs(((int)dir.y + _currentActType) % 2)].Items.Count));
    }

    public void SetCurrentAct()
    {
        SetAction(_currentActType, _currentActIdx);
    }

    public void SetAction(int type, int idx)
    {

        Debug.LogWarning("Fix!!! this is Wrong!");
        _skillAnimator.SetAnim(_cards[type][idx].Act.HashValue);
        _cards[_currentActType][_currentActIdx].OutLineHandle(false);

        _currentActType = type;
        _currentActIdx = idx;

        //_actCommander.SetAct(_cards[type][idx].Act);
        _cards[type][idx].OutLineHandle(true);

        _cardParents[0].Refresh();
        _cardParents[1].Refresh();
    }

    public void Init()
    {
        //for (int i = 0; i < _cards.Count; i++)
        //{
        //    for (int j = 0; j < _cards[i].Count; j++)
        //    {
        //        _cards[i][j].Init()
        //    }
        //}
        if (_didStart) //didstart는 unity2023+에 추가된 기능이다.
        {
            _itemManager = _agentManager.SelectedUnit().GetCompo<ItemManager>();

            for (int i = 0; i < _cards.Count; i++)
            {
                for (int j = 0; j < _cards[0].Count; j++)
                {
                    bool isExist = _itemManager.Items.Count > j;
                    _cards[i][j].SetActive(isExist);

                    if (isExist)
                        _cards[i][j].Init(_itemManager.Items[j], j, i);
                }
            }

            SetAction(_currentActType, _currentActIdx);
        }
       
    }

    public void SetToolTip(Vector3 pos, string s)
    {
        _toolTip.Init(pos, s);
        IsOnPointer = true;
    }
    public void DisableToolTip()
    {
        _toolTip.Disable();
        IsOnPointer = false;
    }

    public void AttackAnim()
    {
        _skillAnimator.SetAnim("Attack");

            if (_itemManager.Items.Count > 0)
            {
                
                //_itemManager.Items.RemoveAt(_currentActIdx);
                //List<ActSO> unitOwnList = _agentManager.SelectedUnit().GetCompo<ItemManager>().Items;

                for (int j = 0; j < _cards[_currentActType].Count; j++)
                {
                    bool isExist = _itemManager.Items.Count > j;
                    _cards[_currentActType][j].SetActive(isExist);

                    if (isExist)
                        _cards[_currentActType][j].Init(_itemManager.Items[j], j, _currentActType);
                }

            }
        _currentActIdx = 0;
        _currentActType = 0;

            StartCoroutine(RemoveCards());
    }

    private IEnumerator RemoveCards()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        //if (_parent.Items.Count > 0)
        //{
        //    if (_currentActType == 1)
        //    {
        //        _parent.Items.RemoveAt(_currentActIdx);
        //    }
        //    Init();
        //}

        SetAction(_currentActType, _currentActIdx);
        if (_itemManager.Items.Count <= 0)
        {
            //_actCommander.CurrentAct = null;
        }
    }


}
