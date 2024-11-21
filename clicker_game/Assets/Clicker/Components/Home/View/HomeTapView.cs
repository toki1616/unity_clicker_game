using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using R3;
using R3.Triggers;
using UnityEngine.EventSystems;

public class HomeTapView : MonoBehaviour
{
    private ItemPresenter _itemPresenter;

    [Inject]
    public void Construct
        (
            ItemPresenter itemPresenter
        )
    {
        _itemPresenter = itemPresenter;
    }

    // Start is called before the first frame update
    void Start()
    {
        var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
        // PointerDown
        eventTrigger
            .OnPointerDownAsObservable()
            .Subscribe(pointerEventData => OnPointerDown(pointerEventData))
            .AddTo(this);
    }

    private void OnPointerDown(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData.position);
        _itemPresenter.OnTapHome();
    }
}
