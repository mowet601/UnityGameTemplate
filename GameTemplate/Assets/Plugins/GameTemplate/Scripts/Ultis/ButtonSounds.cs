using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



[RequireComponent(typeof(UIEvents))]
public class ButtonSounds : MonoBehaviour {
	[Header("Audio"), Space]
	[SerializeField] AudioClip enterClip;
	[SerializeField] AudioClip clickClip;
	[SerializeField] AudioClip exitClip;

	[Header("Refs"), Space]
	[SerializeField] UIEvents events;

#if UNITY_EDITOR
	private void Reset() {
		events = GetComponent<UIEvents>();
		
		StartCoroutine(Init());

		IEnumerator Init() {
			yield return null;

			events.AddPersistentListener(ref events.onEnter, this, "OnEnter");
			events.AddPersistentListener(ref events.onClick, this, "OnClick");
			events.AddPersistentListener(ref events.onExit, this, "OnExit");
		}
	}
#endif

	void OnEnter() {
		if(enterClip)
			AudioManager.Instance.Play(enterClip);
	}

	void OnClick() {
		if(clickClip)
			AudioManager.Instance.Play(clickClip);
	}

	void OnExit() {
		if(exitClip)
			AudioManager.Instance.Play(exitClip);
	}
}
