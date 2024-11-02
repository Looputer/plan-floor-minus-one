Shader "Custom/Player Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _EmissionColor("Emission Color", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        float4 _Color;
        float4 _EmissionColor;
        struct Input
        {
            float2 Dummy;
        };

        half _Glossiness;
        half _Metallic;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            o.Albedo = _Color;
            o.Emission = _EmissionColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
