using UnityEngine;
using UnityEngine.UI;

public class UIProcess_ApplySpriteToImage : SingleEventProcess
{
    public Image ThisImage;
    public Sprite spriteToApply;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        GetSpriteSourceOverride();
        ThisImage.sprite = spriteToApply;
    }

    public virtual void GetSpriteSourceOverride()
    {

    }
}
