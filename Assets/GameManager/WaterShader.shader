Shader "Unlit/WaterShader"
{
    Properties
    {
        // テクスチャが一致した場合にバッチングが効くようにするため、
        // テクスチャは Material から直接ではなく MaterialPropertyBlock 経由で設定する
        // （なお、UI シェーダーでは基本的に MaterialPropertyBlock を使うことはできない）
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}

        // 色
        _Color("Tint", Color) = (1,1,1,1)

        // ステンシル比較関数
        // UnityEngine.Rendering.CompareFunction で定義されている
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.CompareFunction.html
        // 8 は Always であり、常にステンシルテストが成功する
        _StencilComp("Stencil Comparison", Float) = 8

        // ステンシルテストの基準値（0 ～ 255）
        _Stencil("Stencil ID", Float) = 0

        // ステンシルテスト成功時の挙動
        // UnityEngine.Rendering.StencilOp で定義されている
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.StencilOp.html
        // 0 は Keep であり、変更を行わない
        _StencilOp("Stencil Operation", Float) = 0

        // ステンシルテストを行った後にバッファに基準値を書き込むビットを指定するマスク
        // 0xFF なので基準値もバッファの内容もそのまま比較する
        _StencilWriteMask("Stencil Write Mask", Float) = 255

        // ステンシルテストを行う前に基準値とバッファの内容の両方にかける論理和マスク
        // 0xFF なので基準値もバッファの内容もそのまま比較する
        _StencilReadMask("Stencil Read Mask", Float) = 255

        // 描画を反映しないカラーチャンネルの設定
        // UnityEngine.Rendering.ColorWriteMask で定義されている
        // https://docs.unity3d.com/ja/current/ScriptReference/Rendering.ColorWriteMask.html
        // 15 は　All であり、全てのチャンネル(A/B/G/R)を出力する
        _ColorMask("Color Mask", Float) = 15

        // UNITY_UI_ALPHACLIP を define するかどうか
        // 0 なら define しない
        // Mask を使わないのであれば必要ない
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