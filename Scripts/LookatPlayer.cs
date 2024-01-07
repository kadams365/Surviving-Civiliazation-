using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (m_Renderer.isVisible)
        {
            transform.rotation = Quaternion.LookRotation((transform.position - Camera.main.transform.position).normalized);
        }
    }
}