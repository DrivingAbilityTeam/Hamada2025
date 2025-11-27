using UnityEngine;
using System.Collections;

public class Pa : MonoBehaviour
{
    // �p�[�e�B�N���̃J�^�`���Ȃ����Ƃ��郂�f��
    public GameObject TargetPrimitive;

    [Range(0.0f, 1.0f)]
    public float ParticleSpeed;

    // �e�p�[�e�B�N���̖ڕW���W
    private Vector3[] m_targetVertices;
    // �e�p�[�e�B�N�����
    private ParticleSystem.Particle[] m_targetParticles;

    void Start()
    {
        m_targetVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;
        m_targetParticles = new ParticleSystem.Particle[m_targetVertices.Length];
    }

    void Update()
    {
        // �^�[�Q�b�g���W�̍X�V
        m_targetVertices = TargetPrimitive.GetComponent<MeshFilter>().sharedMesh.vertices;

        for (int i = 0; i < m_targetVertices.Length; i++)
        {
            // ���[���h���W�n�ɕϊ�����TargetPrimitive�̈ړ��ɒǏ]������
            m_targetVertices[i] = TargetPrimitive.transform.TransformPoint(m_targetVertices[i]);

            // ������ƒx�������ăp�[�e�B�N�����ړ�������
            m_targetParticles[i].position = m_targetParticles[i].position * (1f - ParticleSpeed) + m_targetVertices[i] * ParticleSpeed;
            // ���W�ɉ����ăp�[�e�B�N�����J���t����
            m_targetParticles[i].color = new Color(1f - m_targetVertices[i].x % 1f, 0.2f + m_targetVertices[i].y % 0.8f, 0.5f + m_targetVertices[i].z % 0.5f);
            m_targetParticles[i].size = 0.05f;

            // ���C�t�^�C�����w�肵�Ȃ��ƕ\������Ȃ��i��������ŏ����Ă�H�j
            m_targetParticles[i].remainingLifetime = 10f;
            m_targetParticles[i].startLifetime = 10f;
        }

        // �p�[�e�B�N�����̍X�V
        GetComponent<ParticleSystem>().SetParticles(m_targetParticles, m_targetParticles.Length);
    }
}
