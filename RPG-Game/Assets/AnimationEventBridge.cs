using UnityEngine;

public class AnimationEventBridge : MonoBehaviour
{
    [SerializeField] private Hitbox weaponHitbox;
    // Hier die Hitbox deines Unterobjekts zuweisen (z. B. per Inspector)

    public void ActivateWeaponHitbox()
    {
        if (weaponHitbox != null)
        {
            weaponHitbox.ActivateHitbox();
        }
    }

    public void DeactivateWeaponHitbox()
    {
        if (weaponHitbox != null)
        {
            weaponHitbox.DeactivateHitbox();
        }
    }
}
