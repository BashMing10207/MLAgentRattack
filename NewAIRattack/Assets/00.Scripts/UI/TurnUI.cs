using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class TurnUI : MonoBehaviour
{
    [SerializeField]
    private Animator _startAnime;

    [SerializeField]
    private Color _whiteTurnBackGround,_whiteTurnText, _blackTurnBackGround,_blackTurnText;

    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Image _backGround;

    public UnityEvent AfterTurnStarter;

    public void TurnStarter()
    {
        _backGround.color = ((GameManager.Instance.GetCompo<TurnManager>().TurnCount%2) ==0)? _whiteTurnBackGround: _blackTurnBackGround;
        _text.color = ((GameManager.Instance.GetCompo<TurnManager>().TurnCount % 2) == 0) ? _whiteTurnText : _blackTurnText;
        _text.text = (((GameManager.Instance.GetCompo<TurnManager>().TurnCount % 2) == 0) ? "WHITE TURN" : "BLACK TURN") + $"\n {GameManager.Instance.GetCompo<TurnManager>().TurnCount} Turn ";
        _startAnime.SetTrigger("Enter");
    }

    public void AfterTrunStarterHandle()
    {
        AfterTurnStarter?.Invoke();
    }

}
