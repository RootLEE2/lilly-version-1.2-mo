using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHHangerControl : SimpleOneTouch
{
    [Header("Variables")]
    [SerializeField] private int hangerCode;
    private int hangingClothesCode = -1;

    [Header("Sprite Variables")]
    [SerializeField] private Sprite hangerSprite;
    private SpriteRenderer spriteRenderer;
    // setter
    public void SetSprite(Sprite a_sprite) { spriteRenderer.sprite = a_sprite; }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void FuncWhenTouchEnded() {
        // if (!PlainHanger.instance.isDragging && hangingClothesCode != -1) {
            HangingClothes(-1, hangerSprite);
        // }
    }

    public bool CheckCanHang(int a_clothesCode) {
        int hangerType = hangerCode / 10;
        int clothesType = a_clothesCode / 10;

        if (hangerType == clothesType) return true;
        else return false;
    }

    public bool HangingClothes(int a_clothesCode, Sprite a_sprite) {
        hangingClothesCode = a_clothesCode;
        SetSprite(a_sprite);

        if (hangingClothesCode == hangerCode) return true;
        else return false;
    }
}
