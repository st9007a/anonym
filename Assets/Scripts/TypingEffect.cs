using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TypingEffect : MonoBehaviour {

    public float Delay;
    public float Speed;

    TextMeshProUGUI Txt;
    string Content;

	void Awake () {
        Txt = GetComponent<TextMeshProUGUI>();
        SetContent(Txt.text);
	}

    public void SetContent(string content) {
        Content = content;
        Txt.text = "";
        StartCoroutine("Typing");
    }

    IEnumerator Typing() {

        yield return new WaitForSeconds(Delay);

        foreach (char c in Content) {
            Txt.text += c;
            yield return new WaitForSeconds(Speed);
        }
    }
}
