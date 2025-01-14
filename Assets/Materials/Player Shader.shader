Shader "Custom/Player Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _EmissionColor("Emission Color", Color) = (0, 0, 0, 0)
        _MyAlpha("Alpha", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Transparent"
        }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        float4 _Color;
        float4 _EmissionColor;
        struct Input
        {
            float2 Dummy;
        };

        half _Glossiness;
        half _Metallic;
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            o.Albedo = _Color;
            o.Emission = _EmissionColor;
        }
        #pragma surface surf2 Lambert alpha
        sampler2D _MyTexture;
        float _MyAlpha;
        struct Input2
        {
            float2 uv_MyTexture;    
        };
        void surf2 (Input2 IN, SurfaceOutput o)
        {
            o.Albedo = tex2D(_MyTexture, _MyAlpha).rgb*_MyAlpha;
            o.Alpha = _MyAlpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
