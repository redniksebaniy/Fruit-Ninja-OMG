Shader "Custom/BlurEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0.001, 0.01)) = 0.005
        _Iterations("Iteration Count", Integer) = 1
    }
    SubShader
    {
        ColorMask RGBA
        Lighting Off 
        Cull Off 
        ZWrite Off 
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
                       
            sampler2D _MainTex;
            
            uniform float _BlurSize;
            
            uniform int _Iterations;
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                const half alpha = col.a;
                
                col.rgb *= _Iterations;
                
                for (int it = 1; it <= _Iterations; it++)
                {                    
                    col.rgb += tex2D(_MainTex, i.uv + half2( _BlurSize * it, 0)).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2(-_BlurSize * it, 0)).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2(0,  _BlurSize * it)).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2(0, -_BlurSize * it)).rgb;
                    
                    col.rgb += tex2D(_MainTex, i.uv + half2( _BlurSize,  _BlurSize) * it).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2(-_BlurSize,  _BlurSize) * it).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2( _BlurSize, -_BlurSize) * it).rgb;
                    col.rgb += tex2D(_MainTex, i.uv + half2(-_BlurSize, -_BlurSize) * it).rgb;
                }
                
                col /= 9 * _Iterations;

                col.a = alpha;
                
                return col;
            }
            ENDCG
        }
    }
}
