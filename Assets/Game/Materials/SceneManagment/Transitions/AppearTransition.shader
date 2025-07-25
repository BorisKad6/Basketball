Shader "Unlit/AppearTrasitionEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Grain ("Grain", float) = 1 
        _Fullness ("Fullness", float) = 0.5
        _Intensity ("Intensity", float) = 1
        _Pow ("Pow", float) = 1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha 
        ZWrite Off  
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Grain;
            float _Fullness;
            float _Pow;
            float _Intensity;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            float hash(float2 p)
            {
                return frac(sin(dot(p, float2(127.1, 311.7))) * 43758.5453);
            }
            float noise(float2 p)
            {
                float2 i = floor(p);
                float2 f = frac(p);
                float2 u = f * f * (3.0 - 2.0 * f);
                return lerp(
                    lerp(hash(i + float2(0.0, 0.0)),
                    hash(i + float2(1.0, 0.0)), u.x),
                    lerp(hash(i + float2(0.0, 1.0)),
                    hash(i + float2(1.0, 1.0)), u.x),
                u.y);
            }
                        float invLerp(float from, float to, float value) {
              return (value - from) / (to - from);
            }

            float4 invLerp(float4 from, float4 to, float4 value) {
              return (value - from) / (to - from);
            }

            float remap(float origFrom, float origTo, float targetFrom, float targetTo, float value){
              float rel = invLerp(origFrom, origTo, value);
              return lerp(targetFrom, targetTo, rel);
            }

            float4 remap(float4 origFrom, float4 origTo, float4 targetFrom, float4 targetTo, float4 value){
              float4 rel = invLerp(origFrom, origTo, value);
              return lerp(targetFrom, targetTo, rel);
            }
            fixed4 frag (v2f i) : SV_Target
            {
                fixed offset = (1/_Intensity)/2;
                fixed noice = noise(i.uv * _Grain);
                fixed yFactor = pow(distance(i.uv.y, 0.5), _Pow);
                fixed dist = i.uv.x - remap(0,1, 0-offset, 1 +offset, _Fullness)+yFactor;
                noice += dist * _Intensity;
                noice = round(noice);
                fixed4 col = noice;
                col.xyz = 1- noice
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
