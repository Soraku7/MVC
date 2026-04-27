Shader "Toon/Basic"
{
    Properties
    {
        _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
        _MainTex ("Base Map", 2D) = "white" {}
        _ToonShade ("Toon Shader Cubemap", CUBE) = "" {}
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Opaque"
            "Queue"="Geometry"
        }

        Pass
        {
            Name "BASE"
            Tags { "LightMode"="UniversalForward" }

            Cull Off
            ZWrite On

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            TEXTURECUBE(_ToonShade);
            SAMPLER(sampler_ToonShade);

            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float4 _MainTex_ST;
            CBUFFER_END

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalVS : TEXCOORD1;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;

                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);

                float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.normalVS = TransformWorldToViewDir(normalWS);

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 baseCol = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * _Color;
                half4 toonCol = SAMPLE_TEXTURECUBE(_ToonShade, sampler_ToonShade, normalize(input.normalVS));

                return half4(2.0h * toonCol.rgb * baseCol.rgb, baseCol.a);
            }

            ENDHLSL
        }
    }

    Fallback Off
}