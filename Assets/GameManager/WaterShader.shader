Shader "Unlit/WaterShader"
{
    Properties
    {
        // �e�N�X�`������v�����ꍇ�Ƀo�b�`���O�������悤�ɂ��邽�߁A
        // �e�N�X�`���� Material ���璼�ڂł͂Ȃ� MaterialPropertyBlock �o�R�Őݒ肷��
        // �i�Ȃ��AUI �V�F�[�_�[�ł͊�{�I�� MaterialPropertyBlock ���g�����Ƃ͂ł��Ȃ��j
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}

        // �F
        _Color("Tint", Color) = (1,1,1,1)

        // �X�e���V����r�֐�
        // UnityEngine.Rendering.CompareFunction �Œ�`����Ă���
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.CompareFunction.html
        // 8 �� Always �ł���A��ɃX�e���V���e�X�g����������
        _StencilComp("Stencil Comparison", Float) = 8

        // �X�e���V���e�X�g�̊�l�i0 �` 255�j
        _Stencil("Stencil ID", Float) = 0

        // �X�e���V���e�X�g�������̋���
        // UnityEngine.Rendering.StencilOp �Œ�`����Ă���
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.StencilOp.html
        // 0 �� Keep �ł���A�ύX���s��Ȃ�
        _StencilOp("Stencil Operation", Float) = 0

        // �X�e���V���e�X�g���s������Ƀo�b�t�@�Ɋ�l���������ރr�b�g���w�肷��}�X�N
        // 0xFF �Ȃ̂Ŋ�l���o�b�t�@�̓��e�����̂܂ܔ�r����
        _StencilWriteMask("Stencil Write Mask", Float) = 255

        // �X�e���V���e�X�g���s���O�Ɋ�l�ƃo�b�t�@�̓��e�̗����ɂ�����_���a�}�X�N
        // 0xFF �Ȃ̂Ŋ�l���o�b�t�@�̓��e�����̂܂ܔ�r����
        _StencilReadMask("Stencil Read Mask", Float) = 255

        // �`��𔽉f���Ȃ��J���[�`�����l���̐ݒ�
        // UnityEngine.Rendering.ColorWriteMask �Œ�`����Ă���
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.ColorWriteMask.html
        // 15 �́@All �ł���A�S�Ẵ`�����l��(A/B/G/R)���o�͂���
        _ColorMask("Color Mask", Float) = 15

        // UNITY_UI_ALPHACLIP �� define ���邩�ǂ���
        // 0 �Ȃ� define ���Ȃ�
        // Mask ���g��Ȃ��̂ł���ΕK�v�Ȃ�
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0

        _ScrollSpeed("Speed", FLOAT ) = 1.0
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Stencil
        {
            Ref[_Stencil]
            Comp[_StencilComp]
            Pass[_StencilOp]
            ReadMask[_StencilReadMask]
            WriteMask[_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest[unity_GUIZTestMode]
        Blend One OneMinusSrcAlpha
        ColorMask[_ColorMask]

        Pass
        {
            Name "Default"

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "UnityCG.cginc"
            #include "UnityUI.cginc"
            #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
            #pragma multi_compile_local _ UNITY_UI_ALPHACLIP

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                half4  mask : TEXCOORD2;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;
            float _MaskSoftnessX;
            float _MaskSoftnessY;
            float _ScrollSpeed;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

                float4 vPosition = UnityObjectToClipPos(v.vertex);
                OUT.worldPosition = v.vertex;
                OUT.vertex = vPosition;
                float2 pixelSize = vPosition.w;
                pixelSize /= float2(1, 1) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));
                float4 clampedRect = clamp(_ClipRect, -2e10, 2e10);
                float2 maskUV = (v.vertex.xy - clampedRect.xy) / (clampedRect.zw - clampedRect.xy);
                OUT.texcoord = float4(v.texcoord.x, v.texcoord.y, maskUV.x, maskUV.y);
                OUT.mask = half4(v.vertex.xy * 2 - clampedRect.xy - clampedRect.zw,
                0.25 / (0.25 * half2(_MaskSoftnessX, _MaskSoftnessY) + abs(pixelSize.xy)));
                OUT.color = v.color * _Color;
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                float2 uv = IN.texcoord;
                uv.x += _ScrollSpeed * _Time.y;
                half4 color = (tex2D(_MainTex, uv) + _TextureSampleAdd) * IN.color;
                #ifdef UNITY_UI_CLIP_RECT
                half2 m = saturate((_ClipRect.zw - _ClipRect.xy - abs(IN.mask.xy)) * IN.mask.zw);
                color.a *= m.x * m.y;
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip(color.a - 0.001);
                #endif
                color.rgb *= color.a;
                return color;
            }
        ENDCG
       }
    }
}