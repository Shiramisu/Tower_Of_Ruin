using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public enum HitboxOwner { Player, Enemy }
    public HitboxOwner owner;

    // Speichert Objekte, die in der aktuellen Angriffsschwingung bereits getroffen wurden.
    private HashSet<GameObject> alreadyHit = new HashSet<GameObject>();

    // Flag, ob die Hitbox aktuell aktiv ist.
    public bool isActive = false;
    // Dauer der Angriffsschwingung in Sekunden (anpassen, wie es zu deiner Animation passt)
    public float attackSwingDuration = 1f;

    // Diese Methode sollte beim Start des Angriffs (z. B. per Animationsevent) aufgerufen werden.
    public void ActivateHitbox()
    {
        isActive = true;
        alreadyHit.Clear();
        // Nach Ablauf der Swing-Dauer wird die Hitbox automatisch wieder deaktiviert.
        Invoke(nameof(DeactivateHitbox), attackSwingDuration);
    }

    // Deaktiviert die Hitbox und leert die Trefferliste.
    public void DeactivateHitbox()
    {
        isActive = false;
        alreadyHit.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        // Nur wenn die Hitbox aktiv ist, soll Schaden zugefügt werden.
        if (!isActive)
            return;

        // Verhindert mehrfachen Schaden am gleichen Objekt während eines Angriffs.
        if (alreadyHit.Contains(other.gameObject))
            return;
        alreadyHit.Add(other.gameObject);

        if (owner == HitboxOwner.Player)
        {
            Enemy enemyScript = other.GetComponentInParent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(Player.AttackDamage);
            }
        }
        else if (owner == HitboxOwner.Enemy)
        {
            Player playerScript = other.GetComponentInParent<Player>();
            if (playerScript != null && !playerScript.isBlocking)
            {
                playerScript.TakeDamage(Enemy.damage);
            }
        }
    }
}
