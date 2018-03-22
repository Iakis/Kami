// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32742,y:32719,varname:node_4013,prsc:2|diff-941-OUT,transm-2771-OUT,lwrap-2771-OUT;n:type:ShaderForge.SFN_Tex2d,id:8454,x:31441,y:32719,varname:node_7343,prsc:2,tex:076f489dff6d46346b1d7bf609f64c79,ntxv:0,isnm:False|UVIN-357-OUT,TEX-9176-TEX;n:type:ShaderForge.SFN_Color,id:373,x:32321,y:32557,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5660,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2432958,c2:0.3601896,c3:0.5514706,c4:1;n:type:ShaderForge.SFN_Multiply,id:3450,x:31642,y:32719,varname:node_3450,prsc:2|A-8454-R,B-1505-G;n:type:ShaderForge.SFN_Add,id:941,x:32528,y:32719,varname:node_941,prsc:2|A-373-RGB,B-4451-OUT;n:type:ShaderForge.SFN_RemapRange,id:9231,x:31822,y:32719,varname:node_9231,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3450-OUT;n:type:ShaderForge.SFN_Clamp01,id:7369,x:31991,y:32719,varname:node_7369,prsc:2|IN-9231-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9176,x:31245,y:32719,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_9851,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:076f489dff6d46346b1d7bf609f64c79,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1505,x:31441,y:32890,varname:node_1325,prsc:2,tex:076f489dff6d46346b1d7bf609f64c79,ntxv:0,isnm:False|UVIN-9535-OUT,TEX-9176-TEX;n:type:ShaderForge.SFN_Append,id:3573,x:30889,y:32890,varname:node_3573,prsc:2|A-1023-OUT,B-3613-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1023,x:30718,y:32890,ptovrint:False,ptlb:U speed waves,ptin:_Uspeedwaves,varname:node_6982,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.0253;n:type:ShaderForge.SFN_ValueProperty,id:3613,x:30718,y:32979,ptovrint:False,ptlb:V speed waves,ptin:_Vspeedwaves,varname:node_8509,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.2;n:type:ShaderForge.SFN_Add,id:357,x:31245,y:32890,varname:node_357,prsc:2|A-3959-OUT,B-1147-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1147,x:31062,y:33041,varname:node_1147,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3959,x:31062,y:32890,varname:node_3959,prsc:2|A-3573-OUT,B-2617-T;n:type:ShaderForge.SFN_Time,id:2617,x:30889,y:33041,varname:node_2617,prsc:2;n:type:ShaderForge.SFN_Append,id:4696,x:30889,y:33200,varname:node_4696,prsc:2|A-1749-OUT,B-880-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1749,x:30718,y:33200,ptovrint:False,ptlb:U speed2 waves,ptin:_Uspeed2waves,varname:_Usppedwaves_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:880,x:30718,y:33289,ptovrint:False,ptlb:V speed2 waves,ptin:_Vspeed2waves,varname:_Vspeedwaves_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.3;n:type:ShaderForge.SFN_Add,id:9535,x:31245,y:33200,varname:node_9535,prsc:2|A-2879-OUT,B-1147-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2879,x:31062,y:33200,varname:node_2879,prsc:2|A-4696-OUT,B-2617-T;n:type:ShaderForge.SFN_OneMinus,id:8568,x:31614,y:33081,varname:node_8568,prsc:2|IN-1147-V;n:type:ShaderForge.SFN_Multiply,id:1429,x:31991,y:32890,varname:node_1429,prsc:2|A-4369-OUT,B-356-OUT;n:type:ShaderForge.SFN_ValueProperty,id:356,x:31822,y:33041,ptovrint:False,ptlb:Center glow,ptin:_Centerglow,varname:node_4393,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:4436,x:32155,y:32719,varname:node_4436,prsc:2|A-7369-OUT,B-1429-OUT;n:type:ShaderForge.SFN_Clamp01,id:4451,x:32321,y:32719,varname:node_4451,prsc:2|IN-4436-OUT;n:type:ShaderForge.SFN_Power,id:4369,x:31822,y:32890,varname:node_4369,prsc:2|VAL-8568-OUT,EXP-9566-OUT;n:type:ShaderForge.SFN_Vector1,id:9566,x:31637,y:32890,varname:node_9566,prsc:2,v1:1.4;n:type:ShaderForge.SFN_ValueProperty,id:2771,x:32528,y:32879,ptovrint:False,ptlb:Transmission and Light Wrapping,ptin:_TransmissionandLightWrapping,varname:node_3245,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;proporder:373-9176-356-2771-1023-3613-1749-880;pass:END;sub:END;*/

Shader "ErbGameArt/WaterWaves" {
    Properties {
        _Color ("Color", Color) = (0.2432958,0.3601896,0.5514706,1)
        _Noise ("Noise", 2D) = "white" {}
        _Centerglow ("Center glow", Float ) = 3
        _TransmissionandLightWrapping ("Transmission and Light Wrapping", Float ) = 1.2
        _Uspeedwaves ("U speed waves", Float ) = -0.0253
        _Vspeedwaves ("V speed waves", Float ) = -0.2
        _Uspeed2waves ("U speed2 waves", Float ) = 0.1
        _Vspeed2waves ("V speed2 waves", Float ) = -0.3
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Uspeedwaves;
            uniform float _Vspeedwaves;
            uniform float _Uspeed2waves;
            uniform float _Vspeed2waves;
            uniform float _Centerglow;
            uniform float _TransmissionandLightWrapping;
			half _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
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
                float4 node_2617 = _Time;
                float2 node_357 = ((float2(_Uspeedwaves,_Vspeedwaves)*node_2617.g)+i.uv0);
                float4 node_7343 = tex2D(_Noise,TRANSFORM_TEX(node_357, _Noise));
                float2 node_9535 = ((float2(_Uspeed2waves,_Vspeed2waves)*node_2617.g)+i.uv0);
                float4 node_1325 = tex2D(_Noise,TRANSFORM_TEX(node_9535, _Noise));
                float3 diffuseColor = (_Color.rgb+saturate((saturate(((node_7343.r*node_1325.g)*2.0+-1.0))*(pow((1.0 - i.uv0.g),1.4)*_Centerglow))));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
				clip(diffuseColor.r - _Cutoff);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Uspeedwaves;
            uniform float _Vspeedwaves;
            uniform float _Uspeed2waves;
            uniform float _Vspeed2waves;
            uniform float _Centerglow;
            uniform float _TransmissionandLightWrapping;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
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
                float4 node_2617 = _Time;
                float2 node_357 = ((float2(_Uspeedwaves,_Vspeedwaves)*node_2617.g)+i.uv0);
                float4 node_7343 = tex2D(_Noise,TRANSFORM_TEX(node_357, _Noise));
                float2 node_9535 = ((float2(_Uspeed2waves,_Vspeed2waves)*node_2617.g)+i.uv0);
                float4 node_1325 = tex2D(_Noise,TRANSFORM_TEX(node_9535, _Noise));
                float3 diffuseColor = (_Color.rgb+saturate((saturate(((node_7343.r*node_1325.g)*2.0+-1.0))*(pow((1.0 - i.uv0.g),1.4)*_Centerglow))));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
