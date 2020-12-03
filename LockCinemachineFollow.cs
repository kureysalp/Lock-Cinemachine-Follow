using UnityEngine;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class LockCinemachineFollow : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    public float m_XPosition = 10;
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_YPosition = 10;
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_ZPosition = 10;

    public bool lockX, lockY, lockZ;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            if (lockX)
            {
                var pos = state.RawPosition;
                pos.x = m_XPosition;
                state.RawPosition = pos;
            }

            if (lockY)
            {
                var pos = state.RawPosition;
                pos.y = m_YPosition;
                state.RawPosition = pos;
            }

            if (lockZ)
            {
                var pos = state.RawPosition;
                pos.z = m_ZPosition;
                state.RawPosition = pos;
            }
        }
    }
}
