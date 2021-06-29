//////////////////////////////////////////////////////////////
/// Shadero Sprite: Sprite Shader Editor - by VETASOFT 2018 //
/// Shader generate with Shadero 1.9.6                      //
/// http://u3d.as/V7t #AssetStore                           //
/// http://www.shadero.com #Docs                            //
//////////////////////////////////////////////////////////////

Shader "Shadero Customs/logo"
{
Properties
{
[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
_NewTex_1("NewTex_1(RGB)", 2D) = "white" { }
_ShinyFX_Pos_1("_ShinyFX_Pos_1", Range(-1, 1)) = -0.088
_ShinyFX_Size_1("_ShinyFX_Size_1", Range(-1, 1)) = -0.166
_ShinyFX_Smooth_1("_ShinyFX_Smooth_1", Range(0, 1)) = 0.326
_ShinyFX_Intensity_1("_ShinyFX_Intensity_1", Range(0, 4)) = 1
_ShinyFX_Speed_1("_ShinyFX_Speed_1", Range(0, 8)) = 1
AnimatedZoomUV_AnimatedZoomUV_Zoom_1("AnimatedZoomUV_AnimatedZoomUV_Zoom_1", Range(0.2, 4)) = 1.168
AnimatedZoomUV_AnimatedZoomUV_PosX_1("AnimatedZoomUV_AnimatedZoomUV_PosX_1", Range(-1, 2)) = 0.5
AnimatedZoomUV_AnimatedZoomUV_PosY_1("AnimatedZoomUV_AnimatedZoomUV_PosY_1", Range(-1, 2)) = 0.5
AnimatedZoomUV_AnimatedZoomUV_Intensity_1("AnimatedZoomUV_AnimatedZoomUV_Intensity_1", Range(0, 4)) = 0.5
AnimatedZoomUV_AnimatedZoomUV_Speed_1("AnimatedZoomUV_AnimatedZoomUV_Speed_1", Range(-10, 10)) = 10
_NewTex_2("NewTex_2(RGB)", 2D) = "white" { }
_OperationBlend_Fade_1("_OperationBlend_Fade_1", Range(0, 1)) = 1
_SpriteFade("SpriteFade", Range(0, 1)) = 1.0

// required for UI.Mask
[HideInInspector]_StencilComp("Stencil Comparison", Float) = 8
[HideInInspector]_Stencil("Stencil ID", Float) = 0
[HideInInspector]_StencilOp("Stencil Operation", Float) = 0
[HideInInspector]_StencilWriteMask("Stencil Write Mask", Float) = 255
[HideInInspector]_StencilReadMask("Stencil Read Mask", Float) = 255
[HideInInspector]_ColorMask("Color Mask", Float) = 15

}

SubShader
{

Tags {"Queue" = "Transparent" "IgnoreProjector" = "true" "RenderType" = "Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True" }
ZWrite Off Blend SrcAlpha OneMinusSrcAlpha Cull Off 

// required for UI.Mask
Stencil
{
Ref [_Stencil]
Comp [_StencilComp]
Pass [_StencilOp]
ReadMask [_StencilReadMask]
WriteMask [_StencilWriteMask]
}

Pass
{

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

struct appdata_t{
float4 vertex   : POSITION;
float4 color    : COLOR;
float2 texcoord : TEXCOORD0;
};

struct v2f
{
float2 texcoord  : TEXCOORD0;
float4 vertex   : SV_POSITION;
float4 color    : COLOR;
};

sampler2D _MainTex;
float _SpriteFade;
sampler2D _NewTex_1;
float _ShinyFX_Pos_1;
float _ShinyFX_Size_1;
float _ShinyFX_Smooth_1;
float _ShinyFX_Intensity_1;
float _ShinyFX_Speed_1;
float AnimatedZoomUV_AnimatedZoomUV_Zoom_1;
float AnimatedZoomUV_AnimatedZoomUV_PosX_1;
float AnimatedZoomUV_AnimatedZoomUV_PosY_1;
float AnimatedZoomUV_AnimatedZoomUV_Intensity_1;
float AnimatedZoomUV_AnimatedZoomUV_Speed_1;
sampler2D _NewTex_2;
float _OperationBlend_Fade_1;

v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = UnityObjectToClipPos(IN.vertex);
OUT.texcoord = IN.texcoord;
OUT.color = IN.color;
return OUT;
}


float4 OperationBlend(float4 origin, float4 overlay, float blend)
{
float4 o = origin; 
o.a = overlay.a + origin.a * (1 - overlay.a);
o.rgb = (overlay.rgb * overlay.a + origin.rgb * origin.a * (1 - overlay.a)) * (o.a+0.0000001);
o.a = saturate(o.a);
o = lerp(origin, o, blend);
return o;
}
float2 AnimatedZoomUV(float2 uv, float zoom, float posx, float posy, float radius, float speed)
{
float2 center = float2(posx, posy);
uv -= center;
zoom -= radius * 0.1;
zoom += sin(_Time * speed * 20) * 0.1 * radius;
uv = uv * zoom;
uv += center;
return uv;
}
float4 ShinyFX(float4 txt, float2 uv, float pos, float size, float smooth, float intensity, float speed)
{
pos = pos + 0.5+sin(_Time*20*speed)*0.5;
uv = uv - float2(pos, 0.5);
float a = atan2(uv.x, uv.y) + 1.4, r = 3.1415;
float d = cos(floor(0.5 + a / r) * r - a) * length(uv);
float dist = 1.0 - smoothstep(size, size + smooth, d);
txt.rgb += dist*intensity;
return txt;
}
float4 frag (v2f i) : COLOR
{
float4 NewTex_1 = tex2D(_NewTex_1, i.texcoord);
float4 _ShinyFX_1 = ShinyFX(NewTex_1,i.texcoord,_ShinyFX_Pos_1,_ShinyFX_Size_1,_ShinyFX_Smooth_1,_ShinyFX_Intensity_1,_ShinyFX_Speed_1);
float2 AnimatedZoomUV_1 = AnimatedZoomUV(i.texcoord,AnimatedZoomUV_AnimatedZoomUV_Zoom_1,AnimatedZoomUV_AnimatedZoomUV_PosX_1,AnimatedZoomUV_AnimatedZoomUV_PosY_1,AnimatedZoomUV_AnimatedZoomUV_Intensity_1,AnimatedZoomUV_AnimatedZoomUV_Speed_1);
float4 NewTex_2 = tex2D(_NewTex_2,AnimatedZoomUV_1);
float4 OperationBlend_1 = OperationBlend(_ShinyFX_1, NewTex_2, _OperationBlend_Fade_1); 
float4 FinalResult = OperationBlend_1;
FinalResult.rgb *= i.color.rgb;
FinalResult.a = FinalResult.a * _SpriteFade * i.color.a;
return FinalResult;
}

ENDCG
}
}
Fallback "Sprites/Default"
}
