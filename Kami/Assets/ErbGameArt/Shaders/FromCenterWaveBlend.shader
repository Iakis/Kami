Shader "ErbGameArt/Projector/Alpha blended/FromCenterWave" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.4779412,0.6975659,1,1)
        _Emission ("Emission", Float ) = 2
        _MoveCirle ("MoveCirle", Range(0.01, 4)) = 4
		_Opacity ("Opacity", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _Emission;
            uniform float _MoveCirle;
			uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
			
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			
            VertexOutput vert (VertexInput v) {
               VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
				o.uv0 = mul (unity_Projector, v.vertex);
				o.uvFalloff = mul (unity_ProjectorClip, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
			
			sampler2D _MainTex;
			
            float4 frag(VertexOutput i) : COLOR {
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4906 = 0.5;
                float2 node_6035 = (i.uv0-node_4906);
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*_Emission*saturate(((saturate((1.0 - length(abs((node_6035/(node_4906*_MoveCirle))))))*saturate(length(abs((node_6035/(_MoveCirle*0.2*_MoveCirle*_MoveCirle))))))+saturate((1.0 - length(abs((node_6035/(_MoveCirle*0.13)))))))));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_MainTex_var.a*i.vertexColor.a*_Opacity));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
}
