Shader "Custom/CRTShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            float4 frag (v2f i) : SV_Target {
                float2 uv = i.uv;
                // Adding horizontal lines
                float line = sin(uv.y * 80.0) * 0.2; // '80.0' controls line density, '0.2' controls line visibility
                float4 tex = tex2D(_MainTex, uv);
                return tex * (1.0 + line);
            }
            ENDCG
        }
    } 
    FallBack "Diffuse"
}
