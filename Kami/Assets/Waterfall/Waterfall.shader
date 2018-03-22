// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32853,y:32731,varname:node_4013,prsc:2|diff-3512-OUT,transm-3245-OUT,lwrap-3245-OUT,voffset-2233-OUT;n:type:ShaderForge.SFN_Multiply,id:515,x:32136,y:32960,varname:node_515,prsc:2|A-3985-RGB,B-2231-R;n:type:ShaderForge.SFN_Color,id:3985,x:31945,y:32752,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3152573,c2:0.5275735,c3:0.875,c4:1;n:type:ShaderForge.SFN_Append,id:9749,x:30660,y:32950,varname:node_9749,prsc:2|A-1612-OUT,B-4096-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1612,x:30489,y:32950,ptovrint:False,ptlb:U spped waves,ptin:_Usppedwaves,varname:node_6982,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:4096,x:30489,y:33039,ptovrint:False,ptlb:V speed waves,ptin:_Vspeedwaves,varname:node_8509,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:2231,x:31580,y:32951,ptovrint:False,ptlb:WaterTex,ptin:_WaterTex,varname:node_7343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a2d34dcd5d0214d4c9863665e20e652e,ntxv:0,isnm:False|UVIN-9907-OUT;n:type:ShaderForge.SFN_Add,id:9907,x:31016,y:32950,varname:node_9907,prsc:2|A-8124-OUT,B-5317-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5317,x:30810,y:33352,varname:node_5317,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Multiply,id:8124,x:30833,y:32950,varname:node_8124,prsc:2|A-9749-OUT,B-7356-T;n:type:ShaderForge.SFN_Time,id:7356,x:30660,y:33113,varname:node_7356,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6227,x:31206,y:33271,ptovrint:False,ptlb:WaveNoise,ptin:_WaveNoise,varname:node_7611,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9907-OUT;n:type:ShaderForge.SFN_Multiply,id:7244,x:31757,y:33274,varname:node_7244,prsc:2|A-4023-OUT,B-6227-R;n:type:ShaderForge.SFN_Add,id:6298,x:32324,y:32960,varname:node_6298,prsc:2|A-515-OUT,B-2043-OUT;n:type:ShaderForge.SFN_Clamp01,id:4370,x:32497,y:32960,varname:node_4370,prsc:2|IN-6298-OUT;n:type:ShaderForge.SFN_NormalVector,id:4031,x:32136,y:33403,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:2233,x:32324,y:33274,varname:node_2233,prsc:2|A-6538-OUT,B-4031-OUT,C-4038-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4023,x:31580,y:33125,ptovrint:False,ptlb:Use gradient?,ptin:_Usegradient,varname:node_7926,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1167-OUT,B-8428-OUT;n:type:ShaderForge.SFN_Vector1,id:1167,x:31388,y:33066,varname:node_1167,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:4038,x:32136,y:33573,ptovrint:False,ptlb:Vertex power,ptin:_Vertexpower,varname:node_6466,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RemapRange,id:9537,x:31963,y:33096,varname:node_9537,prsc:2,frmn:0,frmx:1,tomn:-5,tomx:10|IN-7244-OUT;n:type:ShaderForge.SFN_Clamp01,id:2043,x:32136,y:33096,varname:node_2043,prsc:2|IN-9537-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3245,x:32497,y:32872,ptovrint:False,ptlb:Transmission and Light Wrapping,ptin:_TransmissionandLightWrapping,varname:node_3245,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_SwitchProperty,id:6538,x:32136,y:33274,ptovrint:False,ptlb:Splash vertex?,ptin:_Splashvertex,varname:node_6538,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7244-OUT,B-9000-OUT;n:type:ShaderForge.SFN_Multiply,id:9000,x:31757,y:33400,varname:node_9000,prsc:2|A-6227-R,B-5317-Z;n:type:ShaderForge.SFN_SwitchProperty,id:3512,x:32686,y:32731,ptovrint:False,ptlb:Splash?,ptin:_Splash,varname:node_3512,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4370-OUT,B-3985-RGB;n:type:ShaderForge.SFN_OneMinus,id:8937,x:31206,y:33130,varname:node_8937,prsc:2|IN-5317-V;n:type:ShaderForge.SFN_Clamp01,id:8428,x:31388,y:33130,varname:node_8428,prsc:2|IN-8937-OUT;proporder:3985-1612-4096-2231-6227-4023-4038-3245-6538-3512;pass:END;sub:END;*/

Shader "ErbGameArt/Waterfall" {
    Properties {
        _Color ("Color", Color) = (0.3152573,0.5275735,0.875,1)
        _Usppedwaves ("U spped waves", Float ) = 0
        _Vspeedwaves ("V speed waves", Float ) = 0.5
        _WaterTex ("WaterTex", 2D) = "white" {}
        _WaveNoise ("WaveNoise", 2D) = "white" {}
        [MaterialToggle] _Usegradient ("Use gradient?", Float ) = 1
        _Vertexpower ("Vertex power", Float ) = 1
        _TransmissionandLightWrapping ("Transmission and Light Wrapping", Float ) = 1.2
        [MaterialToggle] _Splashvertex ("Splash vertex?", Float ) = 0
        [MaterialToggle] _Splash ("Splash?", Float ) = 0
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Usppedwaves;
            uniform float _Vspeedwaves;
            uniform sampler2D _WaterTex; uniform float4 _WaterTex_ST;
            uniform sampler2D _WaveNoise; uniform float4 _WaveNoise_ST;
            uniform fixed _Usegradient;
            uniform float _Vertexpower;
            uniform float _TransmissionandLightWrapping;
            uniform fixed _Splashvertex;
            uniform fixed _Splash;
			half _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7356 = _Time;
                float2 node_9907 = ((float2(_Usppedwaves,_Vspeedwaves)*node_7356.g)+o.uv0);
                float4 _WaveNoise_var = tex2Dlod(_WaveNoise,float4(TRANSFORM_TEX(node_9907, _WaveNoise),0.0,0));
                float node_7244 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_WaveNoise_var.r);
                v.vertex.xyz += (lerp( node_7244, (_WaveNoise_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertexpower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_TransmissionandLightWrapping,_TransmissionandLightWrapping,_TransmissionandLightWrapping)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_TransmissionandLightWrapping,_TransmissionandLightWrapping,_TransmissionandLightWrapping);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_7356 = _Time;
                float2 node_9907 = ((float2(_Usppedwaves,_Vspeedwaves)*node_7356.g)+i.uv0);
                float4 _WaterTex_var = tex2D(_WaterTex,TRANSFORM_TEX(node_9907, _WaterTex));
                float4 _WaveNoise_var = tex2D(_WaveNoise,TRANSFORM_TEX(node_9907, _WaveNoise));
                float node_7244 = (lerp( 1.0, saturate((1.0 - i.uv0.g)), _Usegradient )*_WaveNoise_var.r);
                float3 diffuseColor = lerp( saturate(((_Color.rgb*_WaterTex_var.r)+saturate((node_7244*15.0+-5.0)))), _Color.rgb, _Splash );
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
				clip(node_7244.r - _Cutoff);
                float3 finalColor = diffuse;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Usppedwaves;
            uniform float _Vspeedwaves;
            uniform sampler2D _WaterTex; uniform float4 _WaterTex_ST;
            uniform sampler2D _WaveNoise; uniform float4 _WaveNoise_ST;
            uniform fixed _Usegradient;
            uniform float _Vertexpower;
            uniform float _TransmissionandLightWrapping;
            uniform fixed _Splashvertex;
            uniform fixed _Splash;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7356 = _Time;
                float2 node_9907 = ((float2(_Usppedwaves,_Vspeedwaves)*node_7356.g)+o.uv0);
                float4 _WaveNoise_var = tex2Dlod(_WaveNoise,float4(TRANSFORM_TEX(node_9907, _WaveNoise),0.0,0));
                float node_7244 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_WaveNoise_var.r);
                v.vertex.xyz += (lerp( node_7244, (_WaveNoise_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertexpower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_TransmissionandLightWrapping,_TransmissionandLightWrapping,_TransmissionandLightWrapping)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_TransmissionandLightWrapping,_TransmissionandLightWrapping,_TransmissionandLightWrapping);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 node_7356 = _Time;
                float2 node_9907 = ((float2(_Usppedwaves,_Vspeedwaves)*node_7356.g)+i.uv0);
                float4 _WaterTex_var = tex2D(_WaterTex,TRANSFORM_TEX(node_9907, _WaterTex));
                float4 _WaveNoise_var = tex2D(_WaveNoise,TRANSFORM_TEX(node_9907, _WaveNoise));
                float node_7244 = (lerp( 1.0, saturate((1.0 - i.uv0.g)), _Usegradient )*_WaveNoise_var.r);
                float3 diffuseColor = lerp( saturate(((_Color.rgb*_WaterTex_var.r)+saturate((node_7244*15.0+-5.0)))), _Color.rgb, _Splash );
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            uniform float _Usppedwaves;
            uniform float _Vspeedwaves;
            uniform sampler2D _WaveNoise; uniform float4 _WaveNoise_ST;
            uniform fixed _Usegradient;
            uniform float _Vertexpower;
            uniform fixed _Splashvertex;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7356 = _Time;
                float2 node_9907 = ((float2(_Usppedwaves,_Vspeedwaves)*node_7356.g)+o.uv0);
                float4 _WaveNoise_var = tex2Dlod(_WaveNoise,float4(TRANSFORM_TEX(node_9907, _WaveNoise),0.0,0));
                float node_7244 = (lerp( 1.0, saturate((1.0 - o.uv0.g)), _Usegradient )*_WaveNoise_var.r);
                v.vertex.xyz += (lerp( node_7244, (_WaveNoise_var.r*o.uv0.b), _Splashvertex )*v.normal*_Vertexpower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
